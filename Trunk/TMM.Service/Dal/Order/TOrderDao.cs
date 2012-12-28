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


namespace TMM.Service.Dal.Order
{

	/// <summary>
    /// 名称：TOrderDao 数据层
    /// 开发者：
    /// 创建时间：2011-1-9 11:03:46
    /// 功能描述：
    /// </summary>
    public partial class TOrderDal {

		/// <summary>
        /// 取得记录数
        /// </summary>
        /// <param name="param">可选参数为：</param>
        /// <returns></returns>
		public int GetCount(Hashtable param) {
			if (param == null)
                param = new Hashtable();
				
			String stmtId = "TOrder.GetCount";
			return SqlMapper.Instance().QueryForObject<int>(stmtId, param);
		}

		/// <summary>
        /// 提取数据
        /// </summary>
        /// <param name="param">可选参数为：</param>
        /// <param name="orderBy">排序方式:默认为“OrderId asc”</param>
        /// <param name="first">起始记录：从0开始</param>
        /// <param name="rows">提取的条数</param>
        /// <returns></returns>
		public IList<TOrder> GetList(Hashtable param,string orderBy,int first,int rows) 
		{
			if (param == null)
                param = new Hashtable();

            param.Add("Top", first+ rows);
            param.Add("StartRecord", first);

            if (string.IsNullOrEmpty(orderBy))
                param.Add("OrderBy", "CreateTime DESC");
			else
                param.Add("OrderBy", orderBy);
				
			String stmtId = "TOrder.GetList";
			return SqlMapper.Instance().QueryForList<TOrder>(stmtId, param);
		}
        /// <summary>
        /// 最近兑换列表
        /// </summary>
        /// <param name="first"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public IList<TOrder> GetListForExchange(int first, int rows) {
            Hashtable p = new Hashtable();
            p.Add("Top", first + rows);
            p.Add("StartRecord", first);
            p.Add("OrderBy", "OrderId DESC");

            p.Add("OrderType",(int)OrderType.Exchange);
            String stmtId = "TOrder.GetListForExchange";
            return SqlMapper.Instance().QueryForList<TOrder>(stmtId, p);
        }
		/// <summary>
        /// 提取数据
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
		public TOrder Get(Decimal orderId) {
			String stmtId = "TOrder.Get";
			return SqlMapper.Instance().QueryForObject<TOrder>(stmtId, orderId);
		}
        

		/// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>返回：该条数据的主键Id</returns>
		public void Insert(TOrder obj) {
			if (obj == null) throw new ArgumentNullException("obj");
			String stmtId = "TOrder.Insert";
            SqlMapper.Instance().Insert(stmtId, obj);
		}
		
		/// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>返回：ture 成功，false 失败</returns>
		public bool Update(TOrder obj) {
			if (obj == null) throw new ArgumentNullException("obj");
			String stmtId = "TOrder.Update";
			int result = SqlMapper.Instance().QueryForObject<int>(stmtId, obj);
			return result > 0 ? true : false;
		}
		
		/// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>返回：ture 成功，false 失败</returns>
		public bool Delete(Decimal orderId) {
			String stmtId = "TOrder.Delete";
			int result = SqlMapper.Instance().QueryForObject<int>(stmtId, orderId);
			return result > 0 ? true : false;
		}

        public bool UpdateState2Paid(decimal orderid, int status, int payway, string PayWayDetail)
        {
            String stmtId = "TOrder.UpdateState2Paid";
            Hashtable p = new Hashtable();
            p.Add("OrderId", orderid);
            p.Add("State", status);
            p.Add("PayWay", payway);
            p.Add("PayWayDetail", PayWayDetail);
            int result = SqlMapper.Instance().Update(stmtId, p);
            return result > 0;
        }
	}

}