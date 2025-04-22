using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class ServiceOrderUpdateDTO
    {
        public int ID { get; set; }
        [Range(1, 10000, ErrorMessage = "O valor total deve ser um número entre 1 e 100000")]
        public float TotalProductValue { get; set; }
        [Range(1, 10000, ErrorMessage = "O valor de mão de obra deve ser um número entre 1 e 10000")]
        public float TotalLabor { get; set; }
        [StringLength(255)]
        public string? Description { get; set; }
        public DateTime ServiceDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int VehicleID { get; set; }
        public VehicleDTO? Vehicle { get; set; }

        public List<ServiceItemUpdateDTO> ServiceItems { get; set; } = new List<ServiceItemUpdateDTO>();

        public ServiceOrder ToServiceOrder()
        {
            return new ServiceOrder()
            {
                ID = ID,
                TotalProductValue = TotalProductValue,
                TotalLabor = TotalLabor,
                Description = Description,
                ServiceDate = ServiceDate,
                RegistrationDate = RegistrationDate,
                VehicleID = VehicleID
            };
        }
    }
}
