﻿#pragma checksum "..\..\SalesModule.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CD0C031EEB62377758B09A9C785EA50334BD6C43E6E10E8D04A50CCBE18A7FC4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FarmersMarket_GUI;
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


namespace FarmersMarket_GUI {
    
    
    /// <summary>
    /// SalesModule
    /// </summary>
    public partial class SalesModule : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\SalesModule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_pName;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\SalesModule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox search;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\SalesModule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button calculateBtn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\SalesModule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buyBtn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\SalesModule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label showTotal;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\SalesModule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid salesDataGrid;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\SalesModule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _return;
        
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
            System.Uri resourceLocater = new System.Uri("/FarmersMarket_GUI;component/salesmodule.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SalesModule.xaml"
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
            this.label_pName = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.search = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.calculateBtn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\SalesModule.xaml"
            this.calculateBtn.Click += new System.Windows.RoutedEventHandler(this.CalculateBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buyBtn = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\SalesModule.xaml"
            this.buyBtn.Click += new System.Windows.RoutedEventHandler(this.BuyBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.showTotal = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.salesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this._return = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\SalesModule.xaml"
            this._return.Click += new System.Windows.RoutedEventHandler(this._return_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

