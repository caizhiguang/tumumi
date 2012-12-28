using System;
namespace TMM.Model
{
	/// <summary>
	/// ʵ����M_Purchase ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class MPurchase
	{
		public MPurchase()
		{}
		#region Model
		private int _pid;
		private int _userid;
		private int _docid;
		private string _title;
		private DateTime? _purchasetime;
		private decimal? _price;
        private int _saler;
		/// <summary>
		/// ����ID
		/// </summary>
		public int Pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// �û�ID
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// �ĵ�ID
		/// </summary>
		public int DocId
		{
			set{ _docid=value;}
			get{return _docid;}
		}
		/// <summary>
		/// �ĵ�����
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime? PurchaseTime
		{
			set{ _purchasetime=value;}
			get{return _purchasetime;}
		}
		/// <summary>
		/// ���ѽ��
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// �ϴ���
		/// </summary>
		public int Saler
		{
			set{ _saler=value;}
			get{return _saler;}
		}
        /// <summary>
        /// �ĵ�����
        /// </summary>
        public string DocType { get; set; }
        /// <summary>
        /// �ϴ��û�����Ϣ
        /// </summary>
        public U_UserInfo UploaderInfo { get; set; }
		#endregion Model

	}
}

