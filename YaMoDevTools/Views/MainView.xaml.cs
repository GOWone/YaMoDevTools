using System;
using System.Collections.Generic;
using System.Linq;
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

namespace YaMoDevTools.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public static LoginView loginView = null;
        public static FeedbackView feedbackView = null;
        public MainView()
        {
            InitializeComponent();
        }

        private void btn_UserManager(object sender, MouseButtonEventArgs e)
        {
            if (loginView == null)
            {
                loginView = new LoginView();
                loginView.Show();
            }
            else
            {
                loginView.Activate();
                loginView.WindowState = WindowState.Normal;
            }

        }

        private void btn_UserFeedback(object sender, MouseButtonEventArgs e)
        {
            if (feedbackView == null)
            {
                feedbackView = new FeedbackView();
                feedbackView.Show();
            }
            else
            { 
                feedbackView.Activate();
                feedbackView.WindowState = WindowState.Normal;
            }

        }
    }
}
