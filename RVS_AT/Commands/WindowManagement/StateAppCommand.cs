﻿using System.Windows;
using WpfLogReader.Commands.BaseCommands;

namespace WpfLogReader.Commands.WindowManagement
{
    public class StateAppCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }
    }
}
