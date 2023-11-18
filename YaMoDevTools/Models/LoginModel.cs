using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YaMoDevTools.Common;

namespace YaMoDevTools.Models
{
    public class LoginModel : NotifyBase
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; this.DoNotify(); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; this.DoNotify(); }
        }

        private string _verCode;

        public string VerCode
        {
            get { return _verCode; }
            set { _verCode = value; this.DoNotify(); }
        }

    }
}
