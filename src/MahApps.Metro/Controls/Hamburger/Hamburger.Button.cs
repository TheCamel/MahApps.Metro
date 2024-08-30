// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;

namespace MahApps.Metro.Controls
{
    [StyleTypedProperty(Property = nameof(HamburgerButtonStyle), StyleTargetType = typeof(Button))]
    public partial class Hamburger
    {
        ///// <summary>Identifies the <see cref="HamburgerWidth"/> dependency property.</summary>
        //public static readonly DependencyProperty HamburgerWidthProperty
        //    = DependencyProperty.Register(nameof(HamburgerWidth),
        //                                  typeof(double),
        //                                  typeof(Hamburger),
        //                                  new PropertyMetadata(48.0));

        ///// <summary>
        ///// Gets or sets HamburgerMenu button's <see cref="FrameworkElement.Width"/>.
        ///// </summary>
        //public double HamburgerWidth
        //{
        //    get => (double)this.GetValue(HamburgerWidthProperty);
        //    set => this.SetValue(HamburgerWidthProperty, value);
        //}

        /// <summary>Identifies the <see cref="HamburgerHeight"/> dependency property.</summary>
        public static readonly DependencyProperty HamburgerHeightProperty
            = DependencyProperty.Register(nameof(HamburgerHeight),
                                          typeof(double),
                                          typeof(Hamburger),
                                          new PropertyMetadata(48.0));

        /// <summary>
        /// Gets or sets the <see cref="FrameworkElement.Height"/> for the HamburgerMenu button.
        /// </summary>
        public double HamburgerHeight
        {
            get => (double)this.GetValue(HamburgerHeightProperty);
            set => this.SetValue(HamburgerHeightProperty, value);
        }

        /// <summary>Identifies the <see cref="HamburgerMargin"/> dependency property.</summary>
        public static readonly DependencyProperty HamburgerMarginProperty
            = DependencyProperty.Register(nameof(HamburgerMargin),
                                          typeof(Thickness),
                                          typeof(Hamburger),
                                          new PropertyMetadata(new Thickness()));

        /// <summary>
        /// Gets or sets the margin for the HamburgerMenu button.
        /// </summary>
        public Thickness HamburgerMargin
        {
            get => (Thickness)this.GetValue(HamburgerMarginProperty);
            set => this.SetValue(HamburgerMarginProperty, value);
        }

        /// <summary>Identifies the <see cref="HamburgerVisibility"/> dependency property.</summary>
        public static readonly DependencyProperty HamburgerVisibilityProperty
            = DependencyProperty.Register(nameof(HamburgerVisibility),
                                          typeof(Visibility),
                                          typeof(Hamburger),
                                          new PropertyMetadata(Visibility.Visible));

        /// <summary>
        /// Gets or sets the <see cref="UIElement.Visibility"/> for the HamburgerMenu button.
        /// </summary>
        public Visibility HamburgerVisibility
        {
            get => (Visibility)this.GetValue(HamburgerVisibilityProperty);
            set => this.SetValue(HamburgerVisibilityProperty, value);
        }

