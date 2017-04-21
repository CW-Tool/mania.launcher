using Samples;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class PopupDialogUpdate : Window
    {
        private readonly XmlHelper _xmlhelper;

        public PopupDialogUpdate()
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

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

        }

        private void Translate()
        {
            ResourceProvider resource = ResourceProvider.Instance;
            closeBtn.ToolTip = Mania.Language.ptBR.TOOLCLOSE; resource.Get(TextResource.TOOLCLOSE);

        }
    }
}
