using YaMoDevTools.Common;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YaMoDevTools.ViewModels;
using YaMoDevTools.Views;

namespace YaMoDevTools
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// 创建启动窗口
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="containerRegistry"></param>
        /// <exception cref="NotImplementedException"></exception>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
            containerRegistry.RegisterForNavigation<UserInfoView, UserInfoViewModel>();
            containerRegistry.RegisterForNavigation<TranslateView, TranslateViewModel>();
            containerRegistry.RegisterForNavigation<RemoteToolView, MemoViewModel>();

            containerRegistry.RegisterForNavigation<OcrView, OcrViewModel>();
            containerRegistry.RegisterForNavigation<FormatCovView, FormatCovViewModel>();
            containerRegistry.RegisterForNavigation<CredPhotoView, CredPhotoViewModel>();
            containerRegistry.RegisterForNavigation<CalculatorView, CalculatorViewModel>();
            containerRegistry.RegisterForNavigation<SettingView, SettingViewModel>();
        }
    }
}