        /// <summary>Identifies the <see cref="HamburgerButtonStyle"/> dependency property.</summary>
        public static readonly DependencyProperty HamburgerButtonStyleProperty
            = DependencyProperty.Register(nameof(HamburgerButtonStyle),
                                          typeof(Style),
                                          typeof(Hamburger),
                                          new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the <see cref="FrameworkElement.Style"/> for the HamburgerMenu button.
        /// </summary>
        public Style? HamburgerButtonStyle
        {
            get => (Style?)this.GetValue(HamburgerButtonStyleProperty);
            set => this.SetValue(HamburgerButtonStyleProperty, value);
        }

        /// <summary>Identifies the <see cref="HamburgerButtonTemplate"/> dependency property.</summary>
        public static readonly DependencyProperty HamburgerButtonTemplateProperty
            = DependencyProperty.Register(nameof(HamburgerButtonTemplate),
                                          typeof(DataTemplate),
                                          typeof(Hamburger),
                                          new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the <see cref="ContentControl.ContentTemplate"/> for the HamburgerMenu button.
        /// </summary>
        public DataTemplate? HamburgerButtonTemplate
        {
            get => (DataTemplate?)this.GetValue(HamburgerButtonTemplateProperty);
            set => this.SetValue(HamburgerButtonTemplateProperty, value);
        }

        /// <summary>Identifies the <see cref="HamburgerButtonName"/> dependency property.</summary>
        public static readonly DependencyProperty HamburgerButtonNameProperty
            = DependencyProperty.Register(nameof(HamburgerButtonName),
                                          typeof(string),
                                          typeof(Hamburger),
                                          new UIPropertyMetadata(string.Empty),
                                          new ValidateValueCallback(IsNotNull));

        /// <summary>
        /// Gets or sets the<see cref= "AutomationProperties.NameProperty" /> for the HamburgerMenu button.
        /// </summary>
        public string HamburgerButtonName
        {
            get => (string)this.GetValue(HamburgerButtonNameProperty);
            set => this.SetValue(HamburgerButtonNameProperty, value);
        }

        /// <summary>Identifies the <see cref="HamburgerButtonHelpText"/> dependency property.</summary>
        public static readonly DependencyProperty HamburgerButtonHelpTextProperty
            = DependencyProperty.Register(nameof(HamburgerButtonHelpText),
                                          typeof(string),
                                          typeof(Hamburger),
                                          new UIPropertyMetadata(string.Empty),
                                          new ValidateValueCallback(IsNotNull));

        /// <summary>
        /// Gets or sets the <see cref="AutomationProperties.HelpTextProperty"/> for the HamburgerMenu button.
        /// </summary>
        public string HamburgerButtonHelpText
        {
            get => (string)this.GetValue(HamburgerButtonHelpTextProperty);
            set => this.SetValue(HamburgerButtonHelpTextProperty, value);
        }

        /// <summary>Identifies the <see cref="HamburgerMenuHeaderTemplate"/> dependency property.</summary>
        public static readonly DependencyProperty HamburgerMenuHeaderTemplateProperty
            = DependencyProperty.Register(nameof(HamburgerMenuHeaderTemplate),
                                          typeof(DataTemplate),
                                          typeof(Hamburger),
                                          new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the <see cref="ContentControl.ContentTemplate"/> for the HamburgerMenu pane header.
        /// </summary>
        public DataTemplate? HamburgerMenuHeaderTemplate
        {
            get => (DataTemplate?)this.GetValue(HamburgerMenuHeaderTemplateProperty);
            set => this.SetValue(HamburgerMenuHeaderTemplateProperty, value);
        }

        private static bool IsNotNull(object? value)
        {
            return value != null;
        }

        /// <summary>Identifies the <see cref="HamburgerButtonClick"/> routed event.</summary>
        public static readonly RoutedEvent HamburgerButtonClickEvent
            = EventManager.RegisterRoutedEvent(nameof(HamburgerButtonClick),
                                               RoutingStrategy.Direct,
                                               typeof(RoutedEventHandler),
                                               typeof(Hamburger));

        /// <summary>
        /// Event raised when the hamburger button is clicked
        /// </summary>
        public event RoutedEventHandler HamburgerButtonClick
        {
            add => this.AddHandler(HamburgerButtonClickEvent, value);
            remove => this.RemoveHandler(HamburgerButtonClickEvent, value);
        }

        private void OnHamburgerButtonClick(object sender, RoutedEventArgs e)
        {
            var args = new RoutedEventArgs(HamburgerButtonClickEvent, sender);
            this.RaiseEvent(args);

            if (!args.Handled)
            {
                this.IsPaneOpen = !this.IsPaneOpen;
            }
        }
    }
}