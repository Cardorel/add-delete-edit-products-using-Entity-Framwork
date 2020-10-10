using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EKZAMENADONET.ViewModels
{
    internal class CloseDialogBehavior
    {
        public static readonly DependencyProperty CloseDialogProperty
            = DependencyProperty.RegisterAttached(
                    "CloseDialog",
                    typeof(bool),
                    typeof(CloseDialogBehavior),
                    new PropertyMetadata(false, OnCloseDialogPropertyChanged));

        public static bool GetCloseDialog(Window dlg)
        {
            return (bool)dlg.GetValue(CloseDialogProperty);
        }

        public static void SetCloseDialog(Window dlg, bool value)
        {
            dlg.SetValue(CloseDialogProperty, value);
        }

        private static void OnCloseDialogPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Window dlg = d as Window;
            bool isClose = (bool)e.NewValue;
            if (dlg == null || !isClose)
            {
                return;
            }

            dlg.Close();
        }
    }
}
