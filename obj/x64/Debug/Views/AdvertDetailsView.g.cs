﻿#pragma checksum "C:\Users\onurcelikeng\Documents\Visual Studio 2015\Projects\Sahaf\Sahaf\Views\AdvertDetailsView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1EFF93CF1BC04418454E634A30B63062"
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
    partial class AdvertDetailsView : 
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
                    this.requestButton = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 212 "..\..\..\Views\AdvertDetailsView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)this.requestButton).Tapped += this.requestButton_Tapped;
                    #line default
                }
                break;
            case 2:
                {
                    this.deleteButton = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 220 "..\..\..\Views\AdvertDetailsView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)this.deleteButton).Tapped += this.deleteButton_Tapped;
                    #line default
                }
                break;
            case 3:
                {
                    this.personButton = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 113 "..\..\..\Views\AdvertDetailsView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)this.personButton).Tapped += this.personButton_Tapped;
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

