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
    /// FeedbackView.xaml 的交互逻辑
    /// </summary>
    public partial class FeedbackView : Window
    {
        public FeedbackView()
        {
            InitializeComponent();
        }

        private void btn_CloseFeedback(object sender, RoutedEventArgs e)
        {
            MainView.feedbackView = null;
            //this.Close();
        }

        private void FeedbackMove_LBDownEvent(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btn_SubmitFeedback(object sender, MouseButtonEventArgs e)
        {
            //this.Close();
            MainView.feedbackView = null;
        }
    }
}
