using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaMoDevTools.Common.Models
{
	/// <summary>
	/// 功能菜单实体类
	/// </summary>
    public class FunctionButton:BindableBase
    {
		private string iconPath;
		/// <summary>
		/// 图标路径
		/// </summary>
		public string IconPath
		{
			get { return iconPath; }
			set { iconPath = value; }
		}

		private string title;
		/// <summary>
		/// 功能标题
		/// </summary>
		public string Title
		{
			get { return title; }
			set { title = value; }
		}

        /// <summary>
        /// 菜单命名空间
        /// </summary>
        private string nameSpace;

        public string Namespace
        {
            get { return nameSpace; }
            set { nameSpace = value; }
        }
    }
}
