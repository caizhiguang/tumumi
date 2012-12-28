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
    public class DocService : IServiceEnabledComponent, IInitializable
    {
        private IServiceProvider provider;
        
        

        #region IInitializable Members

        public void Initialize()
        {
            DCommentBll = new TMM.Service.Bll.Doc.D_CommentBLL();
            DDocInfoBll = new TMM.Service.Bll.Doc.DDocInfoBLL();
            SCatalogBll = new TMM.Service.Bll.Sys.S_CatalogBLL();
            DownloadLogBll = new TMM.Service.Bll.Doc.DownloadLogBLL();
            TReqDocBll = new TMM.Service.Bll.Doc.TReqDocBLL();
            TJoinDocBll = new TMM.Service.Bll.Doc.TJoinDocBLL();
            DTagBll = new TMM.Service.Bll.Doc.D_TagBLL();
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
        /// �ĵ�����
        /// </summary>
        public Bll.Doc.D_CommentBLL DCommentBll;
        /// <summary>
        /// �ĵ�
        /// </summary>
        public Bll.Doc.DDocInfoBLL DDocInfoBll;
        /// <summary>
        /// ϵͳ����
        /// </summary>
        public Bll.Sys.S_CatalogBLL SCatalogBll;
        /// <summary>
        /// ������־
        /// </summary>
        public Bll.Doc.DownloadLogBLL DownloadLogBll;
        /// <summary>
        /// �����ĵ�
        /// </summary>
        public Bll.Doc.TReqDocBLL TReqDocBll;
        /// <summary>
        /// �����ĵ������б�
        /// </summary>
        public Bll.Doc.TJoinDocBLL TJoinDocBll;
        /// <summary>
        /// ��ǩ
        /// </summary>
        public Bll.Doc.D_TagBLL DTagBll;
    }
}
