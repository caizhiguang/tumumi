using System;
namespace TMM.Model
{
	/// <summary>
	/// ʵ����D_Rel_DocTag ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class D_Rel_DocTag
	{
		public D_Rel_DocTag()
		{}
		#region Model
		private int _docid;
		private int _tagid;
		/// <summary>
		/// �ĵ�ID
		/// </summary>
		public int DocId
		{
			set{ _docid=value;}
			get{return _docid;}
		}
		/// <summary>
		/// ��ǩID
		/// </summary>
		public int TagId
		{
			set{ _tagid=value;}
			get{return _tagid;}
		}
        public int Id { get; set; }
		#endregion Model

	}
}

