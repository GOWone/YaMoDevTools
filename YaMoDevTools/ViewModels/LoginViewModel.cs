using YaMoDevTools.Common;
using YaMoDevTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YaMoDevTools.Views;

namespace YaMoDevTools.ViewModels
{
    public class LoginViewModel : NotifyBase
    {
        public LoginModel LoginModel { get; set; } = new LoginModel();

        public CommandBase CloseWindowCommand { get; set; }

        public CommandBase LoginCommand { get; set; }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; this.DoNotify(); }
        }


        public LoginViewModel()
        {

            this.CloseWindowCommand = new CommandBase();
            this.CloseWindowCommand.DoExecute = new Action<object>((o) => {
                MainView.loginView = null;
                //(o as Window).Close();
            });
            this.CloseWindowCommand.DoCanExecute = new Func<object, bool>((o) =>
            {
                return true;
            });

            this.LoginCommand = new CommandBase();
            this.LoginCommand.DoExecute = new Action<object>(DoLigin);
            this.LoginCommand.DoCanExecute = new Func<object, bool>((o) =>
            {
                return true;
            });
        }

        private void DoLigin(object o)
        {
            this.ErrorMessage = "";
            if (string.IsNullOrEmpty(LoginModel.UserName))
            {
                this.ErrorMessage = "用户名不能为空!";
                return;
            }
            //if (string.IsNullOrEmpty(LoginModel.Password))
            //{
            //    this.ErrorMessage = "密码不能为空!";
            //    return;
            //}
            if (string.IsNullOrEmpty(LoginModel.VerCode))
            {
                this.ErrorMessage = "验证码不能为空!";
                return;
            }

            if (LoginModel.VerCode.ToLower() != "123")
            {
                this.ErrorMessage = "验证码错误!";
                return;
            }
        }
    }
}
