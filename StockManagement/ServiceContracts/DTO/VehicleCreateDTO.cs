using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class VehicleCreateDTO
    {
        [StringLength(30)]
        public string? Type { get; set; }
        [StringLength(7)]
        public string? Plate { get; set; }
        public int OwnerID { get; set; }

        public Vehicle ToVehicle()
        {
            return new Vehicle()
            {
                Type = Type,
                Plate = Plate,
                OwnerID = OwnerID
            };
        }
    }
}
