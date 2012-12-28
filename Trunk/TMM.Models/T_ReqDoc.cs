using System;
namespace TMM.Model
{
	/// <summary>
	/// ʵ����T_ReqDoc ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class TReqDoc
	{
		public TReqDoc()
		{}
		#region Model
		private int _tid;
		private int _userid;
		private string _title;
		private string _description;
		private decimal _price;
		private DateTime _createtime;
		private DateTime _endtime;
		private int _status;
		/// <summary>
		/// ����ID
		/// </summary>
		public int TId
		{
			set{ _tid=value;}
			get{return _tid;}
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
		/// ���ͱ���
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// ���ͽ��
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// ��ֹʱ��
		/// </summary>
		public DateTime EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// ״̬ 1������� 2��ͨ�����
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
        public int DocCount { get; set; }
        public U_UserInfo Publisher { get; set; }
		#endregion Model

	}
}

