using System;
using System.Collections.Generic;
namespace TMM.Model
{
	/// <summary>
	/// ʵ����S_Catalog ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class S_Catalog
	{
		public S_Catalog()
		{}
		#region Model
		private int _catalogid;
		private string _catalogname;
		private int? _pid;
		private int _orderid;
        private IList<S_Catalog> subCatalog;
		/// <summary>
		/// ����ID
		/// </summary>
		public int CatalogId
		{
			set{ _catalogid=value;}
			get{return _catalogid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string CatalogName
		{
			set{ _catalogname=value;}
			get{return _catalogname;}
		}
		/// <summary>
		/// ��ID
		/// </summary>
		public int? Pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public int OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
        /// <summary>
        /// �ӷ���
        /// </summary>
        public IList<S_Catalog> SubCatalog
        {
            get { return subCatalog; }
            set { subCatalog = value; }
        }
		#endregion Model

	}
}

