using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.Entities
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("order_list")]
        public string OrderList { get; set; }

        [Column("order_price")]
        public int OrderPrice { get; set; }
        [Column("order_date")]
        public string OrderDate { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
