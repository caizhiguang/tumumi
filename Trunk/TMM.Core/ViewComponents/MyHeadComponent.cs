using System;
using Castle.MonoRail.Framework;
using System.Collections.Specialized;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using TMM.Model;
using TMM.Service;



namespace TMM.Core.ViewComponents
{
    /// <summary>
    /// �ҵ���ľ��ͷ������ģ��
    /// </summary>
    public class MyHeadComponent : ViewComponent
    {
        
        private bool isLogin;
        /// <summary>
        /// �Ƿ��¼
        /// </summary>
        [ViewComponentParam]
        public bool IsLogin {
            get { return isLogin; }
            set { isLogin = value; }
        }

        public override void Render()
        {
            PropertyBag["isLogin"] = this.isLogin;
            UserService us = RailsContext.GetService<UserService>();
            U_UserInfo u = Session["logonUser"] as U_UserInfo;
            PropertyBag["newMsgCount"] = us.MessageBll.GetNewMsgCount(u.UserId);
            base.Render();
        }
    }
}
