using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NCKU_Common;
using NCKU_Model;
using NCKU_Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NCKU_History.AdminAPI
{
    /// <summary>
    /// 資料類型
    /// </summary>
    public class DataTypeController : BaseApiController
    {
        private readonly ILogger<DataTypeController> _logger;

        private NCKUContext _nCKUContext;

        public DataTypeController(ILogger<DataTypeController> logger, NCKUContext nCKUContext)
        {
            _logger = logger;
            _nCKUContext = nCKUContext;
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Query([FromBody] QueryInfo cond)
        {
            var res = _nCKUContext.DataTypes.Where(x => x.IsDelete== DeleteType.NotYet);
            // 依條件篩選
            if (!string.IsNullOrEmpty(cond.Name))
            {
                res = res.Where(x => x.TypeName == cond.Name);
            }
            if (!string.IsNullOrEmpty(cond.Status))
            {
                res = res.Where(x => x.Status == cond.Status);
            }
            // 排序
            res = res.OrderBy(x => x.Sorting);

            return res.Any()
               ? WriteJsonOk("", PageHelper.Getbypage(res, cond.Page))
               : WriteJsonErr("找不到相關條件資料");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult QueryDetail([FromQuery]int? id)
        {
            if (id == null || id == 0)            
                return WriteJsonErr("取得編輯資料失敗:請傳入正確Id");
            
            var info = _nCKUContext.DataTypes.FirstOrDefault(x => x.DataTypeId == id);

            return info != null
               ? WriteJsonOk("", info)
               : WriteJsonErr("取得編輯資料失敗:查無資料");

        }

        /// <summary>
        /// 新增/更新
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateDataType([FromBody] DataType model)
        {
            // 基本資料驗證
            if (ModelState.IsValid)
            {
                return ModelValidate();
            }
            string type;
            // 無key值=>新增
            if (model.DataTypeId == 0)
            {
                type = "新增";
                model.CreateUser = JwtInfo().Id;
                model.CreateDate = DateTime.Now;
                model.UpdateUser = JwtInfo().Id;
                model.UpdateDate = DateTime.Now;
                model.IsDelete = DeleteType.NotYet;
                _nCKUContext.DataTypes.Add(model);
            }
            else
            {
                type = "編輯";
                model.UpdateUser = JwtInfo().Id;
                model.UpdateDate = DateTime.Now;
                _nCKUContext.DataTypes.Update(model);
            }
            var resSvae = _nCKUContext.NewSaveChanges();

            return resSvae.Key
               ? WriteJsonOk($"{type}資料型態:成功")
               : WriteJsonErr($"{type}資料型態:失敗");
        }

         
        
    }
}
