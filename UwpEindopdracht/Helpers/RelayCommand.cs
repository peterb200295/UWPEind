﻿using System;
using System.Windows.Input;

namespace Exercise4.Helpers
{
    public sealed class RelayCommand : ICommand
    {
        public delegate bool CanExecuteDelegate(object parameter);

        private readonly Action<object> _action;
        private readonly CanExecuteDelegate _canExecute;

        public RelayCommand(Action<object> action, CanExecuteDelegate canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
