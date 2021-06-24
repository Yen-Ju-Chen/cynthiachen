using System;
using System.Collections.Generic;

#nullable disable

namespace NCKU_Model.DBModel
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public int AdminGroupId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUser { get; set; }
        public string IsDelete { get; set; }
    }
}
