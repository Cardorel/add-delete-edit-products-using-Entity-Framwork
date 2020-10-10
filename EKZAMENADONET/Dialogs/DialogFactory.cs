using EKZAMENADONET.ViewModels;
using EKZAMENADONET.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKZAMENADONET.Dialogs
{
    static class DialogFactory
    {
        public static void ShowGoodDialog(GoodDialogViewModal vm)
        {
            var v = new GoodDialogView() { DataContext = vm };
            v.ShowDialog();
        }
    }
}
