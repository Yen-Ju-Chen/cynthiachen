using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKU_Model.DBModel
{
    public partial class NCKUContext : DbContext
    {
        public KeyValuePair<bool, string> NewSaveChanges()
        {
            var dic = new Dictionary<bool, string>();
            try
            {
                var res = base.SaveChanges();
                dic.Add(true, "");
                return dic.FirstOrDefault();
            }
            catch (Exception ex)
            {
                dic.Add(false, ex.Message + ex.InnerException?.Message);
                return dic.FirstOrDefault();
            }

        }
    }
}
