// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using JetBrains.Annotations;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace MetroDemo.ExampleViews
{
    public sealed partial class HamburgerExample : UserControl
    {
        public HamburgerExample()
        {
            this.InitializeComponent();
        }

        //[UsedImplicitly]
        //// Another option to handle the menu item click
        //private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e)
        //{
        //    // instead using binding Content="{Binding RelativeSource={RelativeSource Self}, Mode=OneWay, Path=SelectedItem}"
        //    // we can do this

        //    if (e.ClickedItem is ListBoxItem item)
        //        this.HamburgerMenuControl.Content = item.Tag;

        //    // close the menu if a item was selected
        //    if (this.HamburgerMenuControl.IsPaneOpen)
        //    {
        //        this.HamburgerMenuControl.IsPaneOpen = false;
        //    }
        //}

        [UsedImplicitly]
        // Another option to handle the options menu item click
        private async void HamburgerMenuControl_OnOptionsItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (ListBoxItem)e.ClickedItem!;
            await this.TryFindParent<MetroWindow>()!.ShowMessageAsync("", $"You clicked on {menuItem} button");
        }

        //private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        //{
        //    //this.HamburgerMenuControl.Content = e.InvokedItem;

        //    if (!e.IsItemOptions && this.HamburgerMenuControl.IsPaneOpen)
        //    {
        //        // close the menu if a item was selected
        //        this.HamburgerMenuControl.IsPaneOpen = false;
        //    }
        //}

        private void HamburgerMenuControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if( this.HamburgerMenuControl.SelectedItem is not null)
            this.HamburgerMenuControl.Content = ((ListBoxItem)this.HamburgerMenuControl.SelectedItem).Tag;
        }
    }
}