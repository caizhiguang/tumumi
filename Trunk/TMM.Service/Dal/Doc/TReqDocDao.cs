﻿//==============================================================================
//	CAUTION: This file is generated by IBatisNetGen.DaoImpl.cst at 2011-1-24 8:51:45
//				By xincai.wu
//==============================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMM.Model;
using TMM.Persistence;


namespace TMM.Service.Dal.Doc
{

    /// <summary>
    /// 名称：TReqDocDao 数据层
    /// 开发者：
    /// 创建时间：2011-1-23 16:19:00
    /// 功能描述：
    /// </summary>
    public partial class TReqDocDal
    {

        /// <summary>
        /// 取得记录数
        /// </summary>
        /// <param name="param">可选参数为：</param>
        /// <returns></returns>
        public int GetCount(Hashtable param)
        {
            if (param == null)
                param = new Hashtable();

            String stmtId = "TReqDoc.GetCount";
            return SqlMapper.Instance().QueryForObject<int>(stmtId, param);
        }

        /// <summary>
        /// 提取数据
        /// </summary>
        /// <param name="param">可选参数为：</param>
        /// <param name="orderBy">排序方式:默认为“TId asc”</param>
        /// <param name="first">起始记录：从0开始</param>
        /// <param name="rows">提取的条数</param>
        /// <returns></returns>
        public IList<TReqDoc> GetList(Hashtable param, string orderBy, int first, int rows)
        {
            if (param == null)
                param = new Hashtable();

            param.Add("Top", first + rows);
            param.Add("StartRecord", first);

            if (string.IsNullOrEmpty(orderBy))
                param.Add("OrderBy", "TId desc");
            else
                param.Add("OrderBy", orderBy);

            String stmtId = "TReqDoc.GetList";
            return SqlMapper.Instance().QueryForList<TReqDoc>(stmtId, param);
        }

        /// <summary>
        /// 提取数据
        /// </summary>
        /// <param name="tId"></param>
        /// <returns></returns>
        public TReqDoc Get(Int32 tId)
        {
            String stmtId = "TReqDoc.Get";
            return SqlMapper.Instance().QueryForObject<TReqDoc>(stmtId, tId);
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>返回：该条数据的主键Id</returns>
        public int Insert(TReqDoc obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "TReqDoc.Insert";
            return SqlMapper.Instance().QueryForObject<int>(stmtId, obj);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>返回：ture 成功，false 失败</returns>
        public bool Update(TReqDoc obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "TReqDoc.Update";
            int result = SqlMapper.Instance().QueryForObject<int>(stmtId, obj);
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="tId"></param>
        /// <returns>返回：ture 成功，false 失败</returns>
        public bool Delete(Int32 tId)
        {
            String stmtId = "TReqDoc.Delete";
            int result = SqlMapper.Instance().QueryForObject<int>(stmtId, tId);
            return result > 0 ? true : false;
        }

    }

}