using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindSystem.BLL; // for access to my system
using NorthwindSystem.Entities; // for my EF entities
using Xunit; // the core for testing
using Xunit.Extensions; // for Theories, AutoRollback, etc.

namespace NorthwindSystem.Requirements.UnitTests.CRUD
{
    public class CRUD_Shipper
    {
        [Fact]
        public void Should_Add_Numbers()
        {
            // Arrange
            int first = 5, second = 7;
            // Act
            int actual = first + second;

            // Assert
            Assert.Equal(12, actual);
        }

        [Fact] // indicates that this is a test
        [AutoRollback] // undo database changes after the test
        public void Should_Add_Shipper()
        {
            // Arrange
            var sut = new NorthwindManager(); // sut is short for "Situation Under Test"
            var expected = new Shipper()
            {
                CompanyName = "Montgomery Scott's Transporter Service",
                Phone = "780.555.1212"
            };

            // Act
            var actualId = sut.AddShipper(expected);

            // Asssert
            Assert.True(actualId > 0);
            Shipper actual = sut.GetShipper(actualId);
            Assert.Equal(expected.CompanyName, actual.CompanyName);
            Assert.Equal(expected.Phone, actual.Phone);
            Assert.Equal(actualId, actual.ShipperID);
        }

        #region Properties for Test Data
        // backing field
        private static IEnumerable<object[]> _CurrentShippers = null;
        public static IEnumerable<object[]> CurrentShippers
        {
            get
            {
                if (_CurrentShippers == null) // lazy-loading
                {
                    var controller = new NorthwindManager();
                    var temp = new List<object[]>(); // empty list
                    foreach (Shipper company in controller.ListShippers())
                    {
                        temp.Add(new object[] { company });
                    }
                    _CurrentShippers = temp;
                }
                return _CurrentShippers;
            }
        }
        #endregion

        [Theory] // indicates that this is a test with (potentially) external data
        [PropertyData("CurrentShippers")]
        [AutoRollback]
        public void Should_Update_Shipper(Shipper existing)
        {
            // Arrange
            existing.Phone = "780.999.9999";
            var sut = new NorthwindManager();

            // Act
            sut.UpdateShipper(existing);

            // Assert
            var actual = sut.GetShipper(existing.ShipperID);
            Assert.NotNull(actual);
            Assert.Equal(existing.Phone, actual.Phone);
            Assert.Equal(existing.CompanyName, actual.CompanyName);
        }


        [Fact] // indicates that this is a test
        [AutoRollback] // undo database changes after the test
        public void Should_Delete_Shipper()
        {
            // Arrange
            var sut = new NorthwindManager(); // sut is short for "Situation Under Test"
            var expected = new Shipper()
            {
                CompanyName = "Montgomery Scott's Transporter Service",
                Phone = "780.555.1212"
            };
            expected.ShipperID = sut.AddShipper(expected);

            // Act
            sut.DeleteShipper(expected);

            // Asssert
            Shipper actual = sut.GetShipper(expected.ShipperID);
            Assert.Null(actual);
        }
    }
}
