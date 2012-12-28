using System;
namespace TMM.Model
{
	/// <summary>
	/// ʵ����S_FriendLink ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class S_FriendLink
	{
		public S_FriendLink()
		{}
		#region Model
		private int _fid;
		private string _title;
		private string _linkurl;
		private int _orderid;
		/// <summary>
		/// ��������ID
		/// </summary>
		public int Fid
		{
			set{ _fid=value;}
			get{return _fid;}
		}
		/// <summary>
		/// ��ʾ�ı�
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ���ӵ�ַ
		/// </summary>
		public string LinkUrl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public int OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		#endregion Model

	}
}

