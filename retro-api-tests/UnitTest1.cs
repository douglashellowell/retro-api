using System;
using Microsoft.EntityFrameworkCore;
using Moq;
using retro_api;
using retro_api.Interfaces;
using retro_api.Models;
using Xunit;

namespace retro_api_tests
{
    public class HousesModelTests
    {
        public Mock<IPotterContext> _testPotterContext;
        public HouseModel _houseModel;

        public HousesModelTests()
        {
            _testPotterContext = new Mock<IPotterContext>();
            _houseModel = new HouseModel(_testPotterContext.Object);
        }

        [Fact]
        public void GetAllHouses()
        {
            // arrange
            var dbSet = new Mock<DbSet<House>>();
      
            //_testPotterContext.Setup(obj => obj.houses).Returns(new DbSet()); ;
            // MOQ
            // verify
            // _testPotterContext.setup()

            // act


            // assert
        }


    }
}
