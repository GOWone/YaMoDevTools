using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YaMoDevTools.Pages;
using YaMoDevTools.ViewModels;

namespace YaMoDevTools.Views
{
    /// <summary>
    /// TranslateView.xaml 的交互逻辑
    /// </summary>
    public partial class TranslateView : UserControl
    {
        public TranslateView()
        {
            InitializeComponent();
        }

        private void btn_ToWordTranslatePage(object sender, MouseButtonEventArgs e)
        {
            WordTranslatePage wordTranslatePage = new WordTranslatePage();
            if (wordTranslatePage != null)
            {
                TranslateInputArea.Content = new Frame()
                {
                    Content = wordTranslatePage
                };
            }
        }

        private void btn_ToImageTranslatePage(object sender, MouseButtonEventArgs e)
        {
            ImageTranslatePage imageTranslatePage = new ImageTranslatePage();
            if (imageTranslatePage != null)
            {
                TranslateInputArea.Content = new Frame()
                {
                    Content = imageTranslatePage
                };
            }
        }

        private void btn_ToDocTranslatePage(object sender, MouseButtonEventArgs e)
        {
            DocTranslatePage docTranslatePage = new DocTranslatePage();
            if (docTranslatePage != null)
            {
                TranslateInputArea.Content = new Frame()
                {
                    Content = docTranslatePage
                };
            }
        }

    }
}
