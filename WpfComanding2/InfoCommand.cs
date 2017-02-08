﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfComanding2
{
    public class InfoCommand : ICommand
    {
        public void Execute(object parameter)
        {
            MessageBox.Show("Hello, world!");
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
