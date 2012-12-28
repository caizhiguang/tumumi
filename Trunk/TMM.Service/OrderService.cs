using System;
using System.Collections;
using Castle.Core;
using System.Collections.Generic;

using TMM.Model;
using TMM.Persistence;
using TMM.Service.Bll;
using TMM.Service.Bll.Admin;

namespace TMM.Service
{
    public class OrderService : IServiceEnabledComponent, IInitializable
    {
        private IServiceProvider provider;
        
        

        #region IInitializable Members

        public void Initialize()
        {
            TOrderBll = new TMM.Service.Bll.Order.TOrderBLL();
            TOrderDetailBll = new TMM.Service.Bll.Order.TOrderDetailBLL();
            MPurchaseBll = new TMM.Service.Bll.User.MPurchaseBLL();
            MAccountBll = new TMM.Service.Bll.User.MAccountBLL();
            MPayLogBll = new TMM.Service.Bll.Order.MPayLogBLL();
            MAccountLogBll = new TMM.Service.Bll.Order.AccountLogBLL();
            DDocInfoBll = new TMM.Service.Bll.Doc.DDocInfoBLL();
            UserInfoBll = new TMM.Service.Bll.User.U_UserInfoBLL();
            ExchangeAccountBll = new TMM.Service.Bll.Order.ExchangeAccountBLL();
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
        /// ��Ʒ��
        /// </summary>
        public Bll.Doc.DDocInfoBLL DDocInfoBll;
        /// <summary>
        /// ������
        /// </summary>
        public Bll.Order.TOrderBLL TOrderBll;
        /// <summary>
        /// ������ϸ
        /// </summary>
        public Bll.Order.TOrderDetailBLL TOrderDetailBll;
        /// <summary>
        /// �����¼
        /// </summary>
        public Bll.User.MPurchaseBLL MPurchaseBll;
        /// <summary>
        /// �˻�
        /// </summary>
        public Bll.User.MAccountBLL MAccountBll;
        /// <summary>
        /// �˻���־
        /// </summary>
        public Bll.Order.AccountLogBLL MAccountLogBll;
        /// <summary>
        /// ����֧����¼
        /// </summary>
        public Bll.Order.MPayLogBLL MPayLogBll;
        /// <summary>
        /// �û���Ϣ
        /// </summary>
        public Bll.User.U_UserInfoBLL UserInfoBll;
        /// <summary>
        /// �һ��˻���Ϣ
        /// </summary>
        public Bll.Order.ExchangeAccountBLL ExchangeAccountBll;

    }
}
