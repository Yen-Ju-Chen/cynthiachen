using System;
using System.Collections.Generic;

#nullable disable

namespace NCKU_Model.DBModel
{
    public partial class AdminGroup
    {
        public int AdminGroupId { get; set; }
        public string GroupName { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUser { get; set; }
    }
}
