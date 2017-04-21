using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using BSU.Utils.Data;
using Constants;
using Samples;
using Samples.libs;
using WowLauncher.Utils;
using Mania.Launcher.Config;
using Mania.Launcher.Logic;
using Mania.Launcher.Logic.Updating;
using Mania.Launcher.Properties;
using Mania.Launcher.Utils;
using Mania.Utils.News;
using MessageBox = System.Windows.MessageBox;
using Button = System.Windows.Controls.Button;
using Point = System.Windows.Point;
using Label = System.Windows.Controls.Label;
using Mania.Utils;
using System.Windows.Media.Effects;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media.Animation;
using Mania.Utils.ProgressBar;
using Mania.Utils.Patching;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;
using Mania.Language;
using System.Xml;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Resources;


namespace Mania.Launcher
{
    public partial class MainWindow : Window
    {
        private readonly WebClient _web;
        private readonly WebClientFactory _webClientFactory;
        private readonly WowUpdater _updater;
        private readonly LauncherLogic _launcher;
        private readonly XmlHelper _xmlhelper;
        private readonly AddressSet _addressSet;
        private readonly IpPortConfig _mySqlConfig;
        private readonly IpPortConfig _worldConfig;

        public MainWindow()
        {
            InitializeComponent();

            #region SET VISIBILITY ELEMENTS

            SetVisibilityToHotNewsBlock(false);
            ProgressBar1.Visibility = Visibility.Hidden;
            bannersLoader.Visibility = Visibility.Hidden;
            initIndicator.Visibility = Visibility.Hidden;

            #endregion

            #region Конфиги Mysql и игровые
            _webClientFactory = new WebClientFactory();
            _web = _webClientFactory.Create();

            var mySqlConfig = new IpPortConfig
            {
                Ip = Settings.Default.mysql_ip,
                Port = Settings.Default.mysql_port
            };
            var worldConfig = new IpPortConfig
            {
                Ip = Settings.Default.world_ip,
                Port = Settings.Default.world_port
            };
            #endregion

            #region ADRESSET (Логика для использования функций серверной части)

            var addressSet = new AddressSet
            {
                ServerPid = UrlHelper.Combine(Settings.Default.update_folder, Wow.FileName.PID_FILE_NAME),
                ServerPidClientPt = UrlHelper.Combine(Settings.Default.down_client_pt, Wow.FileName.PID_FILE_NAME),
                ServerPidClientEn = UrlHelper.Combine(Settings.Default.down_client_en, Wow.FileName.PID_FILE_NAME),

                ServerPatchFile = Settings.Default.patchlist,
                //ServerFilesRoot = Settings.Default.update_folder,

                HotNews = string.Format(Settings.Default.api_url + "?_key={0}&_url=hot_news", Settings.Default.skey_api),
                LoadBannerNews = string.Format(Settings.Default.api_url + "?_key={0}&_url=news", Settings.Default.skey_api),

            };

            #endregion

            _addressSet = addressSet;
            _mySqlConfig = mySqlConfig;
            _worldConfig = worldConfig;
            _xmlhelper = new XmlHelper();

            var ClientLocation = LocalConfiguration.Instance.Files.ConfDataFile;
            string rootDirectory = _xmlhelper.GetSettingValue("realm1_client_location");
            string localPidFile = Path.Combine(rootDirectory, Wow.FileName.PID_FILE_NAME);

            #region IF PATH TO GAME EXISTS - CHECK AN UPDATE
            if (rootDirectory != "")
            {        
                string langApp = _xmlhelper.GetSettingValue("client_lang");
                switch (langApp)
                {
                    case "pt":
                        string ServerFilesRootPT = Settings.Default.down_client_pt;
                        string ServerPatchFilePt = Settings.Default.down_client_pt_patch;

                        _updater = new WowUpdater(rootDirectory, addressSet.ServerPidClientPt, localPidFile, ServerPatchFilePt, ServerFilesRootPT);
                        _updater.UpdateProgressChanged += Updater_UpdateProgressChanged;
                        _updater.UpdateStateChanged += Updater_UpdateStateChanged;
                        _updater.UpdateDownloadInfo += Updater_UpdateInfoChanged;
                        break;

                    case "en":
                        string ServerFilesRootEN = Settings.Default.down_client_en;
                        string ServerPatchFileEn = Settings.Default.down_client_en_patch;
                        _updater = new WowUpdater(rootDirectory, addressSet.ServerPidClientEn, localPidFile, ServerPatchFileEn, ServerFilesRootEN);
                        _updater.UpdateProgressChanged += Updater_UpdateProgressChanged;
                        _updater.UpdateStateChanged += Updater_UpdateStateChanged;
                        _updater.UpdateDownloadInfo += Updater_UpdateInfoChanged;
                        break;

                    default:
                        break;
                }

                
                this.WelcomeBlock.HideBlock();
            }
            else
            {
                this.WelcomeBlock.ShowBlock();
                playButton.Visibility = Visibility.Hidden;
            }
            #endregion

            #region LAUNCHER LOGIC

            _launcher = new LauncherLogic(addressSet, mySqlConfig, worldConfig);

            #endregion

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Translate();
            clearLogs();
            _launcher.DataLoadingStateChanged += Launcher_DataLoadingStateChanged;
            _launcher.NewsLoadStateChanged += Launcher_NewsLoadStateChanged;
            _launcher.NewsLoadBanner += Launcher_NewsLoadBanner;
            _launcher.Initialize();
           // UpdateOnlinePlayersCounter(_addressSet.OnlinePlayers, _worldConfig.Ip, _worldConfig.Port);

            await CheckAndUpdate(_updater);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        #region GENERAL CHECK UPDATE

        async Task CheckAndUpdate(WowUpdater _updater)
        {
            try
            {
                bool needUpdate = await _updater.CheckUpdateAsync();
                if (needUpdate)
                {
                    _updater.Update();
                    Logger.Current.AppendText("Началось обновление игрового клиента");
                }
            }
            catch (Exception ex) { Logger.Current.AppendException(ex); }
        }

        #endregion

        #region Show progressbar and miniprogressbar in % and Updated Info

        private void Updater_UpdateProgressChanged(object sender, ProgressEventArgs e)
        {
            this.ProgressBar1.SetPercentage(this.ProgressBar1.Percentage = e.Progress);
        }

        private void Updater_UpdateInfoChanged(object sender, InfoEventArgs e)
        {
            ResourceProvider resource = ResourceProvider.Instance;
            float percentage = (e.Size - e.RemainingSize) / e.Size * 100;
            infoDownload.Content = string.Format(resource.Get(TextResource.DOWNLOAD_STATUS), e.Name, (int)percentage, Math.Round(e.RemainingSize, 1));
        }

        #endregion

        #region UPDATE LOGIC

        private void Updater_UpdateStateChanged(object sender, UpdateStateEventArgs e)
        {
            ResourceProvider resource = ResourceProvider.Instance;

            switch (e.NewState)
            {
                case UpdateState.None:
                    infoDownload.Visibility = Visibility.Hidden;
                    break;

                case UpdateState.Checking: //checking for update
                    playButton.IsEnabled = false;
                    break;

                case UpdateState.NotNeeded: //update not needed
                    playButton.IsEnabled = true;
                    this.ProgressBar1.NotNeeded();
                    ProgressBar1.Visibility = Visibility.Hidden;
                    playButton.Content = resource.Get(TextResource.PLAY);
                    break;

                case UpdateState.Started: //update start
                    FancyBalloon updateStart = new FancyBalloon();
                    updateStart.BalloonMessage = resource.Get(TextResource.UPDSTART);
                    tb.ShowCustomBalloon(updateStart, PopupAnimation.Slide, 5000);

                    infoDownload.Visibility = Visibility.Visible;
                    playButton.IsEnabled = false;
                    ProgressBar1.Visibility = Visibility.Visible;
                    playButton.Content = resource.Get(TextResource.UPDATING);
                    break;

                case UpdateState.Completed: //update success
                    FancyBalloon balloon = new FancyBalloon();
                    balloon.BalloonMessage = resource.Get(TextResource.UPDCOMPLETE);
                    tb.ShowCustomBalloon(balloon, PopupAnimation.Slide, 5000);
                    infoDownload.Visibility = Visibility.Hidden;
                    playButton.IsEnabled = true;
                    this.ProgressBar1.Complete();
                    playButton.Content = resource.Get(TextResource.PLAY);
                    Logger.Current.AppendText("Обновление успешно завершено");
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        #endregion

        #region BANNER NEWS

        private void Launcher_DataLoadingStateChanged(object sender, LauncherStateEventArgs e)
        {
            switch (e.State)
            {
                case LauncherState.ConnectionFailed:
                    bannersLoader.Visibility = Visibility.Hidden;
                    break;

                case LauncherState.InitializationStarted:
                    StartWaitAnimation();
                    break;

                case LauncherState.InitializationCompleted:
                    StopWaitAnimation();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Launcher_NewsLoadStateChanged(object sender, LoadTextEventArgs e)
        {
            string rootDirectory = _xmlhelper.GetSettingValue("realm1_client_location");

            switch (e.State)
            {
                case LoadingState.Canceled:
                    break;

                case LoadingState.Started:
                    StartWaitAnimation();
                    break;

                case LoadingState.Completed:
                    if (e.Result.Success)
                    {
                        if (rootDirectory == "")
                        {
                            SetVisibilityToHotNewsBlock(false);
                        }
                        else
                        {
                            hotNewsTextBox.Text = e.Result.Data;
                            SetVisibilityToHotNewsBlock(true);
                        }

                    }
                    else
                    {
                        hotNewsTextBox.Text = string.Empty;
                        SetVisibilityToHotNewsBlock(false);
                    }
                    StopWaitAnimation();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        //Вывод новостей реалм 1
        private void Launcher_NewsLoadBanner(object sender, LoadTextEventArgs e)
        {
            ResourceProvider resource = ResourceProvider.Instance;

            switch (e.State)
            {
                case LoadingState.Canceled:
                    break;

                case LoadingState.Started:
                    StartWaitAnimation();
                    break;

                case LoadingState.Completed:
                    bannersLoader.Visibility = Visibility.Visible;
                    try
                    {
                        if (e.Result.Success)
                        {
                            ExpressNewsSet newsSet = ExpressNewsSet.FromXml(e.Result.Data);
                            bannersLoader.NewsItems = newsSet.ExpressNews;
                        }
                    }
                    catch (Exception err)
                    {
                        FancyBalloon balloon = new FancyBalloon();
                        balloon.BalloonMessage = resource.Get(TextResource.NEWSBANNERERROR);
                        tb.ShowCustomBalloon(balloon, PopupAnimation.Slide, 5000);

                        Logger.Current.AppendException(err);
                    }
                    StopWaitAnimation();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        #endregion

        #region Hot News Visibility Block

        private void SetVisibilityToHotNewsBlock(bool visible)
        {
            if (visible)
            {
                hotNewsGrid1.Visibility = Visibility.Visible;
            }
            else
            {
                hotNewsGrid1.Visibility = Visibility.Hidden;
            }
        }

        #endregion

        #region Status and count players

        //private async void UpdateOnlinePlayersCounter(string onlinePlayersAddress, string worldIp, int worldPort)
        //{
        //    //ResourceProvider resource = ResourceProvider.Instance;

        //    //bool connected = await _launcher.CheckConnectionToServerAsync(worldIp, worldPort);
        //    //if (connected)
        //    //{
        //    //    on_off.Text = resource.Get(TextResource.ONLINE);
        //    //    on_off.Foreground = Brushes.Lime;

        //    //    WebClient web = _webClientFactory.Create();
        //    //    onlinePlayer.Content = await web.DownloadStringTaskAsync(onlinePlayersAddress);
        //    //}
        //    //else
        //    //{
        //    //    on_off.Text = resource.Get(TextResource.OFFLINE);
        //    //    on_off.Foreground = Brushes.Red;
        //    //    onlinePlayer.Content = "0";
        //    //}
        //}



        #endregion

        #region DEFAULT LINKS

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MinimizeButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void shopBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Settings.Default.shop_link);
        }

        private void forumBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Settings.Default.forum_link);
        }

        private void logo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(Settings.Default.site_link);
        }

        private void settingsBtn_Click(object sender, RoutedEventArgs e)
        {
            var settings = new SettingsWindow();
            settings.Owner = this;
            ApplyEffect(this);
            settings.ShowDialog();
            ClearEffect(this);
        }

        #endregion

        #region PLAY BUTTON

        private async void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            ResourceProvider resource = ResourceProvider.Instance;
            string nosExeFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Wow.FileName.MAPLESTORY_EXE_NAME);
            try
            {
                if (!File.Exists(nosExeFile))
                {
                    byte[] resf;
                    resf = Properties.Resources.NostaleRun;
                    System.IO.File.WriteAllBytes(nosExeFile, resf);
                    System.IO.File.SetAttributes(nosExeFile, FileAttributes.Hidden);
                    Logger.Current.AppendText("Создан файл запуска приложения");
                }

                var process = new Process();
                process.StartInfo.FileName = nosExeFile;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                //Logger.Current.AppendText("Запуск игрового клиента");
                //string getPass = EncDec.DeShifrovka(_xmlhelper.GetSettingValue("user_password"), "private_string");
                //Thread.Sleep(6000);
                //SendKeys.SendWait(_xmlhelper.GetSettingValue("user_login"));
                //SendKeys.SendWait("{Tab}");
                //Logger.Current.AppendText("Отправляем логин в игру");
                //SendKeys.SendWait(getPass);
                //Logger.Current.AppendText("Отправляем пароль в игру");
                //SendKeys.SendWait("{enter}");


                WindowState = WindowState.Minimized;

            }
            catch (Exception patchingErrorMain)
            {
                FancyBalloon balloon = new FancyBalloon();
                balloon.BalloonMessage = resource.Get(TextResource.EXENOTFOUND);
                tb.ShowCustomBalloon(balloon, PopupAnimation.Slide, 5000);
                Logger.Current.AppendText("Отсутствует файл запуска приложения");
            }

        }

        #endregion

        #region Методы обновления UI (потокобезопасные)

        private void UpdateResultText(string text)
        {
            if (Dispatcher.CheckAccess()) //Обращаемся ли мы к UI из не UI потока
            {
                newsAvailible.Text = "Download file: " + text;
            }
            else
            {
                Dispatcher.Invoke((Action<string>)UpdateResultText, text);
            }
        }

        private void ChangePlayButtonEnableState(bool state)
        {
            if (Dispatcher.CheckAccess()) //Обращаемся ли мы к UI из не UI потока
            {
                playButton.IsEnabled = state;
            }
            else
            {
                Dispatcher.Invoke((Action<bool>)ChangePlayButtonEnableState, state);
            }
        }

        #endregion

        #region ANIMATION

        public void StartWaitAnimation()
        {
            initIndicator.Visibility = Visibility.Visible;
        }
        public void StopWaitAnimation()
        {
            initIndicator.Visibility = Visibility.Hidden;
        }

        #endregion

        #region BLUR EFFECTS
        private void ApplyEffect(Window win)
        {
            BlurEffect objBlur = new BlurEffect();
            objBlur.Radius = 4;
            win.Effect = objBlur;
        }

        private void ClearEffect(Window win)
        {
            win.Effect = null;
        }

        #endregion

        #region DELETE LOGS
        private void clearLogs()
        {
            string[] files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppFolder.APP_LOGS_FOLDER_NAME));
            foreach (string file in files)
            {
                //if (DateTime.Now - File.GetCreationTime(file) < TimeSpan.FromDays(3d))
                // {
                File.Delete(file);
                Logger.Current.AppendText("Удаление старых Log файлов");
                //}
            }
        }
        #endregion

