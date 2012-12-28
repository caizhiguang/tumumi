using System;
namespace TMM.Model
{
	/// <summary>
	/// ʵ����N_News ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class N_News
	{
		public N_News()
		{}
		#region Model
		private int _nid;
		private string _title;
		private string _content;
		private string _catalog;
		/// <summary>
		/// ����ID
		/// </summary>
		public int Nid
		{
			set{ _nid=value;}
			get{return _nid;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
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
		/// ���ŷ���
		/// </summary>
		public string Catalog
		{
			set{ _catalog=value;}
			get{return _catalog;}
		}
		#endregion Model

	}
}

