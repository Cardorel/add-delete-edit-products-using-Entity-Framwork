using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKZAMENADONET.ViewModels
{
    class MainViewModel: BindableBase
    {
        private IGood category;
        public MainViewModel(IGood c)
        {
            category = c;
        }

        public IGood Categories => category;
    }
}
