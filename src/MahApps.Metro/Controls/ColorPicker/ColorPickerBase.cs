﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
    [DefaultEvent("SelectedColorChanged")]
    public class ColorPickerBase : Control
    {
        protected bool ColorIsUpdating;
        protected bool UpdateHsvValues = true;

        /// <summary>Identifies the <see cref="SelectedColor"/> dependency property.</summary>
        public static readonly DependencyProperty SelectedColorProperty
            = DependencyProperty.Register(nameof(SelectedColor),
                                          typeof(Color?),
                                          typeof(ColorPickerBase),
                                          new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedColorPropertyChanged));

        private static void OnSelectedColorPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is ColorPickerBase colorPicker)
            {
                colorPicker.OnSelectedColorChanged(e.OldValue as Color?, e.NewValue as Color?);
            }
        }

        /// <summary>
        /// Gets or Sets the selected <see cref="Color"/>
        /// </summary>
        public Color? SelectedColor
        {
            get => (Color?)this.GetValue(SelectedColorProperty);
            set => this.SetValue(SelectedColorProperty, value);
        }

        /// <summary>Identifies the <see cref="DefaultColor"/> dependency property.</summary>
        public static readonly DependencyProperty DefaultColorProperty
            = DependencyProperty.Register(nameof(DefaultColor),
                                          typeof(Color?),
                                          typeof(ColorPickerBase),
                                          new FrameworkPropertyMetadata(null, OnSelectedColorPropertyChanged));

        /// <summary>
        /// Gets or Sets the selected <see cref="Color"/>
        /// </summary>
        public Color? DefaultColor
        {
            get => (Color?)this.GetValue(DefaultColorProperty);
            set => this.SetValue(DefaultColorProperty, value);
        }

        private static readonly DependencyPropertyKey SelectedHSVColorPropertyKey
            = DependencyProperty.RegisterReadOnly(nameof(SelectedHSVColor),
                                                  typeof(HSVColor),
                                                  typeof(ColorPickerBase),
                                                  new PropertyMetadata(new HSVColor(Colors.Black)));

        /// <summary>Identifies the <see cref="SelectedHSVColor"/> dependency property.</summary>
        public static readonly DependencyProperty SelectedHSVColorProperty = SelectedHSVColorPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the <see cref="SelectedColor"/> as <see cref="HSVColor"/>. This property is read only.
        /// </summary>
        public HSVColor SelectedHSVColor => (HSVColor)this.GetValue(SelectedHSVColorProperty);

        /// <summary>Identifies the <see cref="ColorName"/> dependency property.</summary>
        public static readonly DependencyProperty ColorNameProperty
            = DependencyProperty.Register(nameof(ColorName),
                                          typeof(string),
                                          typeof(ColorPickerBase),
                                          new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnColorNamePropertyChanged));

        private static void OnColorNamePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is ColorPickerBase colorPicker)
            {
                if (!colorPicker.ColorIsUpdating)
                {
                    if (string.IsNullOrEmpty(e.NewValue?.ToString()))
                    {
                        colorPicker.SetCurrentValue(SelectedColorProperty, null);
                    }
                    else if (ColorHelper.ColorFromString(e.NewValue?.ToString(), colorPicker.ColorNamesDictionary) is Color color)
                    {
                        colorPicker.SetCurrentValue(SelectedColorProperty, color);
                    }
                    else
                    {
                        throw new InvalidCastException("Cannot convert the given input to a valid color");
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the ColorName
        /// </summary>
        public string ColorName
        {
            get => (string)this.GetValue(ColorNameProperty);
            set => this.SetValue(ColorNameProperty, value);
        }

        /// <summary>Identifies the <see cref="ColorNamesDictionary"/> dependency property.</summary>
        public static readonly DependencyProperty ColorNamesDictionaryProperty
            = DependencyProperty.Register(nameof(ColorNamesDictionary),
                                          typeof(Dictionary<Color?, string>),
                                          typeof(ColorPickerBase),
                                          new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a <see cref="Dictionary{TKey, TValue}"/> for looking up the ColorName
        /// </summary>
        public Dictionary<Color?, string> ColorNamesDictionary
        {
            get => (Dictionary<Color?, string>)this.GetValue(ColorNamesDictionaryProperty);
            set => this.SetValue(ColorNamesDictionaryProperty, value);
        }

        /// <summary>Identifies the <see cref="A"/> dependency property.</summary>
        public static readonly DependencyProperty AProperty
            = DependencyProperty.Register(nameof(A),
                                          typeof(byte),
                                          typeof(ColorPickerBase),
                                          new FrameworkPropertyMetadata((byte)255, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnColorChannelChanged));

        /// <summary>
        /// Gets or Sets the Alpha-Channel
        /// </summary>
        public byte A
        {
            get => (byte)this.GetValue(AProperty);
            set => this.SetValue(AProperty, value);
        }

        /// <summary>Identifies the <see cref="R"/> dependency property.</summary>
        public static readonly DependencyProperty RProperty
            = DependencyProperty.Register(nameof(R),
                                          typeof(byte),
                                          typeof(ColorPickerBase),
                                          new FrameworkPropertyMetadata((byte)0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnColorChannelChanged));

        /// <summary>
        /// Gets or Sets the Red-Channel
        /// </summary>
        public byte R
        {
            get => (byte)this.GetValue(RProperty);
            set => this.SetValue(RProperty, value);
        }

        /// <summary>Identifies the <see cref="G"/> dependency property.</summary>
        public static readonly DependencyProperty GProperty
            = DependencyProperty.Register(nameof(G),
                                          typeof(byte),
                                          typeof(ColorPickerBase),
                                          new FrameworkPropertyMetadata((byte)0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnColorChannelChanged));

        /// <summary>
        /// Gets or Sets the Green-Channel
        /// </summary>
        public byte G
        {
            get => (byte)this.GetValue(GProperty);
            set => this.SetValue(GProperty, value);
        }

        /// <summary>Identifies the <see cref="B"/> dependency property.</summary>
        public static readonly DependencyProperty BProperty
            = DependencyProperty.Register(nameof(B),
                                          typeof(byte),
                                          typeof(ColorPickerBase),
                                          new FrameworkPropertyMetadata((byte)0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnColorChannelChanged));

        /// <summary>
        /// Gets or Sets the Blue-Channel
        /// </summary>
        public byte B
        {
            get => (byte)this.GetValue(BProperty);
            set => this.SetValue(BProperty, value);
        }

        /// <summary>Identifies the <see cref="Hue"/> dependency property.</summary>
        public static readonly DependencyProperty HueProperty
            = DependencyProperty.Register(nameof(Hue),
                                          typeof(double),
                                          typeof(ColorPickerBase),
                                          new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnHSVValuesChanged));

        private static void OnHSVValuesChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is ColorPickerBase colorPicker && !colorPicker.ColorIsUpdating)
            {
                var hsv = new HSVColor(colorPicker.A / 255d, colorPicker.Hue, colorPicker.Saturation, colorPicker.Value);

                colorPicker.UpdateHsvValues = false;
                colorPicker.SetCurrentValue(SelectedColorProperty, hsv.ToColor());
                colorPicker.UpdateHsvValues = true;
            }
        }

        /// <summary>
        /// Gets or Sets the Hue-Channel
        /// </summary>
        public double Hue
        {
            get => (double)this.GetValue(HueProperty);
            set => this.SetValue(HueProperty, value);
        }

        /// <summary>Identifies the <see cref="Saturation"/> dependency property.</summary>
        public static readonly DependencyProperty SaturationProperty
            = DependencyProperty.Register(nameof(Saturation),
                                          typeof(double),
                                          typeof(ColorPickerBase),
                                          new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnHSVValuesChanged));

        /// <summary>
        /// Gets or Sets the Saturation-Channel
        /// </summary>
        public double Saturation
        {
            get => (double)this.GetValue(SaturationProperty);
            set => this.SetValue(SaturationProperty, value);
        }

        /// <summary>Identifies the <see cref="Value"/> dependency property.</summary>
        public static readonly DependencyProperty ValueProperty
            = DependencyProperty.Register(nameof(Value),
                                          typeof(double),
                                          typeof(ColorPickerBase),
                                          new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnHSVValuesChanged));

        /// <summary>
        /// Gets or Sets the Value-Channel
        /// </summary>
        public double Value
        {
            get => (double)this.GetValue(ValueProperty);
            set => this.SetValue(ValueProperty, value);
        }

        /// <summary>Identifies the <see cref="LabelAlphaChannel"/> dependency property.</summary>
        public static readonly DependencyProperty LabelAlphaChannelProperty
            = DependencyProperty.Register(nameof(LabelAlphaChannel),
                                          typeof(object),
                                          typeof(ColorPickerBase),
                                          new PropertyMetadata("A"));

        /// <summary>
        /// Gets or Sets the Alpha-Label in the GUI
        /// </summary>
        public object LabelAlphaChannel
        {
            get => (object)this.GetValue(LabelAlphaChannelProperty);
            set => this.SetValue(LabelAlphaChannelProperty, value);
        }

        /// <summary>Identifies the <see cref="LabelRedChannel"/> dependency property.</summary>
        public static readonly DependencyProperty LabelRedChannelProperty
            = DependencyProperty.Register(nameof(LabelRedChannel),
                                          typeof(object),
                                          typeof(ColorPickerBase),
                                          new PropertyMetadata("R"));

        /// <summary>
        /// Gets or Sets the Red-Label in the GUI
        /// </summary>
        public object LabelRedChannel
        {
            get => (object)this.GetValue(LabelRedChannelProperty);
            set => this.SetValue(LabelRedChannelProperty, value);
        }

        /// <summary>Identifies the <see cref="LabelGreenChannel"/> dependency property.</summary>
        public static readonly DependencyProperty LabelGreenChannelProperty
            = DependencyProperty.Register(nameof(LabelGreenChannel),
                                          typeof(object),
                                          typeof(ColorPickerBase),
                                          new PropertyMetadata("G"));

        /// <summary>
        /// Gets or Sets the Green-Label in the GUI
        /// </summary>
        public object LabelGreenChannel
        {
            get => (object)this.GetValue(LabelGreenChannelProperty);
            set => this.SetValue(LabelGreenChannelProperty, value);
        }

        /// <summary>Identifies the <see cref="LabelBlueChannel"/> dependency property.</summary>
        public static readonly DependencyProperty LabelBlueChannelProperty
            = DependencyProperty.Register(nameof(LabelBlueChannel),
                                          typeof(object),
                                          typeof(ColorPickerBase),
                                          new PropertyMetadata("B"));

        /// <summary>
        /// Gets or Sets the Blue-Label in the GUI
        /// </summary>
        public object LabelBlueChannel
        {
            get => (object)this.GetValue(LabelBlueChannelProperty);
            set => this.SetValue(LabelBlueChannelProperty, value);
        }

        /// <summary>Identifies the <see cref="LabelColorPreview"/> dependency property.</summary>
        public static readonly DependencyProperty LabelColorPreviewProperty
            = DependencyProperty.Register(nameof(LabelColorPreview),
                                          typeof(object),
                                          typeof(ColorPickerBase),
                                          new PropertyMetadata("Preview"));

        /// <summary>
        /// Gets or Sets the Preview-Label in the GUI
        /// </summary>
        public object LabelColorPreview
        {
            get => (object)this.GetValue(LabelColorPreviewProperty);
            set => this.SetValue(LabelColorPreviewProperty, value);
        }

        /// <summary>Identifies the <see cref="LabelHueChannel"/> dependency property.</summary>
        public static readonly DependencyProperty LabelHueChannelProperty
            = DependencyProperty.Register(nameof(LabelHueChannel),
                                          typeof(object),
                                          typeof(ColorPickerBase),
                                          new PropertyMetadata("H"));

        /// <summary>
        /// Gets or Sets the Hue-Label in the GUI
        /// </summary>
        public object LabelHueChannel
        {
            get => (object)this.GetValue(LabelHueChannelProperty);
            set => this.SetValue(LabelHueChannelProperty, value);
        }

        /// <summary>Identifies the <see cref="LabelSaturationChannel"/> dependency property.</summary>
        public static readonly DependencyProperty LabelSaturationChannelProperty
            = DependencyProperty.Register(nameof(LabelSaturationChannel),
                                          typeof(object),
                                          typeof(ColorPickerBase),
                                          new PropertyMetadata("S"));

        /// <summary>
        /// Gets or Sets the Saturation-Label in the GUI
        /// </summary>
        public object LabelSaturationChannel
        {
            get => (object)this.GetValue(LabelSaturationChannelProperty);
            set => this.SetValue(LabelSaturationChannelProperty, value);
        }

        /// <summary>Identifies the <see cref="LabelValueChannel"/> dependency property.</summary>
        public static readonly DependencyProperty LabelValueChannelProperty
            = DependencyProperty.Register(nameof(LabelValueChannel),
                                          typeof(object),
                                          typeof(ColorPickerBase),
                                          new PropertyMetadata("V"));

        /// <summary>
        /// Gets or Sets the Value-Label in the GUI
        /// </summary>
        public object LabelValueChannel
        {
            get => (object)this.GetValue(LabelValueChannelProperty);
            set => this.SetValue(LabelValueChannelProperty, value);
        }

        /// <summary>Identifies the <see cref="LabelColorName"/> dependency property.</summary>
        public static readonly DependencyProperty LabelColorNameProperty
            = DependencyProperty.Register(nameof(LabelColorName),
                                          typeof(object),
                                          typeof(ColorPickerBase),
                                          new PropertyMetadata("Name"));

        /// <summary>
        /// Gets or Sets the ColorName-Label in the GUI
        /// </summary>
        public object LabelColorName
        {
            get => (object)this.GetValue(LabelColorNameProperty);
            set => this.SetValue(LabelColorNameProperty, value);
        }

        /// <summary>Identifies the <see cref="SelectedColorChanged"/> routed event.</summary>
        public static readonly RoutedEvent SelectedColorChangedEvent = EventManager.RegisterRoutedEvent(
            nameof(SelectedColorChanged),
            RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<Color?>),
            typeof(ColorPickerBase));

        /// <summary>
        ///     Occurs when the <see cref="SelectedColor" /> property is changed.
        /// </summary>
        public event RoutedPropertyChangedEventHandler<Color?> SelectedColorChanged
        {
            add => this.AddHandler(SelectedColorChangedEvent, value);
            remove => this.RemoveHandler(SelectedColorChangedEvent, value);
        }

        internal virtual void OnSelectedColorChanged(Color? oldValue, Color? newValue)
        {
            // don't do a second update
            if (this.ColorIsUpdating)
            {
                return;
            }

            this.ColorIsUpdating = true;

            if (this.SelectedColor == null && this.DefaultColor != null)
            {
                this.SetCurrentValue(SelectedColorProperty, this.DefaultColor);
            }

            this.SetCurrentValue(ColorNameProperty, ColorHelper.GetColorName(this.SelectedColor, this.ColorNamesDictionary));

            // We just update the following lines if we have a Color.
            if (this.SelectedColor != null)
            {
                var color = (Color)this.SelectedColor;

                if (this.UpdateHsvValues)
                {
                    var hsv = new HSVColor(color);
                    this.SetCurrentValue(HueProperty, hsv.Hue);
                    this.SetCurrentValue(SaturationProperty, hsv.Saturation);
                    this.SetCurrentValue(ValueProperty, hsv.Value);
                }

                this.SetValue(SelectedHSVColorPropertyKey, new HSVColor(this.A / 255d, this.Hue, this.Saturation, this.Value));

                this.SetCurrentValue(AProperty, color.A);
                this.SetCurrentValue(RProperty, color.R);
                this.SetCurrentValue(GProperty, color.G);
                this.SetCurrentValue(BProperty, color.B);
            }

            this.ColorIsUpdating = false;

            this.RaiseEvent(new RoutedPropertyChangedEventArgs<Color?>(oldValue, newValue, SelectedColorChangedEvent));
        }

        internal static void OnColorChannelChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is ColorPickerBase colorPicker && !colorPicker.ColorIsUpdating)
            {
                colorPicker.SetCurrentValue(SelectedColorProperty, Color.FromArgb(colorPicker.A, colorPicker.R, colorPicker.G, colorPicker.B));
            }
        }
    }
}