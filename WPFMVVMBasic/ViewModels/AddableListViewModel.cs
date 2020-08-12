using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMVVMBasic.ListItem;
using WPFMVVMBasic.Utilities;

namespace WPFMVVMBasic.ViewModels
{
    public class AddableListViewModel : BaseViewModel
    {
        /// <summary>
        /// The bindable collection of items
        /// </summary>
        public ObservableCollection<AListItemViewModel> Items { get; set; }

        private string _inputText;

        /// <summary>
        /// The text in the textbox
        /// </summary>
        public string InputText
        {
            get => _inputText;
            set => RaisePropertyChanged(ref _inputText, value);
        }

        private AListItemViewModel _selectedItem;

        /// <summary>
        /// The selected listboxitem.
        /// </summary>
        public AListItemViewModel SelectedItem
        {
            get => _selectedItem;
            set => RaisePropertyChanged(ref _selectedItem, value);
        }

        public ICommand AddInputToListCommand { get; private set; }
        public ICommand ClearListCommand { get; private set; }

        public AddableListViewModel()
        {
            Items = new ObservableCollection<AListItemViewModel>();

            AddInputToListCommand = new Command(AddInputToList);
            ClearListCommand = new Command(ClearList);
        }

        public AListItemViewModel CreateItem(string text)
        {
            return new AListItemViewModel() { Text = text };
        }

        public void AddInputToList()
        {
            AddToList(CreateItem(InputText));
        }

        public void AddToList(AListItemViewModel item)
        {
            if (!string.IsNullOrEmpty(item.Text))
                Items.Add(item);
        }

        public void RemoveFromList(AListItemViewModel item)
        {
            Items.Remove(item);
        }

        public void ClearList()
        {
            Items.Clear();
        }
    }
}
