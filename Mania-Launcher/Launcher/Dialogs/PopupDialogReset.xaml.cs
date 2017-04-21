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
    public partial class PopupDialogReset : Window
    {
        private readonly XmlHelper _xmlhelper;

        public PopupDialogReset()
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

        private void restartLaterBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void restartBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();
        }

        private void Translate()
        {
            ResourceProvider resource = ResourceProvider.Instance;

            restartBtn.Content = resource.Get(TextResource.RESTARTBTN);
            restartLaterBtn.Content = resource.Get(TextResource.RESTARTLATERBTN);
            closeBtn.ToolTip = resource.Get(TextResource.TOOLCLOSE);
            popupMessage.Text = resource.Get(TextResource.POPUPMSGRESTART);

        }
    }
}