        #region TRANSLATE

        private void Translate()
        {
            ResourceProvider resource = ResourceProvider.Instance;
            string hotNewsConst = resource.Get(TextResource.HOTNEWS);
            string playConst = resource.Get(TextResource.PLAY);

            gamesBtn.Content = resource.Get(TextResource.GAMESBTN);
            newsBtn.Content = resource.Get(TextResource.NEWSBTN);
            minimizeButton.ToolTip = resource.Get(TextResource.TOOLMINI);
            closeButton.ToolTip = resource.Get(TextResource.TOOLCLOSE);
            settingsBtn.Content = resource.Get(TextResource.SETTINGSBTN);
            shopBtn.Content = resource.Get(TextResource.SHOPBTN);
            forumBtn.Content = resource.Get(TextResource.FORUMBTN);

            playButton.Content = playConst;
            hotNewsLabel.Content = hotNewsConst;

            Logger.Current.AppendText("Завершен метод перевода главного окна");
        }

        #endregion

        #region TABS

        private void gamesBtn_Click(object sender, RoutedEventArgs e)
        {
            bg.Source = new BitmapImage(new Uri(@"/Resources/main_bg.jpg", UriKind.Relative));

            if (newsBtn.IsChecked == true)
            {
                newsBtn.IsChecked = false;
            }
            gameGrid.Visibility = Visibility.Visible;
            NewsTab.Visibility = Visibility.Hidden;
            WelcomeBlock.Visibility = Visibility.Visible;

        }

        private void newsBtn_Click(object sender, RoutedEventArgs e)
        {
            bg.Source = new BitmapImage(new Uri(@"/Resources/news_background.jpg", UriKind.Relative));


            if (gamesBtn.IsChecked == true)
            {
                gamesBtn.IsChecked = false;
            }

            gameGrid.Visibility = Visibility.Hidden;
            WelcomeBlock.Visibility = Visibility.Hidden;
            NewsTab.Visibility = Visibility.Visible;
        }

        #endregion

        


    }
}