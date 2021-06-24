using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKU_Model
{
    public class QueryInfo
    {
        /// <summary>
        /// 查詢條件
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 查詢條件
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 啟用狀態
        /// </summary>
        public string Status { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 分頁
        /// </summary>
        public Page Page { get; set; }
    }
}



