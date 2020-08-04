using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMVVMBasic.Utilities;

namespace WPFMVVMBasic.ViewModels
{
    public class AddableListViewModel : BaseViewModel
    {
        public ObservableCollection<string> Items { get; set; }

        private string _inputText;
        public string InputText
        {
            get => _inputText;
            set => RaisePropertyChanged(ref _inputText, value);
        }

        private string _selectedItem;
        public string SelectedItem
        {
            get => _selectedItem;
            set => RaisePropertyChanged(ref _selectedItem, value);
        }

        public ICommand AddInputToListCommand { get; private set; }
        public ICommand ClearListCommand { get; private set; }

        public AddableListViewModel()
        {
            Items = new ObservableCollection<string>();

            AddInputToListCommand = new Command(AddInputToList);
            ClearListCommand = new Command(ClearList);
        }

        public void AddInputToList()
        {
            AddToList(InputText);
        }

        public void AddToList(string item)
        {
            if (!string.IsNullOrEmpty(item))
                Items.Add(item);
        }

        public void RemoveFromList(string item)
        {
            Items.Remove(item);
        }

        public void ClearList()
        {
            Items.Clear();
        }
    }
}
