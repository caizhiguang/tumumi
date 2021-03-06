//==============================================================================
//	CAUTION: This file is generated by IBatisNetGen.Entity.cst at 2010-12-17 15:46:13
//				Any manual editing will be lost in re-generation.
//==============================================================================
using System;
using System.Collections.Generic;
using System.Text;

namespace TMM.Model  
{
	
    /// <summary><c>DDocInfo</c> Business Object.</summary>
    [Serializable]
    public partial class DDocInfo {
        
        #region DocId

        private Int32 m_docId;
		
		/// <summary>Gets or sets DocId</summary>
        public Int32 DocId {
        	get { return m_docId; }
        	set { m_docId = value;}        
        }
		
	    #endregion
		
        #region UserId

        private Int32 m_userId;
		
		/// <summary>Gets or sets UserId</summary>
        public Int32 UserId {
        	get { return m_userId; }
        	set { m_userId = value;}        
        }
		
	    #endregion
		
        #region UserCateId

        private Int32 m_userCateId;
		
		/// <summary>Gets or sets UserCateId</summary>
        public Int32 UserCateId {
        	get { return m_userCateId; }
        	set { m_userCateId = value;}        
        }
		
	    #endregion
		
        #region Title

        private String m_title;
		
		/// <summary>Gets or sets Title</summary>
        public String Title {
        	get {
                if (string.IsNullOrEmpty(m_title))
                {
                    return m_fileName;
                }
                else
                    return m_title;
            }
        	set { m_title = value;}        
        }
		
	    #endregion
		
        #region DocType

        private string m_docType;
		
		/// <summary>Gets or sets DocType</summary>
        public string DocType {
        	get { return m_docType; }
        	set { m_docType = value;}        
        }
		
	    #endregion
		
        #region CateId

        private Int32? m_cateId;
		
		/// <summary>Gets or sets CateId</summary>
        public Int32? CateId {
        	get { return m_cateId; }
        	set { m_cateId = value;}        
        }
		
	    #endregion

        
		
        #region Description

        private String m_description;
		
		/// <summary>Gets or sets Description</summary>
        public String Description {
        	get { return m_description; }
        	set { m_description = value;}        
        }
		
	    #endregion
		
        #region Tags

        private String m_tags;
		
		/// <summary>Gets or sets Tags</summary>
        public String Tags {
        	get { return m_tags; }
        	set { m_tags = value;}        
        }
		
	    #endregion
		
        #region Price

        private Decimal m_price;
		
		/// <summary>Gets or sets Price</summary>
        public Decimal Price {
        	get { return m_price; }
        	set { m_price = value;}        
        }
		
	    #endregion
		
        #region ViewCount

        private Int32 m_viewCount;
		
		/// <summary>Gets or sets ViewCount</summary>
        public Int32 ViewCount {
        	get { return m_viewCount; }
        	set { m_viewCount = value;}        
        }
		
	    #endregion
		
        #region FavCount

        private Int32 m_favCount;
		
		/// <summary>Gets or sets FavCount</summary>
        public Int32 FavCount {
        	get { return m_favCount; }
        	set { m_favCount = value;}        
        }
		
	    #endregion
		
        #region UpCount

        private Int32 m_upCount;
		
		/// <summary>Gets or sets UpCount</summary>
        public Int32 UpCount {
        	get { return m_upCount; }
        	set { m_upCount = value;}        
        }
		
	    #endregion

        #region CommentCount

        private Int32 m_commentCount;

        /// <summary>Gets or sets UpCount</summary>
        public Int32 CommentCount
        {
            get { return m_commentCount; }
            set { m_commentCount = value; }
        }

        #endregion
		
        #region CreateTime

        private DateTime m_createTime;
		
		/// <summary>Gets or sets CreateTime</summary>
        public DateTime CreateTime {
        	get { return m_createTime; }
        	set { m_createTime = value;}        
        }
		
	    #endregion
		
        #region IsAudit

        private Boolean m_isAudit;
		
		/// <summary>Gets or sets IsAudit</summary>
        public Boolean IsAudit {
        	get { return m_isAudit; }
        	set { m_isAudit = value;}        
        }
		
	    #endregion
		
        #region IsRecommend

