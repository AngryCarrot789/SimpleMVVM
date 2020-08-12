using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFMVVMBasic.Utilities;

namespace WPFMVVMBasic.ListItem
{
    public class AListItemViewModel : BaseViewModel
    {
        private string _text;
        public string Text
        {
            get => _text;
            set => RaisePropertyChanged(ref _text, value);
        }
    }
}
