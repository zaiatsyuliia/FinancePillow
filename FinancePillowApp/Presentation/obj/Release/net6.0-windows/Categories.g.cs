﻿#pragma checksum "..\..\..\Categories.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "340C9606BB50C3249462B27FB321682FF3610243"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Presentation;
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


namespace Presentation {
    
    
    /// <summary>
    /// Categories
    /// </summary>
    public partial class Categories : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\..\Categories.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Supermarkets;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Categories.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Entertainment;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Categories.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Restaurants;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Categories.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Fashion;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Categories.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border EShopping;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Categories.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Investments;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Categories.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Home;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\Categories.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Travel;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Categories.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Transport;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Categories.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Other;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\Categories.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel menuCanvas;
        
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
            System.Uri resourceLocater = new System.Uri("/Presentation;component/categories.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Categories.xaml"
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
            
            #line 8 "..\..\..\Categories.xaml"
            ((Presentation.Categories)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 43 "..\..\..\Categories.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ToggleMenuVisibility);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Supermarkets = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.Entertainment = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.Restaurants = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.Fashion = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.EShopping = ((System.Windows.Controls.Border)(target));
            return;
            case 8:
            this.Investments = ((System.Windows.Controls.Border)(target));
            return;
            case 9:
            this.Home = ((System.Windows.Controls.Border)(target));
            return;
            case 10:
            this.Travel = ((System.Windows.Controls.Border)(target));
            return;
            case 11:
            this.Transport = ((System.Windows.Controls.Border)(target));
            return;
            case 12:
            this.Other = ((System.Windows.Controls.Border)(target));
            return;
            case 13:
            this.menuCanvas = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

