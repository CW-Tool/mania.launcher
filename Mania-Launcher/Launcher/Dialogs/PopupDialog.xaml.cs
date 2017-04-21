using Samples;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using Mania.Language;
using Mania.Launcher.Config;
using Mania.Launcher.Utils;

namespace Mania.Launcher.Dialogs
{
    /// <summary>
    /// Interaction logic for PopupDialog.xaml
    /// </summary>
    public partial class PopupDialog : Window
    {
        private readonly XmlHelper _xmlhelper;

        public PopupDialog()
        {
            InitializeComponent();
            _xmlhelper = new XmlHelper();
            Translate();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            ResourceProvider resource = ResourceProvider.Instance;
            try
            {

                if (File.Exists(LocalConfiguration.Instance.Files.ConfDataFile))
                {
                    File.Delete(LocalConfiguration.Instance.Files.ConfDataFile);
                    Logger.Current.AppendText("Сброс настроек файла конфигурации");
                }

                FancyBalloon balloon = new FancyBalloon();

                balloon.BalloonMessage = resource.Get(TextResource.RESETMSG);

                tb.ShowCustomBalloon(balloon, PopupAnimation.Slide, 5000);

                DialogResult = true;
            }
            catch (Exception ex)
            {

                FancyBalloon balloon = new FancyBalloon();

                balloon.BalloonMessage = resource.Get(TextResource.RESETMSGERR);

                tb.ShowCustomBalloon(balloon, PopupAnimation.Slide, 5000);

                Logger.Current.AppendText("Не удалось сбросить настройки");
                Logger.Current.AppendException(ex);
            }
        }


        private void Translate()
        {
            ResourceProvider resource = ResourceProvider.Instance;

            deleteBtn.Content = resource.Get(TextResource.RESETSETT);
            cancelBtn.Content = resource.Get(TextResource.CANCELBTN);
            closeBtn.ToolTip = resource.Get(TextResource.TOOLCLOSE);
            popupMessage.Text = resource.Get(TextResource.POPUPMSG);


        }
    }
}
