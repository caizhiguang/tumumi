using System;
namespace TMM.Model
{
	/// <summary>
	/// ʵ����D_FileInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class D_FileInfo
	{
		public D_FileInfo()
		{}
		#region Model
		private Guid _fid;
		private int? _filetype;
		private string _filename;
		private int _ownerid;
		private string _filepath;
		private DateTime _createtime;
		/// <summary>
		/// �ļ�ID
		/// </summary>
		public Guid Fid
		{
			set{ _fid=value;}
			get{return _fid;}
		}
		/// <summary>
		/// �ļ�����
		/// </summary>
		public int? FileType
		{
			set{ _filetype=value;}
			get{return _filetype;}
		}
		/// <summary>
		/// �ļ�ԭʼ����
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// ������ID
		/// </summary>
		public int OwnerId
		{
			set{ _ownerid=value;}
			get{return _ownerid;}
		}
		/// <summary>
		/// �ļ�·��
		/// </summary>
		public string FilePath
		{
			set{ _filepath=value;}
			get{return _filepath;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

