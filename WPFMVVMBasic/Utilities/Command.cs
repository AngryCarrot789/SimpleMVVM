﻿using System;
using System.Windows.Input;

namespace WPFMVVMBasic.Utilities
{
    /// <summary>
    /// An always executable command
    /// </summary>
    public class Command : ICommand
    {
        private readonly Action _action;

        public Command(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
