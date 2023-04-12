using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.Station.FoodOrder.Entities.Models
{
    [Table("FoodOrder")]
    public class FoodOrder
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public int Quantity { get; set; }
        public string? Note { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset OrderedTime { get; set; }
        public DateTimeOffset CanceledTime { get; set; }
    }
}