        private Boolean m_isRecommend;
		
		/// <summary>Gets or sets IsRecommend</summary>
        public Boolean IsRecommend {
        	get { return m_isRecommend; }
        	set { m_isRecommend = value;}        
        }
		
	    #endregion
		
        #region IsTaskDoc

        private Boolean m_isTaskDoc;
		
		/// <summary>Gets or sets IsTaskDoc</summary>
        public Boolean IsTaskDoc {
        	get { return m_isTaskDoc; }
        	set { m_isTaskDoc = value;}        
        }
		
	    #endregion
		
        #region ThumbnailUrl

        private String m_thumbnailUrl;
		
		/// <summary>Gets or sets ThumbnailUrl</summary>
        public String ThumbnailUrl {
        	get { return m_thumbnailUrl; }
        	set { m_thumbnailUrl = value;}        
        }
		
	    #endregion
		
        #region FlashUrl

        private String m_flashUrl;
		
		/// <summary>Gets or sets FlashUrl</summary>
        public String FlashUrl {
        	get { return m_flashUrl; }
        	set { m_flashUrl = value;}        
        }
		
	    #endregion
		
        #region BuyCount

        private Int32 m_buyCount;
		
		/// <summary>Gets or sets BuyCount</summary>
        public Int32 BuyCount {
        	get { return m_buyCount; }
        	set { m_buyCount = value;}        
        }
		
	    #endregion
		
        #region DownCount

        private Int32 m_downCount;
		
		/// <summary>Gets or sets DownCount</summary>
        public Int32 DownCount {
        	get { return m_downCount; }
        	set { m_downCount = value;}        
        }
		
	    #endregion
		
        #region FileId

        private Guid? m_fileId;
		
		/// <summary>Gets or sets FileId</summary>
        public Guid? FileId {
        	get { return m_fileId; }
        	set { m_fileId = value;}        
        }
		
	    #endregion
		
        #region FileName

        private String m_fileName;
		
		/// <summary>Gets or sets FileName</summary>
        public String FileName {
        	get { return m_fileName; }
        	set { m_fileName = value;}        
        }
		
	    #endregion
		
        #region FileLength

        private Int32 m_fileLength;
		
		/// <summary>Gets or sets FileLength</summary>
        public Int32 FileLength {
        	get { return m_fileLength; }
        	set { m_fileLength = value;}        
        }
		
	    #endregion
		
        #region PageCount

        private Int32? m_pageCount;
		
		/// <summary>Gets or sets PageCount</summary>
        public Int32? PageCount {
        	get { return m_pageCount; }
        	set { m_pageCount = value;}        
        }
		
	    #endregion
		
        #region PhysicalPath

        private String m_physicalPath;
		
		/// <summary>Gets or sets PhysicalPath</summary>
        public String PhysicalPath {
        	get { return m_physicalPath; }
        	set { m_physicalPath = value;}        
        }
		
	    #endregion
		
        #region SwfCreateTime

        private DateTime? m_swfCreateTime;
		
		/// <summary>Gets or sets SwfCreateTime</summary>
        public DateTime? SwfCreateTime {
        	get { return m_swfCreateTime; }
        	set { m_swfCreateTime = value;}        
        }
		
	    #endregion
		
        #region IsConvert

        private Boolean m_isConvert;
		
		/// <summary>Gets or sets IsConvert</summary>
        public Boolean IsConvert {
        	get { return m_isConvert; }
        	set { m_isConvert = value;}        
        }
		
	    #endregion

        public U_UserInfo Uploader { get; set; }
        /// <summary>
        /// 搜索摘要
        /// </summary>
        public string SearchSummary { get; set; }
        /// <summary>
        /// 替换的文档ID
        /// </summary>
        public int? ReplaceDocId { get; set; }
        /// <summary>
        /// 是否马甲用户上传
        /// </summary>
        public bool? IsMajia { get; set; }

        #region 文档转换标识列
        public int Wwk { get; set; }
        public int Wwk2 { get; set; }
        public int Txt { get; set; }
        #endregion

    }

    [Serializable]
    public class DocType
    {
        public string TypeName { get; set; }
        public int TypeId { get; set; }
        public string TypeDesc { get; set; }
    }
}
