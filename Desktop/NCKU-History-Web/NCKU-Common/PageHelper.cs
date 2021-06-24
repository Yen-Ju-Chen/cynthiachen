using NCKU_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKU_Common
{
    public static class PageHelper
    {
        public static object Getbypage(IQueryable<object> res, Page page)
        {
            page.Total = res.Count();
            return new
            {
                val = res.Skip((page.Current - 1) * page.Size).Take(page.Size),
                page = page
            };
        }
    }
}
