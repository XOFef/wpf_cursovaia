﻿#pragma checksum "..\..\TestBildTree.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CB2E7126EA5B9113ACADB52B4A0E0D8146878D30E0FD648005D9248868FF7205"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Wpf;


namespace Wpf {
    
    
    /// <summary>
    /// TestBildTree
    /// </summary>
    public partial class TestBildTree : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\TestBildTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel UpPannel;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\TestBildTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Result;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\TestBildTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ScoreLow;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\TestBildTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ScoreHight;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\TestBildTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Title;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\TestBildTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox myCheckBoxTwoResult;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\TestBildTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxResult;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\TestBildTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox myCheckBoxResult;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\TestBildTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonImageResult;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\TestBildTree.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imageControlResult;
        
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
            System.Uri resourceLocater = new System.Uri("/Wpf;component/testbildtree.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TestBildTree.xaml"
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
            this.UpPannel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.Result = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.ScoreLow = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ScoreHight = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Title = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.myCheckBoxTwoResult = ((System.Windows.Controls.CheckBox)(target));
            
            #line 40 "..\..\TestBildTree.xaml"
            this.myCheckBoxTwoResult.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked_Two_Result);
            
            #line default
            #line hidden
            
            #line 40 "..\..\TestBildTree.xaml"
            this.myCheckBoxTwoResult.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked_Two_Result);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TextBoxResult = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.myCheckBoxResult = ((System.Windows.Controls.CheckBox)(target));
            
            #line 46 "..\..\TestBildTree.xaml"
            this.myCheckBoxResult.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked_Result);
            
            #line default
            #line hidden
            
            #line 46 "..\..\TestBildTree.xaml"
            this.myCheckBoxResult.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked_Result);
            
            #line default
            #line hidden
            return;
            case 9:
            this.buttonImageResult = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\TestBildTree.xaml"
            this.buttonImageResult.Click += new System.Windows.RoutedEventHandler(this.Button_Click_Result);
            
            #line default
            #line hidden
            return;
            case 10:
            this.imageControlResult = ((System.Windows.Controls.Image)(target));
            return;
            case 11:
            
            #line 53 "..\..\TestBildTree.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_NewResult);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 59 "..\..\TestBildTree.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Delete);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 60 "..\..\TestBildTree.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Back);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 61 "..\..\TestBildTree.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Ready);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
