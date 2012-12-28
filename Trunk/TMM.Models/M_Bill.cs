using System;
namespace TMM.Model
{
	/// <summary>
	/// ʵ����M_Bill ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class M_Bill
	{
		public M_Bill()
		{}
		#region Model
		private int _bid;
		private int _userid;
		private DateTime _createtime;
		private int _direct;
		private string _remark;
		private int _status;
		private decimal _price;
		/// <summary>
		/// �˵�ID
		/// </summary>
		public int Bid
		{
			set{ _bid=value;}
			get{return _bid;}
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
		/// ����ʱ��
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// �˵�����
		/// </summary>
		public int Direct
		{
			set{ _direct=value;}
			get{return _direct;}
		}
		/// <summary>
		/// �˵���ע
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// ״̬
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		#endregion Model

	}
}

