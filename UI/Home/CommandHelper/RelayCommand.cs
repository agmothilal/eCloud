using System;
using System.Windows.Input;

namespace Home.CommandHelper
{
    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action execute;
        private readonly Func<bool> canExecute;

        #endregion

        #region Ctors

        public RelayCommand(Action execute) : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion

        #region ICommand members

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }

        #endregion
    }

    public class RelayCommand<T> : ICommand
    {
        #region Fields

        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;

        #endregion

        #region Ctors

        public RelayCommand(Action<T> execute) : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion

        #region ICommand members

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            execute((T)parameter);
        }

        #endregion
    }
}
