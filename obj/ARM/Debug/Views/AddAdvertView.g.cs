﻿#pragma checksum "C:\Users\onurcelikeng\Documents\Visual Studio 2015\Projects\Sahaf\Sahaf\Views\AddAdvertView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D4C7CBC9A22719D6D090443709DE6584"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sahaf.Views
{
    partial class AddAdvertView : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.book = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 2:
                {
                    this.advertButton = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 139 "..\..\..\Views\AddAdvertView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)this.advertButton).Tapped += this.advertButton_Tapped;
                    #line default
                }
                break;
            case 3:
                {
                    this.city = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.price = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.advertName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6:
                {
                    this.deleteButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 47 "..\..\..\Views\AddAdvertView.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.deleteButton).Click += this.deleteButton_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

