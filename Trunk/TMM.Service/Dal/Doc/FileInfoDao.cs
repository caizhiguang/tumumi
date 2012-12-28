﻿//==============================================================================
//	CAUTION: This file is generated by IBatisNetGen.DaoImpl.cst at 2010-12-17 22:06:26
//				By xincai.wu
//==============================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMM.Model;
using TMM.Persistence;


namespace TMM.Service.Dal.Doc {

	/// <summary>
    /// 名称：FileInfoDao 数据层
    /// 开发者：
    /// 创建时间：2010-11-29 19:03:15
    /// 功能描述：
    /// </summary>
    public partial class FileInfoDal {

		/// <summary>
        /// 取得记录数
        /// </summary>
        /// <param name="param">可选参数为：</param>
        /// <returns></returns>
		public int GetCount(Hashtable param) {
			if (param == null)
                param = new Hashtable();
				
			String stmtId = "FileInfo.GetCount";
			return SqlMapper.Instance().QueryForObject<int>(stmtId, null);
		}

		/// <summary>
        /// 提取数据
        /// </summary>
        /// <param name="param">可选参数为：</param>
        /// <param name="orderBy">排序方式:默认为“Id asc”</param>
        /// <param name="first">起始记录：从0开始</param>
        /// <param name="rows">提取的条数</param>
        /// <returns></returns>
		public IList<FileInfo> GetList(Hashtable param,string orderBy,int first,int rows) 
		{
			if (param == null)
                param = new Hashtable();

            param.Add("Top", first+ rows);
            param.Add("StartRecord", first);

            if (string.IsNullOrEmpty(orderBy))
                param.Add("OrderBy", "Id asc");
			else
                param.Add("OrderBy", orderBy);
				
			String stmtId = "FileInfo.GetList";
			return SqlMapper.Instance().QueryForList<FileInfo>(stmtId, param);
		}
		
		/// <summary>
        /// 提取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public FileInfo Get(Int32 id) {
			String stmtId = "FileInfo.Get";
			return SqlMapper.Instance().QueryForObject<FileInfo>(stmtId, id);
		}

		/// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>返回：该条数据的主键Id</returns>
		public int Insert(FileInfo obj) {
			if (obj == null) throw new ArgumentNullException("obj");
			String stmtId = "FileInfo.Insert";
			return SqlMapper.Instance().QueryForObject<int>(stmtId, obj);
		}
		
		/// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>返回：ture 成功，false 失败</returns>
		public bool Update(FileInfo obj) {
			if (obj == null) throw new ArgumentNullException("obj");
			String stmtId = "FileInfo.Update";
			int result = SqlMapper.Instance().QueryForObject<int>(stmtId, obj);
			return result > 0 ? true : false;
		}
		
		/// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns>返回：ture 成功，false 失败</returns>
		public bool Delete(Int32 id) {
			String stmtId = "FileInfo.Delete";
			int result = SqlMapper.Instance().QueryForObject<int>(stmtId, id);
			return result > 0 ? true : false;
		}
		
	}

}