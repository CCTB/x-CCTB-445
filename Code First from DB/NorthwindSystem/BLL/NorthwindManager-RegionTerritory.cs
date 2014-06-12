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
        #region Region and Territory Entities
        #region Command Methods
        public int Add(Region region)
        {
            // TODO: Add Unit Test
            if (region == null)
                throw new ArgumentNullException("region", "region is null.");
            using (var dbContext = new NWContext())
            {
                /* NOTE:
                 *  The TerritoryID column in Territories is a string - nvarchar(20) - rather than an integer.
                 *  The existing data in Northwind Traders uses the zip code of the city/town as the TerritoryID.
                 *  This sample just "simplifies" and assigns the territory description as the ID, since we're
                 *  in Canada and we aren't using a single zip or postal code.
                 */
                foreach (var territory in region.Territories)
                    if (string.IsNullOrEmpty(territory.TerritoryID))
                        territory.TerritoryID = territory.TerritoryDescription;

                /* NOTE:
                 *  The RegionID column in Regions is an integer, but it is not an IDENTITY column.
                 *  As such, we're simply going to get the next highest ID available.
                 */
                if (region.RegionID <= 0)
                    region.RegionID = dbContext.Regions.Max(item => item.RegionID) + 1;

                dbContext.Regions.Add(region);

                dbContext.SaveChanges();

                return region.RegionID;
            }
        }

        public void Update(Region region, List<Territory> territories)
        {
            // TODO: Add Unit Test
            if (region == null)
                throw new ArgumentNullException("region", "region is null.");
            if (territories == null)
                throw new ArgumentNullException("territories", "territories is null.");

            using (var dbContext = new NWContext())
            {
                foreach (var item in territories)
                {
                    var found = dbContext.Territories.Find(item.TerritoryID);
                    if (found != null)
                    {
                        /* NOTE:
                         *  Pre-process the Territory IDs to see if they should be "synced" with the name/description.
                         *  This will be the case if, in the original, the ID was the same as the description
                         */
                        string foundTerritoryID = found.TerritoryID;
                        string foundTerritoryDescription = found.TerritoryDescription.Trim(); // HACK: Turns out, the column is nchar(50), not an nvarchar....
                        string itemTerritoryID = item.TerritoryID;
                        string itemTerritoryDescription = item.TerritoryDescription.Trim();
                        if (foundTerritoryID.Equals(foundTerritoryDescription) &&
                            !itemTerritoryID.Equals(itemTerritoryDescription))
                        {
                            item.TerritoryID = itemTerritoryDescription;
                            dbContext.Territories.Remove(found); // Because the PK has changed...
                            dbContext.Territories.Add(item); // Because the PK has changed...
                        }
                    }
                }

                dbContext.Entry(region).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region Query Methods
        // TODO: Move the GetRegions method to here from #region Legacy Code....
        #endregion
        #endregion
    }
}
