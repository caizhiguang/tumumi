using System;
namespace TMM.Model
{
	/// <summary>
	/// ʵ����D_Tag ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class D_Tag
	{
		public D_Tag()
		{}
		#region Model
		private int _tagid;
		private string _tag;
		private int _usecount;
		/// <summary>
		/// ��ǩID
		/// </summary>
		public int TagId
		{
			set{ _tagid=value;}
			get{return _tagid;}
		}
		/// <summary>
		/// ��ǩ����
		/// </summary>
		public string Tag
		{
			set{ _tag=value;}
			get{return _tag;}
		}
		/// <summary>
		/// ʹ�ô���
		/// </summary>
		public int UseCount
		{
			set{ _usecount=value;}
			get{return _usecount;}
		}
        /// <summary>
        /// Ȩ�� 1 ������� 0 ������С
        /// </summary>
        public decimal TagWeight { get; set; }
		#endregion Model

	}
}

