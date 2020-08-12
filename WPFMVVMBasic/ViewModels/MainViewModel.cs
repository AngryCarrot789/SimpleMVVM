using System.Windows.Input;
using WPFMVVMBasic.ListItem;
using WPFMVVMBasic.Utilities;

namespace WPFMVVMBasic.ViewModels
{
    public class MainViewModel
    {
        /// <summary>
        /// The Left list view model
        /// </summary>
        public AddableListViewModel ListOne { get; private set; }

        /// <summary>
        /// The Right list view model.
        /// </summary>
        public AddableListViewModel ListTwo { get; private set; }

        // The 2 ViewModels above are 2 different instances so they're unrelated
        // in terms of the items in the Items collection, InputText, etc.


        /// <summary>
        /// The command to move items between listboxes.
        /// </summary>
        public ICommand MoveItemBetweenListCommand { get; private set; }

        public MainViewModel()
        {
            ListOne = new AddableListViewModel();
            ListTwo = new AddableListViewModel();

            // this command requires a parameter so CommandParam is used.
            // <string> specifies what the paramater type if (string, int, etc)
            MoveItemBetweenListCommand = new CommandParam<string>(MoveItemBetweenList);
        }

        public void MoveItemBetweenList(string listToList)
        {
            if (listToList == "1to2")
            {
                // Move selected item from list 1 to list 2

                AListItemViewModel selectedItem = ListOne.SelectedItem;
                ListOne.RemoveFromList(selectedItem);
                ListTwo.AddToList(selectedItem);
            }

            if (listToList == "2to1")
            {
                // Move selected item from list 2 to list 1

                AListItemViewModel selectedItem = ListTwo.SelectedItem;
                ListTwo.RemoveFromList(selectedItem);
                ListOne.AddToList(selectedItem);
            }
        }
    }
}
