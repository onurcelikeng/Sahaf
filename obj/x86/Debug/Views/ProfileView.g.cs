﻿#pragma checksum "C:\Users\onurcelikeng\Documents\Visual Studio 2015\Projects\Sahaf\Sahaf\Views\ProfileView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1BF5AB3F1720CB0965118BA8CD08D81F"
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
                    #line 139 "..\..\..\Views\ProfileView.xaml"
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
                    #line 220 "..\..\..\Views\ProfileView.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.list3).SelectionChanged += this.list3_SelectionChanged;
                    #line default
                }
                break;
            case 6:
                {
                    this.list1 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 143 "..\..\..\Views\ProfileView.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.list1).SelectionChanged += this.list1_SelectionChanged;
                    #line default
                }
                break;
            case 7:
                {
                    this.panel3 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 109 "..\..\..\Views\ProfileView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)this.panel3).Tapped += this.oldAdvertCount_Tapped;
                    #line default
                }
                break;
            case 8:
                {
                    this.oldAdvertCount = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 117 "..\..\..\Views\ProfileView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)this.oldAdvertCount).Tapped += this.oldAdvertCount_Tapped;
                    #line default
                }
                break;
            case 9:
                {
                    this.OfflineAdvert = (global::Windows.UI.Xaml.Documents.Run)(target);
                }
                break;
            case 10:
                {
                    this.panel1 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 81 "..\..\..\Views\ProfileView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)this.panel1).Tapped += this.newAdverButton_Tapped;
                    #line default
                }
                break;
            case 11:
                {
                    this.newAdverButton = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 89 "..\..\..\Views\ProfileView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)this.newAdverButton).Tapped += this.newAdverButton_Tapped;
                    #line default
                }
                break;
            case 12:
                {
                    this.OnlineAdvert = (global::Windows.UI.Xaml.Documents.Run)(target);
                }
                break;
            case 13:
                {
                    this.logOutButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 51 "..\..\..\Views\ProfileView.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.logOutButton).Click += this.logOutButton_Click;
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

