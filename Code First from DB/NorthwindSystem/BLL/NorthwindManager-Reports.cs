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
    public partial class NorthwindManager
    {
        #region Queries for Reports
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Thanks to Matteo Tontini's bloq post "Linq To Entities:  Queryable.Sum returns Null on an empty list".
        /// <see cref="http://ilmatte.wordpress.com/2012/12/20/queryable-sum-on-decimal-and-null-return-value-with-linq-to-entities/"/>
        /// Also, see the FootNotes at the end of NorthwindManager.cs for more info on issues around the
        /// Linq-to-Entities query used inside this method.
        /// </remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CustomerOrderSummary> GetCustomerOrderSummaries()
        {
            var dbContext = new NWContext();
            var data = (from purchase in dbContext.Orders
                        where purchase.OrderDate.HasValue
                        select new CustomerOrderSummary()
                        {
                            OrderDate = purchase.OrderDate.Value,
                            // see http://blog.dreamlabsolutions.com/post/2008/11/17/LINQ-Method-cannot-be-translated-into-a-store-expression.aspx
                            Freight = purchase.Freight ?? 0m, // purchase.Freight.GetValueOrDefault(),
                            Subtotal = purchase.Order_Details
                                               .Sum(x =>
                                                    (decimal?)(x.UnitPrice * x.Quantity)
                                                    ) ?? 0,                                       // NOTE: See Footnote 1
                            Discount = purchase.Order_Details
                                               .Sum(x =>
                                                    x.UnitPrice * x.Quantity *
                                                    (((decimal)((int)(x.Discount * 100))) / 100) // NOTE: See Footnote 2
                                                    ),
                            Total = purchase.Order_Details.Sum(x => (x.UnitPrice * x.Quantity) -
                                                                    (x.UnitPrice * x.Quantity *
                                                                     (((decimal)((int)(x.Discount * 100))) / 100) // NOTE: See Footnote 2
                                                                    )
                                                               ),
                            ItemCount = purchase.Order_Details.Count(),
                            ItemQuantity = purchase.Order_Details.Sum(x => (short?)x.Quantity) ?? 0,
                            AverageItemUnitPrice = purchase.Order_Details.Average(x => (decimal?)x.UnitPrice) ?? 0,
                            CompanyName = purchase.Customer.CompanyName,
                            ContactName = purchase.Customer.ContactName,
                            ContactTitle = purchase.Customer.ContactTitle,
                            CustomerId = purchase.CustomerID
                        }).ToList();
            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Thanks to Matteo Tontini's bloq post "Linq To Entities:  Queryable.Sum returns Null on an empty list".
        /// <see cref="http://ilmatte.wordpress.com/2012/12/20/queryable-sum-on-decimal-and-null-return-value-with-linq-to-entities/"/>.
        /// Also, see the FootNotes at the end of NorthwindManager.cs for more info on issues around the
        /// Linq-to-Entities query used inside this method.
        /// </remarks>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ProductSaleSummary> GetProductSaleSummaries()
        {
            // NOTE: See Footnote 1
            // NOTE: See Footnote 2
            var dbContext = new NWContext();
            var data =
                (from item in dbContext.Products
                 where !item.Discontinued
                 select new ProductSaleSummary()
                 {
                     TotalSales = item.Order_Details.Sum(x => (decimal?)(x.UnitPrice * x.Quantity)) ?? 0,  // NOTE: See Footnote 1
                     TotalDiscount = item.Order_Details
                                     .Sum(x => (decimal?)
                                                 (x.UnitPrice * x.Quantity *
                                                 (((decimal)((int)(x.Discount * 100))) / 100)               // NOTE: See Footnote 2
                                                 )) ?? 0,
                     SaleCount = item.Order_Details.Count(),
                     SaleQuantity = item.Order_Details.Sum(x => (short?)x.Quantity) ?? 0,
                     AverageUnitPrice = item.Order_Details.Average(x => (decimal?)x.UnitPrice) ?? 0,
                     ProductName = item.ProductName,
                     QuantityPerUnit = item.QuantityPerUnit,
                     UnitsInStock = item.UnitsInStock.HasValue ?
                                     item.UnitsInStock.Value : (short)0,
                     UnitsOnOrder = item.UnitsOnOrder.HasValue ?
                                     item.UnitsOnOrder.Value : (short)0,
                     ReorderLevel = item.ReorderLevel.HasValue ?
                                     item.ReorderLevel.Value : (short)0,
                     Discontinued = item.Discontinued,
                     CurrentUnitPrice = item.UnitPrice.HasValue ?
                                     item.UnitPrice.Value : 0,
                     CategoryId = item.CategoryID.HasValue ?
                                     item.CategoryID.Value : 0,
                     ProductId = item.ProductID
                 }).ToList();

            var dbInventoryContext = new NWContext();
            foreach (var item in data)
                if (item.CategoryId > 0)
                    item.CategoryName = dbInventoryContext.Categories.Find(item.CategoryId).CategoryName;
            return data;
        }
        #endregion
    }
}
