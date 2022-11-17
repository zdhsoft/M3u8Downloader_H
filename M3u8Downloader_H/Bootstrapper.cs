﻿using System;
using System.Net;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Threading;
using Caliburn.Micro;
using M3u8Downloader_H.Services;
using M3u8Downloader_H.ViewModels;

namespace M3u8Downloader_H
{
    public class Bootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer simpleContainer = new();
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            simpleContainer
                .PerRequest<IWindowManager, WindowManager>();

            simpleContainer
                .Singleton<SettingsService>()
                .Singleton<DownloadService>()
                .Singleton<SoundService>()
                .Singleton<PluginService>()
                .PerRequest<MainWindowViewModel>()
                .PerRequest<DownloadViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return simpleContainer.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return simpleContainer.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            simpleContainer.BuildUp(instance);
        }

        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            ServicePointManager.DefaultConnectionLimit = 2000;
            await DisplayRootViewForAsync<MainWindowViewModel>();
        }


#if !DEBUG
        protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            base.OnUnhandledException(sender, e);

            MessageBox.Show(e.Exception.Message, "错误详情", MessageBoxButton.OK, MessageBoxImage.Error);
        }
#endif

    }
}
