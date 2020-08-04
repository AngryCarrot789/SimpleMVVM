using System.Windows.Input;
using WPFMVVMBasic.Utilities;

namespace WPFMVVMBasic.ViewModels
{
    public class MainViewModel
    {
        public AddableListViewModel ListOne { get; private set; }
        public AddableListViewModel ListTwo { get; private set; }

        public ICommand MoveItemBetweenListCommand { get; private set; }

        public MainViewModel()
        {
            ListOne = new AddableListViewModel();
            ListTwo = new AddableListViewModel();

            MoveItemBetweenListCommand = new CommandParam<string>(MoveItemBetweenList);
        }

        public void MoveItemBetweenList(string listToList)
        {
            if (listToList == "1to2")
            {
                // Move selected item from list 1 to list 2

                string selectedItem = ListOne.SelectedItem;
                ListOne.RemoveFromList(selectedItem);
                ListTwo.AddToList(selectedItem);
            }

            if (listToList == "2to1")
            {
                // Move selected item from list 2 to list 1

                string selectedItem = ListTwo.SelectedItem;
                ListTwo.RemoveFromList(selectedItem);
                ListOne.AddToList(selectedItem);
            }
        }
    }
}
