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
    /// ��ͷ������ģ��
    /// </summary>
    public class HeadComponent : ViewComponent
    {

        private U_UserInfo userInfo;
        /// <summary>
        /// �Ƿ��¼
        /// </summary>
        [ViewComponentParam]
        public U_UserInfo UserInfo {
            get { return userInfo; }
            set { userInfo = value; }
        }

        private int headType = 1;
        /// <summary>
        /// ���ͷ�������� 1 Ϊ��վͨ��ͷ�� 2 �ĵ����ҳͷ��
        /// </summary>
        [ViewComponentParam]
        public int HeadType
        {
            get { return headType; }
            set { headType = value; }
        }

        public override void Render()
        {
            PropertyBag["userInfo"] = this.userInfo;
            if (this.userInfo != null)
            {
                UserService us = RailsContext.GetService<UserService>();
                U_UserInfo u = Session["logonUser"] as U_UserInfo;
                PropertyBag["newMsgCount"] = us.MessageBll.GetNewMsgCount(u.UserId);
                //�˻����
                PropertyBag["accountBalance"] = us.MAccountBll.GetByUserId(u.UserId).Amount;
            }

            if (this.headType == 1)
            {
                base.Render();
            }
            else {
                RenderView("docHead");
            }
        }
    }
}
