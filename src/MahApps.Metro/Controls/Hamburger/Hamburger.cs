// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using ControlzEx;

namespace MahApps.Metro.Controls
{
    /// <summary>
    /// The Hamburger is based on a <see cref="SplitView"/> control. By default it contains a HamburgerButton and a ListView to display menu items.
    /// </summary>
    [TemplatePart(Name = "PART_BurgerButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_ButtonsList", Type = typeof(ListBox))]
    [TemplatePart(Name = "PART_OptionsList", Type = typeof(ListBox))]
    public partial class Hamburger: Selector
    {
        private Button? hamburgerButton;
        private ListBox? optionsListView;
        private readonly PropertyChangeNotifier actualWidthPropertyChangeNotifier;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hamburger"/> class.
        /// </summary>
        public Hamburger()
        {
            this.DefaultStyleKey = typeof(Hamburger);

            this.actualWidthPropertyChangeNotifier = new PropertyChangeNotifier(this, ActualWidthProperty);
            this.actualWidthPropertyChangeNotifier.ValueChanged += (s, e) => this.CoerceValue(OpenPaneLengthProperty);
        }

        /// <summary>
        /// Override default OnApplyTemplate to capture children controls
        /// </summary>
        public override void OnApplyTemplate()
        {
            if (this.hamburgerButton != null)
            {
                this.hamburgerButton.Click -= this.OnHamburgerButtonClick;
            }

            if (this.optionsListView != null)
            {
                this.optionsListView.SelectionChanged -= this.OptionsListView_SelectionChanged;
            }

            this.hamburgerButton = this.GetTemplateChild("PART_BurgerButton") as Button;
            //this.optionsListView = this.GetTemplateChild("PART_ButtonsList") as ListBox;
            this.optionsListView = this.GetTemplateChild("PART_OptionsList") as ListBox;

            if (this.hamburgerButton != null)
            {
                this.hamburgerButton.Click += this.OnHamburgerButtonClick;
            }

            if (this.optionsListView != null)
            {
                this.optionsListView.SelectionChanged += this.OptionsListView_SelectionChanged;
            }

            this.ChangeItemFocusVisualStyle();

            base.OnApplyTemplate();
        }

        //private void HamburgerMenu_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if (this.GetValue(ContentProperty) != null)
        //    {
        //        return;
        //    }

        //    var item = this.buttonsListView?.SelectedItem;
        //    var canRaiseItemEvents = this.CanRaiseItemEvents(item);
        //    if (canRaiseItemEvents && this.RaiseItemEvents(item))
        //    {
        //        return;
        //    }

        //    var optionItem = this.optionsListView?.SelectedItem;
        //    var canRaiseOptionsItemEvents = this.CanRaiseOptionsItemEvents(optionItem);
        //    if (canRaiseOptionsItemEvents && this.RaiseOptionsItemEvents(optionItem))
        //    {
        //        return;
        //    }

        //    if (canRaiseItemEvents || canRaiseOptionsItemEvents)
        //    {
        //        var selectedItem = item ?? optionItem;
        //        if (selectedItem != null)
        //        {
        //            this.SetCurrentValue(ContentProperty, selectedItem);
        //        }
        //    }
        //}
    }
}