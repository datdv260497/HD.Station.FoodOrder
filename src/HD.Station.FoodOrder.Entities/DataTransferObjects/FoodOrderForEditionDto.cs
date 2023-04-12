using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.Station.FoodOrder.EF.DataTransferObjects
{
    public class FoodOrderForEditionDto
    {
        public FoodOrderForEditionDto() { }
        public FoodOrderForEditionDto(Entities.Models.FoodOrder model)
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

        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public int Quantity { get; set; }
        public string? Note { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset OrderedTime { get; set; }
        public DateTimeOffset CanceledTime { get; set; }


        public Entities.Models.FoodOrder ToEntity()
        {
            return new Entities.Models.FoodOrder()
            {
                Id = Id,
                EmployeeId = EmployeeId,
                Quantity = Quantity,
                Note = Note,
                CreatedDateTime = CreatedDateTime,
                OrderedTime = OrderedTime,
                CanceledTime = CanceledTime
            };
        }
    }
}
