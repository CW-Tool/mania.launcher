﻿#pragma checksum "..\..\..\Dialogs\PopupDialogReset.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8921773BAFF60C1765D5886746F0515E"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using Samples.libs;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Mania.Launcher.Dialogs {
    
    
    /// <summary>
    /// PopupDialogReset
    /// </summary>
    public partial class PopupDialogReset : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\Dialogs\PopupDialogReset.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Samples.libs.TaskbarIcon tb;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Dialogs\PopupDialogReset.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closeBtn;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Dialogs\PopupDialogReset.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button restartBtn;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Dialogs\PopupDialogReset.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button restartLaterBtn;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Dialogs\PopupDialogReset.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock popupMessage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MapleStory Mania Launcher;component/dialogs/popupdialogreset.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Dialogs\PopupDialogReset.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 12 "..\..\..\Dialogs\PopupDialogReset.xaml"
            ((Mania.Launcher.Dialogs.PopupDialogReset)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tb = ((Samples.libs.TaskbarIcon)(target));
            return;
            case 3:
            this.closeBtn = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\Dialogs\PopupDialogReset.xaml"
            this.closeBtn.Click += new System.Windows.RoutedEventHandler(this.closeBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.restartBtn = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\Dialogs\PopupDialogReset.xaml"
            this.restartBtn.Click += new System.Windows.RoutedEventHandler(this.restartBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.restartLaterBtn = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\Dialogs\PopupDialogReset.xaml"
            this.restartLaterBtn.Click += new System.Windows.RoutedEventHandler(this.restartLaterBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.popupMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

