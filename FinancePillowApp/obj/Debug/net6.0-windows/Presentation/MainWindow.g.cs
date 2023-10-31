﻿#pragma checksum "..\..\..\..\Presentation\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49418FEE72111D9BF1AABDA0A3D9B46F2BB6B56D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FinancePillowApp;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace FinancePillowApp {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\Presentation\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Incomes;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Presentation\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock incomeTextBlock;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Presentation\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Expences;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Presentation\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid overlayGrid;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Presentation\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border customPanel;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Presentation\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox amountTextBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Presentation\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu menuCanvas;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FinancePillowApp;component/presentation/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Presentation\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\..\Presentation\MainWindow.xaml"
            ((FinancePillowApp.MainWindow)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 12 "..\..\..\..\Presentation\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ToggleMenuVisibility);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Incomes = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            
            #line 18 "..\..\..\..\Presentation\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FirstButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.incomeTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.Expences = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.overlayGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.customPanel = ((System.Windows.Controls.Border)(target));
            return;
            case 9:
            this.amountTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 36 "..\..\..\..\Presentation\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddAmount_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.menuCanvas = ((System.Windows.Controls.Menu)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
