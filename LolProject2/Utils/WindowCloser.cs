﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LolProject2.Utils;
namespace LolProject2.ViewModels
{
    public class WindowCloser
    {
        public static bool GetEnableWindowClosing(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableWindowClosingProperty);
        }

        public static void SetEnableWindowClosing(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableWindowClosingProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnableWindowClosingProperty =
            DependencyProperty.RegisterAttached("EnableWindowClosingProperty", typeof(bool), typeof(WindowCloser), new PropertyMetadata(false,OnEnableWindowClosingChanged));

        private static void OnEnableWindowClosingChanged(DependencyObject win,DependencyPropertyChangedEventArgs args)
        {
            if(win is Window window)
            {
                window.Loaded += (s, e) =>
                {
                    if (window.DataContext is ICloseWindow vm)
                    {
                        vm.Close += () =>
                        {
                            window.Close();
                        };
                        window.Closing += (w, a) =>
                         {
                             a.Cancel = !vm.CanClose();
                         };
                        
                    }
                };
            }
        }
    }
}
