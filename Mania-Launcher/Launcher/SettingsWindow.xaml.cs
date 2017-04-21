using System;
using System.IO;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using BSU.Utils.Data;
using Samples;
using Mania.Launcher.Config;
using Mania.Launcher.Utils;
using System.Windows.Controls;
using TextBox = System.Windows.Controls.TextBox;
using MessageBox = System.Windows.MessageBox;
using System.Windows.Forms;
using System.Windows.Media.Effects;
using Mania.Launcher.Dialogs;
using System.Xml;
using System.Collections;
using Mania.Language;
using System.Collections.Generic;
using System.Diagnostics;

namespace Mania.Launcher
{
    public partial class SettingsWindow : Window
    {

        private readonly XmlHelper _xmlhelper;

        public SettingsWindow()
        {
            InitializeComponent();
            SetResultText(string.Empty);
            _xmlhelper = new XmlHelper();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Translate();
            LoadData();
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void closeButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SetResultText(string text)
        {
            result.Text = text;
        }

        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            ResourceProvider resource = ResourceProvider.Instance;

            try
            {

                _xmlhelper.UpdateSettingValue("user_login", textBoxLogin.Text);
                _xmlhelper.UpdateSettingValue("user_password", EncDec.Shifrovka(passwordBox.Password, "private_string"));
                _xmlhelper.UpdateSettingValue("realm1_client_location", location1.Text);
   
                if (copyApp.IsChecked == true)
                {
                    _xmlhelper.UpdateSettingValue("run_copy_app", "false");
                }
                else
                {
                    _xmlhelper.UpdateSettingValue("run_copy_app", "true");
                }

                FancyBalloon balloon = new FancyBalloon();
                balloon.BalloonMessage = resource.Get(TextResource.SETTINGOK);
                tb.ShowCustomBalloon(balloon, PopupAnimation.Slide, 5000);
                Logger.Current.AppendText("Пользовательские данные успешно сохранены");
                SetResultText("");

                var popupReset = new PopupDialogReset();
                popupReset.Owner = this;
                ApplyEffect(this);
                bool? dialogResult = popupReset.ShowDialog();
                ClearEffect(this);

                if (dialogResult == true)
                {
                    Close();
                }
            }
            catch
            {
                FancyBalloon balloon = new FancyBalloon();
                balloon.BalloonMessage = resource.Get(TextResource.SETTINGERR);
                tb.ShowCustomBalloon(balloon, PopupAnimation.Slide, 5000);
                Logger.Current.AppendText("Ошибка сохранения пользовательских данных");
            }
        }

        private void copyApp_Loaded(object sender, RoutedEventArgs e)
        {
            string copyRunApp = _xmlhelper.GetSettingValue("run_copy_app");

            switch (copyRunApp)
            {
                case "false":
                    copyApp.IsChecked = true;
                    break;

                case "true":
                    copyApp.IsChecked = false;
                    break;

                default:
                    break;
            }
        }

        private void changeLang_Loaded(object sender, RoutedEventArgs e)
        {
            string language = _xmlhelper.GetSettingValue("app_language");

            switch (language)
            {
                case "ptBR":
                    changeLang.SelectedIndex = 0;
                    
                    break;

                case "enUS":
                    changeLang.SelectedIndex = 1;
                    
                    break;

                default:
                    break;
            }
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ComboBoxItem comboBoxItem = e.OriginalSource as ComboBoxItem;
            if (comboBoxItem != null)
            {
                if (comboBoxItem.Content.ToString() == "Português(BR)")
                {
                    _xmlhelper.UpdateSettingValue("app_language", "ptBR");
                    _xmlhelper.UpdateSettingValue("client_lang", "pt");
                }
                else if (comboBoxItem.Content.ToString() == "English(Us)")
                {
                    _xmlhelper.UpdateSettingValue("app_language", "enUS");
                    _xmlhelper.UpdateSettingValue("client_lang", "en");
                }

            }
        }


        private void LoadData()
        {
            if (File.Exists(LocalConfiguration.Instance.Files.ConfDataFile))
            {
                textBoxLogin.Text = _xmlhelper.GetSettingValue("user_login");
                string getPass = EncDec.DeShifrovka(_xmlhelper.GetSettingValue("user_password"), "private_string");
                passwordBox.Password = getPass;

                location1.Text = _xmlhelper.GetSettingValue("realm1_client_location");
                Logger.Current.AppendText("Загрузка пользовательских данных");

                if (textBoxLogin.Text != string.Empty && passwordBox.Password != string.Empty)
                {
                    exitBtn.Visibility = Visibility.Visible;
                }
                else
                {
                    exitBtn.Visibility = Visibility.Hidden;
                }
            }

        }

