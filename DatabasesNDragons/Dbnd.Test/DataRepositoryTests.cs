using System;
using System.Collections.Generic;
using System.Text;
using Dbnd.Data.Repository;
using Xunit;
using Moq;

namespace Dbnd.Test
{
    class DataRepositoryTests
    {
        // Example Usage of Moq data to Unit test repository use
        //[Fact]
        //public void MethodToTestFromAControllerNotNull()
        //{
        //    var listOfGames = new List<Dbnd.Logic.Objects.Game>();
        //    listOfGames.Add(new Dbnd.Logic.Objects.Game() 
        //    { 
        //        GameName = "EyeOfTheBeHolder",
        //        DungeonMasterID = Guid.NewGuid()
        //    });
        //    listOfGames.Add(new Dbnd.Logic.Objects.Game()
        //    {
        //        GameName = "NeverwinterNights",
        //        DungeonMasterID = Guid.NewGuid()
        //    });
            //    Mock<Repository> mockRepository = new Mock<Repository>();
            //    mockRepository.Setup(x => x.GetAllGamesByDungeonMasterID(Guid.NewGuid())).Returns(listOfGames);
            //    var someController = new SomeController(mockRepository.Object);
            //    var test = bandController.MethodToTest();
            //    Assert.NotNull(test);
            //    Assert.Equals(expected, outcome); etc...
        //}
    }
}
