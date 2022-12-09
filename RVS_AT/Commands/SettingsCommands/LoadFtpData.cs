﻿using RVS_AT.Commands.BaseCommands;
using RVS_AT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RVS_AT.Commands.SettingsCommands
{
    public class LoadFtpData : AsyncCommandBase
    {
        private readonly SettingsViewModel _settingsViewModel;
        private readonly Ftp _ftp;

        public LoadFtpData(SettingsViewModel settingsViewModel, Ftp ftp)
        {
            _settingsViewModel = settingsViewModel;
            _ftp = ftp;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var ftpData = await _ftp.GetListingAsync();

            var fileCount = ftpData.Count;

            if (fileCount > 0)
            {
                var current = 0;
                foreach (var file in ftpData)
                {
                    current++;
                    _ftp.DownloadFile(file);
                    _settingsViewModel.UpdateProgressBar(current, fileCount);
                    Thread.Sleep(500);
                }
            }
            else
            {
                _settingsViewModel.Progress = 0;
            }
        }
    }
}