        private void Translate()
        {

            ResourceProvider resource = ResourceProvider.Instance;

            saveSettingsButton.Content = resource.Get(TextResource.SAVEBTN);
            settingsLabelTooltip.Content = resource.Get(TextResource.SETTLABEL1);
            settingsLabelTooltip2.Text = resource.Get(TextResource.SETTLABEL2);
            closeButtonSettings.ToolTip = resource.Get(TextResource.TOOLCLOSE);
            SettingsLabel.Text = resource.Get(TextResource.SETHEADER);
            EnterLogin.Text = resource.Get(TextResource.ENTLOG);
            EnterPass.Text = resource.Get(TextResource.ENTPASS);
            tabMenu1.Text = resource.Get(TextResource.TABMENU1);
            tabMenu2.Text = resource.Get(TextResource.TABMENU2);
            tabMenu.Text = resource.Get(TextResource.TABMENU);

            labelGame.Text = resource.Get(TextResource.TABMENU2);

            string changeLoc = resource.Get(TextResource.CHANGELOC);
            client1Btn.Content = changeLoc;

            string entExe = resource.Get(TextResource.ENTWOWEXE);
            location1.Text = entExe;

            clearSetting.Content = resource.Get(TextResource.BTNCLEAR);
            exitBtn.Content = resource.Get(TextResource.EXITBTN);
            appLang.Text = resource.Get(TextResource.LANGUAGEMENU);
            labelGeneral.Text = resource.Get(TextResource.GENERALSETLABEL);
            copyApp.Content = resource.Get(TextResource.COPYAPP);
            confTextBlock.Text = resource.Get(TextResource.CONFTEXT);
            openGameSetBtn.Content = resource.Get(TextResource.OPENGAMECONF);
            Logger.Current.AppendText("Завершен метод перевода формы с настройками");
        }

        private void textBoxLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBoxLogin = (TextBox)sender;
            textBoxLogin.GotFocus -= textBoxLogin_GotFocus;
        }

        private void passwordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox password = (PasswordBox)sender;
            password.GotFocus -= passwordBox_GotFocus;
        }

        private void location1_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox location1 = (TextBox)sender;
            location1.GotFocus -= location1_GotFocus;
        }

        private void client1Btn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string foldername = dialog.SelectedPath;
                location1.Text = foldername;
            }
        }


        // BLUR EFFECTS
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
        // BLUR EFFECTS


        private void clearSetting_Click(object sender, RoutedEventArgs e)
        {
            var popup = new PopupDialog();
            popup.Owner = this;
            ApplyEffect(this);
            bool? dialogResult = popup.ShowDialog();
            ClearEffect(this);

            if (dialogResult == true)
            {
                try
                {
                    var popupReset = new PopupDialogReset();
                    popupReset.Owner = this;
                    ApplyEffect(this);
                    bool? dialogResultRestart = popupReset.ShowDialog();
                    ClearEffect(this);

                    if (dialogResultRestart == true)
                    {
                        Close();
                    }
                }
                catch
                {
                    Logger.Current.AppendText("Возникла ошибка при сохранении файла конфигурации");
                }

                Close();
            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password != string.Empty)
            {
                exitBtn.IsEnabled = true;
            }
            else
            {
                exitBtn.IsEnabled = false;
            }
        }

        private void openGameSetBtn_Click(object sender, RoutedEventArgs e)
        {
            ResourceProvider resource = ResourceProvider.Instance;
            try
            {
                    string configFile = Path.Combine(_xmlhelper.GetSettingValue("realm1_client_location"), "NtConfig.exe");

                    if (File.Exists(configFile))
                    {
                        var process = new Process();
                        process.StartInfo.FileName = configFile;
                        process.Start();
                    }
                    else
                    {
                        FancyBalloon balloon = new FancyBalloon();
                        balloon.BalloonMessage = string.Format(resource.Get(TextResource.EXENOTFOUND),
                                    configFile);
                        tb.ShowCustomBalloon(balloon, PopupAnimation.Slide, 5000);
                        Logger.Current.AppendText("NtConfig.exe не найден");
                    }

            }
            catch (Exception patchingErrorMain)
            {
                FancyBalloon balloon = new FancyBalloon();
                balloon.BalloonMessage = resource.Get(TextResource.ERRORSTARTINGGAME);
                tb.ShowCustomBalloon(balloon, PopupAnimation.Slide, 5000);
            }
        }






    }
}