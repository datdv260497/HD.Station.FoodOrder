using HD.Station.FoodOrder.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.Station.FoodOrder.Entities.DataTransferObjects
{
    public class FoodOrderDto
    {
        public FoodOrderDto(Entities.Models.FoodOrder model)
        {
            if (model != null)
            {
                Id = model.Id;
                EmployeeId = model.EmployeeId;
                Quantity = model.Quantity;
                Note = model.Note;
                CreatedDateTime = model.CreatedDateTime;
                OrderedTime = model.OrderedTime;
                CanceledTime = model.CanceledTime;
            }
        }
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public int Quantity { get; set; }
        public string? Note { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset OrderedTime { get; set; }
        public DateTimeOffset CanceledTime { get; set; }
    }
}
