using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using EKZAMENADONET.Models;

namespace EKZAMENADONET.ViewModels
{
    interface IGood
    {
        ObservableCollection<Good> Goods { get;}
    }
}
