using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindSystem.Entities.DTO
{
    [Serializable]
    public class ShipperDTO
    {
        public ShipperDTO()
        {
        }
        public ShipperDTO(Shipper info)
        {
            ShipperID = info.ShipperID;
            CompanyName = info.CompanyName;
            Phone = info.Phone;
        }
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public Shipper ToShipper()
        {
            return new Shipper()
            {
                ShipperID = ShipperID,
                CompanyName = CompanyName,
                Phone = Phone
            };
        }
    }
}
