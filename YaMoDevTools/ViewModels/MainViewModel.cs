using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using YaMoDevTools.Common.Models;
using YaMoDevTools.Extensions;

namespace YaMoDevTools.ViewModels
{
    public class MainViewModel:BindableBase
    {
        //导航命令
        public DelegateCommand<FunctionButton> NavigateCommand { get; private set; }
        //区域导航日志
        private IRegionNavigationJournal regionNavigationJournal;
        private readonly IRegionManager regionManager;
        public MainViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<FunctionButton>();
            NavigateCommand = new DelegateCommand<FunctionButton>(Navigate);
            CreateMenuBar();
            this.regionManager = regionManager;
        }

        private void Navigate(FunctionButton obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.Namespace))
            {
                return;
            }
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.Namespace, back =>
            {
                regionNavigationJournal = back.Context.NavigationService.Journal;
            });
        }

        private ObservableCollection<FunctionButton> menuBars;

        public ObservableCollection<FunctionButton> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        void CreateMenuBar()
        {
            MenuBars.Add(new FunctionButton() { IconPath= "/Assets/index.png", Title= "首页", Namespace = "IndexView"});
            MenuBars.Add(new FunctionButton() { IconPath= "/Assets/ocrIcon.png", Title= "OCR文字识别", Namespace = "OcrView" });
            MenuBars.Add(new FunctionButton() { IconPath= "/Assets/remoteIcon.png", Title= "远程工具", Namespace = "RemoteToolView" });
            MenuBars.Add(new FunctionButton() { IconPath= "/Assets/formatCovIcon.png", Title= "格式转换", Namespace = "FormatCovView" });

            MenuBars.Add(new FunctionButton() { IconPath= "/Assets/photomakeIcon.png", Title= "证件照制作", Namespace = "CredPhotoView" });
            MenuBars.Add(new FunctionButton() { IconPath= "/Assets/traslateIcon.png", Title= "翻译", Namespace = "TranslateView" });
            MenuBars.Add(new FunctionButton() { IconPath= "/Assets/calcIcon.png", Title= "计算器", Namespace = "CalculatorView" });
            MenuBars.Add(new FunctionButton() { IconPath= "/Assets/setting.png", Title= "设置", Namespace = "SettingView" });
        }
    }
}
