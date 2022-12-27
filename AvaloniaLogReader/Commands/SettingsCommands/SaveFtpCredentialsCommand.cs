﻿using AvaloniaLogReader.Commands.BaseCommands;
using AvaloniaLogReader.ViewModels;
using Domain.Models;
using Services.Stores;

namespace AvaloniaLogReader.Commands.SettingsCommands
{
    public class SaveFtpCredentialsCommand : CommandBase
    {

        private readonly ContentStore _contentStore;
        private readonly SettingsViewModel _settingsViewModel;

        public SaveFtpCredentialsCommand(ContentStore contentStore, SettingsViewModel settingsViewModel)
        {
            _contentStore = contentStore;
            _settingsViewModel = settingsViewModel;
        }

        public override void Execute(object parameter)
        {
            FtpCredentials updatedFtpCredentials = new FtpCredentials
            {
                Host = _settingsViewModel.Host,
                Login = _settingsViewModel.Login,
                Password = _settingsViewModel.Password.ToString(),
                PathToFiles = _settingsViewModel.PathToFiles,
                Port = _settingsViewModel.Port,
                Id = 1
            };

            _contentStore._ftpCredentialsRepository.Update(updatedFtpCredentials);
        }
    }
}
