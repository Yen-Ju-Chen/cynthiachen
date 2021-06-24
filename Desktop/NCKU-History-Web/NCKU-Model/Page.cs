using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKU_Model
{
    public class Page
    {
        //  總筆數
        public int Total { get; set; }
        //  當前頁數
        public int Current { get; set; }
        //  每頁數量
        public int Size { get; set; }
        //  預設下拉頁數
        public List<int> Option { get; set; }
    }
}
