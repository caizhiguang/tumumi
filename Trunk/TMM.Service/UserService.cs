using System;
using System.Collections;
using Castle.Core;
using System.Collections.Generic;

using TMM.Model;
using TMM.Persistence;
using TMM.Service.Bll.Sys;
using TMM.Service.Bll;

namespace TMM.Service
{
    public class UserService : IServiceEnabledComponent, IInitializable
    {
        private IServiceProvider provider;
        
        

        #region IInitializable Members

        public void Initialize()
        {
            UserInfoBll = new TMM.Service.Bll.User.U_UserInfoBLL();
            MessageBll = new TMM.Service.Bll.User.M_MessageBLL();
            DocInfoBll = new TMM.Service.Bll.Doc.DDocInfoBLL();
            MCatalogBll = new TMM.Service.Bll.Doc.MCatalogBLL();
            MFavoriteBll = new TMM.Service.Bll.Doc.MFavoriteBLL();
            DTagBll = new TMM.Service.Bll.Doc.D_TagBLL();
            MPurchaseBll = new TMM.Service.Bll.User.MPurchaseBLL();
            MAccountBll = new TMM.Service.Bll.User.MAccountBLL();
            TReqDocBll = new TMM.Service.Bll.Doc.TReqDocBLL();
            AccountLogBll = new TMM.Service.Bll.Order.AccountLogBLL();
        }

        #endregion

        #region IServiceEnabledComponent Members

        public void Service(IServiceProvider provider)
        {
            this.provider = provider;
            
        }
	    public void initService()
	    {
		    
	    }

        #endregion

        /// <summary>
        /// �û�
        /// </summary>
        public Bll.User.U_UserInfoBLL UserInfoBll;
        /// <summary>
        /// ��Ϣ
        /// </summary>
        public Bll.User.M_MessageBLL MessageBll;
        /// <summary>
        /// �ĵ�
        /// </summary>
        public Bll.Doc.DDocInfoBLL DocInfoBll;
        /// <summary>
        /// �����ļ���
        /// </summary>
        public Bll.Doc.MCatalogBLL MCatalogBll;
        /// <summary>
        /// �����ղ�
        /// </summary>
        public Bll.Doc.MFavoriteBLL MFavoriteBll;
        /// <summary>
        /// ��ǩ
        /// </summary>
        public Bll.Doc.D_TagBLL DTagBll;
        /// <summary>
        /// �ҵĹ���
        /// </summary>
        public Bll.User.MPurchaseBLL MPurchaseBll;
        /// <summary>
        /// �����˻�
        /// </summary>
        public Bll.User.MAccountBLL MAccountBll;
        /// <summary>
        /// �˻���־
        /// </summary>
        public Bll.Order.AccountLogBLL AccountLogBll;
        /// <summary>
        /// �����ĵ�
        /// </summary>
        public Bll.Doc.TReqDocBLL TReqDocBll;
    }
}
