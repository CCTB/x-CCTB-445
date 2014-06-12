using NorthwindSystem.BLL;
using NorthwindSystem.Entities;
using NorthwindSystem.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

/// <summary>
/// Summary description for ShipperController
/// </summary>
public class ShipperController : ApiController
{
    #region Constructor + Properties
    private NorthwindManager Northwind { get; set; }
    public ShipperController()
    {
        Northwind = new NorthwindManager();
    }
    #endregion

    // GET api/<controller>
    public IEnumerable<ShipperDTO> Get()
    {
        var result = new List<ShipperDTO>();
        foreach (var item in Northwind.ListShippers())
            result.Add(new ShipperDTO(item));
        return result;
    }

    // GET api/<controller>/5
    public Shipper Get(int id)
    {
        return Northwind.GetShipper(id);
    }

    // DELETE api/<controller>
    public void Post([FromBody] ShipperDTO value)
    {
        Northwind.AddShipper(value.ToShipper());
    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody] ShipperDTO value)
    {
        value.ShipperID = id;
        Northwind.UpdateShipper(value.ToShipper());
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
        Northwind.DeleteShipper(new Shipper() { ShipperID = id });
    }
}