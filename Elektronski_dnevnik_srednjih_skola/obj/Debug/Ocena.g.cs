﻿#pragma checksum "..\..\Ocena.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B78C32E8C5392A37EB17A2DF27135714839D70F27780744B3B102A6FEBD04EB3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Elektronski_dnevnik_srednjih_skola;
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


namespace Elektronski_dnevnik_srednjih_skola {
    
    
    /// <summary>
    /// Ocena
    /// </summary>
    public partial class Ocena : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Ocena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUnesi;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Ocena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzmeni;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Ocena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzbrisi;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Ocena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNazad;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Ocena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbRadnik;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Ocena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbPredmet;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Ocena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid tabela;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Ocena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtOcenaID;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Ocena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slVrednost;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Ocena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbUcenik;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Ocena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtVrednost;
        
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
            System.Uri resourceLocater = new System.Uri("/Elektronski dnevnik srednjih skola;component/ocena.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Ocena.xaml"
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
            this.btnUnesi = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\Ocena.xaml"
            this.btnUnesi.Click += new System.Windows.RoutedEventHandler(this.btnUnesi_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnIzmeni = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\Ocena.xaml"
            this.btnIzmeni.Click += new System.Windows.RoutedEventHandler(this.btnIzmeni_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnIzbrisi = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\Ocena.xaml"
            this.btnIzbrisi.Click += new System.Windows.RoutedEventHandler(this.btnIzbrisi_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnNazad = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Ocena.xaml"
            this.btnNazad.Click += new System.Windows.RoutedEventHandler(this.btnNazad_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmbRadnik = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.cmbPredmet = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.tabela = ((System.Windows.Controls.DataGrid)(target));
            
            #line 23 "..\..\Ocena.xaml"
            this.tabela.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.tabela_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtOcenaID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.slVrednost = ((System.Windows.Controls.Slider)(target));
            
            #line 34 "..\..\Ocena.xaml"
            this.slVrednost.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.slVrednost_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.cmbUcenik = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.txtVrednost = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

