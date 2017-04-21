using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Media.Animation;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Mania.Launcher;
using Mania.Launcher.Utils;
using System.Windows.Media.Effects;
using Mania.Launcher.Config;
using System.IO;
using System.Xml;
using Mania.Language;
using Constants;
using System.Diagnostics;
using Mania.Launcher.Logic.Updating;
using System.Windows.Forms;
using Mania.Launcher.Logic;
using Mania.Launcher.Properties;
using System.Net;
using System.Threading.Tasks;
using WowLauncher.Utils;
using Mania.Utils;
using Mania.Launcher.Dialogs;

namespace Mania.Launcher.Controls
{
    public partial class WelcomeBlock : System.Windows.Controls.UserControl
    {
        private readonly XmlHelper _xmlhelper;
        private readonly WebClient _web;
        private readonly WebClientFactory _webClientFactory;

        public WelcomeBlock()
        {
            InitializeComponent();
            _xmlhelper = new XmlHelper();
            Translate();
            DataContext = this;       

        }

        public void ShowBlock()
        {
            LayoutRoot.Visibility = Visibility.Visible;
        }

        public void HideBlock()
        {
            LayoutRoot.Visibility = Visibility.Hidden;
        }


        private void settingsBtn_Click(object sender, RoutedEventArgs e)
        {
            var settings = new SettingsWindow();
            settings.Settings.SelectedIndex = 2;
            settings.ShowDialog();  
        }

        private void Translate()
        {
            ResourceProvider resource = ResourceProvider.Instance;

            welcomeBlock.Text = resource.Get(TextResource.WELCBLOCK);
            welcomeDescript.Text = resource.Get(TextResource.WELCDESCR);
            welcomeBtn.Content = resource.Get(TextResource.WELCBTN);
            settingsBtn.Content = resource.Get(TextResource.WELCBTNSET);
            change.Content = resource.Get(TextResource.CHANGEGAMELANG);
        }

        private async void welcomeBtn_Click(object sender, RoutedEventArgs e)
        {
   
            if (changeLang.SelectedIndex == 1)
            {
                FolderBrowserDialog updPathRu = new FolderBrowserDialog();
                updPathRu.ShowDialog();
                string rootDirectory = updPathRu.SelectedPath;
                _xmlhelper.UpdateSettingValue("realm1_client_location", rootDirectory);
                _xmlhelper.UpdateSettingValue("client_lang", "pt");

                try
                {
                    var popupReset = new PopupDialogReset();
                    bool? dialogResultRestart = popupReset.ShowDialog();

                    if (dialogResultRestart == true)
                    {
                        System.Windows.Forms.Application.Restart();
                        System.Windows.Application.Current.Shutdown();
                    }
                }
                catch
                {
                    Logger.Current.AppendText("Возникла ошибка при обновлении файла конфигурации");
                }

            }

            else if (changeLang.SelectedIndex == 2)
            {
                FolderBrowserDialog updPathEn = new FolderBrowserDialog();
                updPathEn.ShowDialog();
                string rootDirectory = updPathEn.SelectedPath;
                _xmlhelper.UpdateSettingValue("realm1_client_location", rootDirectory);
                _xmlhelper.UpdateSettingValue("client_lang", "en");

                try
                {
                    var popupReset = new PopupDialogReset();
                    bool? dialogResultRestart = popupReset.ShowDialog();

                    if (dialogResultRestart == true)
                    {
                        System.Windows.Forms.Application.Restart();
                        System.Windows.Application.Current.Shutdown();
                    }
                }
                catch
                {
                    Logger.Current.AppendText("Возникла ошибка при обновлении файла конфигурации");
                }
            }

        }


        private void changeLang_Loaded(object sender, RoutedEventArgs e)
        {
            changeLang.SelectedIndex = 0;
        }

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

        private void changeLang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}