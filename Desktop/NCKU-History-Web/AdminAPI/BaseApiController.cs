using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NCKU_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NCKU_History.AdminAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        #region Api回傳格式共用
        /// <summary>
        /// 成功回傳
        /// </summary>
        /// <param name="msg">訊息</param>
        /// <param name="dt">資料
        /// </param>
        /// <returns></returns>
        protected IActionResult WriteJsonOk(string msg, object dt = null)
        {
            return Ok(new
            {
                isOk = true,
                msg,
                dt
            });
        }
        /// <summary>
        /// 失敗回傳
        /// </summary>
        /// <param name="msg">訊息</param>
        ///<param name="dt">資料</param>
        /// <returns></returns>
        protected IActionResult WriteJsonErr(string msg, object dt = null)
        {
            return Ok(new
            {
                isOk = false,
                msg,
                dt
            });
        }

        #endregion

        /// <summary>
        /// Model 驗證回傳
        /// </summary>
        /// <returns></returns>
        protected IActionResult ModelValidate()
        {
            var errmsg = string.Join("<br>", ModelState.Values.SelectMany(v => v.Errors)
                                                             .Select(e => e.ErrorMessage));
            return WriteJsonErr(errmsg);
        }

        protected JWTInfo JwtInfo()
        {
            var id = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier)
                                            .FirstOrDefault().Value;
            var email = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Email)
                                            .FirstOrDefault().Value;
            var name = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Name)
                                            .FirstOrDefault().Value;
            var role = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role)
                                                .FirstOrDefault().Value;
            return new JWTInfo
            {
                Id = int.Parse(id),
                Email = email,
                Name = name,
                Role = role
            };
        }
    }
}
