using NorthwindSystem.DAL;
using NorthwindSystem.Entities;
using NorthWindSystem.Entities.POCOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity; // for some of the EF extension methods
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindSystem.BLL
{
    // This is the primary public access into the NorthwindSystem's data
    [DataObject]
    public partial class NorthwindManager
    {
        #region Shippers
        public IList<Shipper> ListShippers()
        {
            using (var context = new NWContext())
            {
                return context.Shippers.ToList();
            }
        }

        public Shipper GetShipper(int shipperId)
        {
            using (var context = new NWContext())
            {
                return context.Shippers.Find(shipperId);
            }
        }

        public int AddShipper(Shipper info)
        {
            using (var context = new NWContext())
            {
                context.Shippers.Add(info);
                context.SaveChanges();
                return info.ShipperID;
            }
        }
        
        public void UpdateShipper(Shipper info)
        {
            // NOTE: See question and commentary on
            // http://stackoverflow.com/questions/15336248/entity-framework-5-updating-a-record
            using (var context = new NWContext())
            {
                context.Shippers.Attach(info);
                context.Entry(info).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteShipper(Shipper info)
        {
            using (var context = new NWContext())
            {
                var found = context.Shippers.Find(info.ShipperID);
                if (found != null)
                {
                    context.Shippers.Remove(found);
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Legacy Code
        public List<Employee> GetEmployees()
        {
            using (var context = new NWContext())
            {
                var result = context.Employees;
                return result.ToList();
            }
        }

        // TODO: Create a method called GetOrders() that will return a list of Order objects from the database.
        public List<Order> GetOrders()
        {
            using (var context = new NWContext())
            {
                var result = context.Orders;
                return result.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Region> GetRegions()
        {
            using (var context = new NWContext())
            {
                var result = 
                    context.Regions
                           .Include(item => item.Territories)
                           .OrderBy(item => item.RegionDescription);

                return result.ToList();
            }
        }

        #endregion
    }
}

/* NOTE:    Important Footnotes !! KEEP
 * 
 * ==============================================================================================================
 * 1) Having a problem with casting float to decimal in L2E:
 *      "Casting to Decimal is not supported in LINQ to Entities queries, 
 *       because the required precision and scale information cannot be inferred."
 *  Cast is happening in the generated query, not in memory. It looks like I might have to
 *  create a function on the data model or something to handle this.
 *  
 *  BTW:
 *  It's necessary to calculate discounts applied on a row-by-row basis BEFORE doing a sum
 *  in order to get the correct amount.
 *  (e.g.:  You get a different calculation if you sum before multiplying:
 *          5 items X $ 10.00  = $ 50.00
 *        +
 *          2 items X $  0.50  = $  1.00
 *          ----------------------------
 *                             = $ 51.00    <== CORRECT answer
 *                             
 *     vs.
 *          5 items X $ 10.00
 *        +
 *          2 items X $  0.50
 *          ----------------------------
 *          7 items X $ 10.50   = $ 73.50   <== WRONG answer
 *  )
 * ==============================================================================================================
 * 
 * 2) Fixed error: 
 *    "Casting to Decimal is not supported in LINQ to Entities queries, because the required precision and scale information cannot be inferred."
 *    Solution was not to cast, but to -truncate- through integer conversion and then cast to decimal. In other words, use
 *        (((decimal)((int)(x.Discount * 100))) / 100)
 *    instead of
 *        (decimal)x.Discount
 *    It produces terrible SQL, like this:
 *        ( CAST(  CAST( [Extent4].[Discount] * cast(100 as real) AS int) AS decimal(19,0)) / cast(100 as decimal(18)))
 *    But, it does produce the correct results, and keeps the aggregation on the database server rather than pulling all
 *    the Order_Details into memory to aggregate locally (which can be a heavy strain in a system with a lot more product sales).
 * ==============================================================================================================
 *    
 */