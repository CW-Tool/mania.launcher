using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WowLauncher.Utils;
using Mania.Launcher.Config;
using Mania.Launcher.Logic;
using Mania.Launcher.Logic.Updating;
using Mania.Launcher.Properties;
using Mania.Launcher.Utils;
using Mania.Utils.News;
using MessageBox = System.Windows.MessageBox;
using Point = System.Windows.Point;
using Mania.Utils;
using BSU.Utils.Data;
using Constants;
using Samples;
using System.Net;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Resources;
using System.Windows.Media.Effects;
using System.Xml;
using Mania.Language;
using System.Security.Cryptography;

namespace Mania.Launcher
{
    public partial class LoginForm : Window
    {
        private readonly WebClient _web;
        private readonly WebClientFactory _webClientFactory;
        private readonly XmlHelper _xmlhelper;
        private bool _isPopupPanelOpened;
        ThicknessAnimation _animOpen;
        ThicknessAnimation _animClose;
        ThicknessAnimation _btnOpen;
        ThicknessAnimation _btnClose;
        ThicknessAnimation _errorOpen;
        ThicknessAnimation _errorClose;

        public LoginForm()
        {
            InitializeComponent();

            initIndicator.Visibility = Visibility.Hidden;
            _webClientFactory = new WebClientFactory();
            _xmlhelper = new XmlHelper();
            _web = _webClientFactory.Create();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Translate();
            LoadAccount();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public void StartWaitAnimation()
        {
            initIndicator.Visibility = Visibility.Visible;
        }

        public void StopWaitAnimation()
        {
            initIndicator.Visibility = Visibility.Hidden;
        }


        private async void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            ResourceProvider resource = ResourceProvider.Instance;

            string login = WebUtility.UrlEncode(loginBox.Text);
            string passwd = WebUtility.UrlEncode(passwordBox.Password);

            // Send the request to the server part
            string query = string.Format("{0}?_key={1}&_url=auth&login={2}&password={3}", Settings.Default.api_url, Settings.Default.skey_api, login, passwd);
            try
            {
                loginBtn.IsEnabled = false;
                loginBtn.Content = "";
                StartWaitAnimation();
                string authorization = await _web.DownloadStringTaskAsync(query);
                Logger.Current.AppendText("Отправляем пользовательские данные для проверки");

                if (authorization == "true")
                {
                    if (remember.IsChecked == true)
                    {
                        _xmlhelper.UpdateSettingValue("user_login", loginBox.Text);
                        _xmlhelper.UpdateSettingValue("user_password", EncDec.Shifrovka(passwordBox.Password, "private_string"));

                        Logger.Current.AppendText("Запоминаем пользователя в файле конфигурации");
                    }

                    var launcher = new MainWindow();
                    launcher.Show();
                    Logger.Current.AppendText("Авторизация прошла успешно");
                    this.Close();

                }
                else
                {
                    FancyBalloon balloon = new FancyBalloon();
                    balloon.BalloonMessage = resource.Get(TextResource.ERRORLOGINORPASSWORD);  
                    tb.ShowCustomBalloon(balloon, PopupAnimation.Slide, 5000);
                    Logger.Current.AppendText("Ошибка авторизации. Не верный логин или пароль");

                    loginBtn.Content = resource.Get(TextResource.LOGINBTN);
                    loginBtn.IsEnabled = true;
                    passwordBox.Password = string.Empty;
                    passwordBox.Focus();

                }

            }
            catch (Exception ex)
            {
                loginBtn.Content = resource.Get(TextResource.LOGINBTN);
                loginBtn.IsEnabled = true;
                FancyBalloon LoginError = new FancyBalloon();
                LoginError.BalloonMessage = resource.Get(TextResource.ERRORLOGIN); 
                tb.ShowCustomBalloon(LoginError, PopupAnimation.Slide, 5000);
                Logger.Current.AppendException(ex);
            }
            finally
            {
                StopWaitAnimation();
            }

        }

        private void registrBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Settings.Default.reg_link);
        }

        private void forgotBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Settings.Default.forg_pass_link);
        }


        private void LoadAccount()
        {
            try
            {
                if (File.Exists(LocalConfiguration.Instance.Files.ConfDataFile))
                {
                    loginBox.Text = _xmlhelper.GetSettingValue("user_login");

                    string getPass = EncDec.DeShifrovka(_xmlhelper.GetSettingValue("user_password"), "private_string");
                    passwordBox.Password = getPass;
                    Logger.Current.AppendText("Учетная запись загружена");
                }
            }
            catch (Exception ex)
            {
                Logger.Current.AppendText("Ошибка загрузки файла конфигурации");
                Logger.Current.AppendException(ex);
            }
        }

        #region  BLUR EFFECTS
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

        #region TRANSLATE
        private void Translate()
        {
            ResourceProvider resource = ResourceProvider.Instance;
            closeButton.ToolTip = resource.Get(TextResource.TOOLCLOSE);
            forgotPassBtn.Content = resource.Get(TextResource.FORGOTPWD);
            remember.Content = resource.Get(TextResource.REMEMBER);

            regBtn.Content = resource.Get(TextResource.CREATEACC);
            loginBtn.Content = resource.Get(TextResource.LOGINBTN);
            Logger.Current.AppendText("Завершен метод перевода окна авторизации");
        }

        #endregion

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password != string.Empty)
            {
                loginBtn.IsEnabled = true;
            }
            else
            {
                loginBtn.IsEnabled = false;
            }
        }

        private void passwordBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                loginBtn_Click(null, null);
            }
        }




    }
}

