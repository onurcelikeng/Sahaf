﻿#pragma checksum "C:\Users\onurcelikeng\Documents\Visual Studio 2015\Projects\Sahaf\Sahaf\Views\ProfileView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E2EEDA6F256517CAFC02EA67E57EE367"
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
    partial class ProfileView : 
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
                    this.progress = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                }
                break;
            case 2:
                {
                    this.pivot = (global::Windows.UI.Xaml.Controls.Pivot)(target);
                    #line 114 "..\..\..\Views\ProfileView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Pivot)this.pivot).SelectionChanged += this.pivot_SelectionChanged;
                    #line default
                }
                break;
            case 3:
                {
                    this.pivotItem1 = (global::Windows.UI.Xaml.Controls.PivotItem)(target);
                }
                break;
            case 4:
                {
                    this.pivotItem3 = (global::Windows.UI.Xaml.Controls.PivotItem)(target);
                }
                break;
            case 5:
                {
                    this.list3 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 195 "..\..\..\Views\ProfileView.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.list3).SelectionChanged += this.list3_SelectionChanged;
                    #line default
                }
                break;
            case 6:
                {
                    this.list1 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 118 "..\..\..\Views\ProfileView.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.list1).SelectionChanged += this.list1_SelectionChanged;
                    #line default
                }
                break;
            case 7:
                {
                    this.offlineAdvertButton = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 84 "..\..\..\Views\ProfileView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)this.offlineAdvertButton).Tapped += this.offlineAdvertButton_Tapped;
                    #line default
                }
                break;
            case 8:
                {
                    this.panel2 = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                }
                break;
            case 9:
                {
                    this.onlineAdvertButton = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 66 "..\..\..\Views\ProfileView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)this.onlineAdvertButton).Tapped += this.onlineAdvertButton_Tapped;
                    #line default
                }
                break;
            case 10:
                {
                    this.panel1 = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                }
                break;
            case 11:
                {
                    this.reportButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 39 "..\..\..\Views\ProfileView.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.reportButton).Click += this.logOutButton_Click;
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

