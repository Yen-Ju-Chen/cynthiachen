using System;
using System.Collections.Generic;

#nullable disable

namespace NCKU_Model.DBModel
{
    public partial class DataType
    {
        public int DataTypeId { get; set; }
        public string TypeName { get; set; }
        public int Sorting { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUser { get; set; }
        public string IsDelete { get; set; }
    }
}
