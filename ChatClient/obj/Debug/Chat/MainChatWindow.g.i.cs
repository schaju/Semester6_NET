﻿#pragma checksum "..\..\..\Chat\MainChatWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2F813C0981FA188DD41F523F1796E0B618C344C2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ChatClient.Chat.Control;
using Model;
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


namespace ChatClient.Chat {
    
    
    /// <summary>
    /// MainChatWindow
    /// </summary>
    public partial class MainChatWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Chat\MainChatWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ChatClient.Chat.MainChatWindow MainChatWindowUI;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Chat\MainChatWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewChats;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Chat\MainChatWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewContactBtn;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Chat\MainChatWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxMessage;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Chat\MainChatWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView MainContent;
        
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
            System.Uri resourceLocater = new System.Uri("/ChatClient;component/chat/mainchatwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Chat\MainChatWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.MainChatWindowUI = ((ChatClient.Chat.MainChatWindow)(target));
            
            #line 9 "..\..\..\Chat\MainChatWindow.xaml"
            this.MainChatWindowUI.Closed += new System.EventHandler(this.MainChatWindow_OnClosed);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 17 "..\..\..\Chat\MainChatWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Edit_Profile);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 18 "..\..\..\Chat\MainChatWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Logout_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ListViewChats = ((System.Windows.Controls.ListView)(target));
            
            #line 27 "..\..\..\Chat\MainChatWindow.xaml"
            this.ListViewChats.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListViewChats_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddNewContactBtn = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Chat\MainChatWindow.xaml"
            this.AddNewContactBtn.Click += new System.Windows.RoutedEventHandler(this.NewContactBtn);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TextBoxMessage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 54 "..\..\..\Chat\MainChatWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Send_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MainContent = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

