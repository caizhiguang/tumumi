using System;
namespace TMM.Model
{
	/// <summary>
	/// ʵ����D_Comment ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class D_Comment
	{
		public D_Comment()
		{}
		#region Model
		private int _commentid;
		private int _docid;
		private string _content;
		private DateTime _createtime;
		private int _userid;
		/// <summary>
		/// ����ID
		/// </summary>
		public int CommentId
		{
			set{ _commentid=value;}
			get{return _commentid;}
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
		/// ����
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
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
		/// ������
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
        public bool IsDisp { get; set; }

        public U_UserInfo UserInfo { get; set; }
		#endregion Model

	}
}

