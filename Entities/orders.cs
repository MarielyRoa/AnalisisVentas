using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readcsv.Class
{
    public class orders
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        [CsvHelper.Configuration.Attributes.Ignore]
        [Column(TypeName = "decimal(10,2)")]
        public Decimal Total { get; set; }
    }
}
