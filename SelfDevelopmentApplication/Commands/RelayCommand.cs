﻿using System;
using System.Windows.Input;

namespace SelfDevelopmentApplication.Commands
{
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Func<object, bool> _canExecute;
        private Action<object> _execute;

        public RelayCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _canExecute = CanExecute;
            _execute = Execute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
