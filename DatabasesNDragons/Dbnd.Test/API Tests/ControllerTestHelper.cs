using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dbnd.Api;
using Dbnd.Api.Controllers;
using Dbnd.Logic.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Dbnd.Test.API_Tests
{
    class ControllerTestHelper
    {
        public Mock<Dbnd.Logic.Interfaces.IRepository> Repository { get; private set; }
        public Mock<IAuthorizer> Authorizer { get; private set; }
        public ClientController ClientController { get; private set; }
        public List<Client> Clients { get; private set; }
        public List<Game> Games { get; private set; }

        public ControllerTestHelper()
        {
            SetUpClients();
            SetUpGames(Clients);
            SetUpMocks();
        }

        private void SetUpClients()
        {
            Clients = new List<Client>
            {
                new Client
                {
                    UserName = "Jacob",
                    Email = "jacobs.email@email.com",
                    ClientID = new Guid("518b9a19-bd55-4497-a01f-2e48f23d8d30"),
                    Characters = new List<Character>
                    {
                        new Logic.Objects.Character()
                        {
                            CharacterID = new Guid("d9beb26e-11e5-490f-a27f-1467ac5d6a68"),
                            ClientID = new Guid("518b9a19-bd55-4497-a01f-2e48f23d8d30"),
                            FirstName = "Willy",
                            LastName = "Wonka"
                        }
                    }
                },
                new Client
                {
                    UserName = "KC",
                    Email = "kcs.email@email.com",
                    ClientID = new Guid("01eec648-89c6-4324-a732-165adcd430c6"),
                    Characters = new List<Character>
                    {
                        new Logic.Objects.Character()
                        {
                            ClientID = new Guid("01eec648-89c6-4324-a732-165adcd430c6"),
                            FirstName = "Skip",
                            LastName = "Donahue"
                        }
                    }
                },
                new Client
                {
                    UserName = "Shawn",
                    Email = "shawns.email@email.com",
                    ClientID = new Guid("174e181b-f482-4a77-a2c3-734c494616fa"),
                    Characters = new List<Character>
                    {
                        new Dbnd.Logic.Objects.Character()
                        {
                            ClientID = new Guid("174e181b-f482-4a77-a2c3-734c494616fa"),
                            FirstName = "Leo",
                            LastName = "Bloom"
                        }
                    }
                }
            };
        }

        private void SetUpGames(List<Client> testClients)
        {
            Games = new List<Logic.Objects.Game>
            {
                new Logic.Objects.Game()
                {
                    GameName = "EyeOfTheBeHolder",
                    ClientID = testClients[0].ClientID,
                    GameID = new Guid("32f71873-125e-46b3-ade7-17b3e4fb936b"),
                    Characters = new List<Character>()
                    {
                        testClients[1].Characters[0]
                    },
                    Overviews = new List<Overview>()
                    {
                        new Overview(new Guid("32f71873-125e-46b3-ade7-17b3e4fb936b"), "test1", "Eye of the Besucker, more like."),
                        new Overview(new Guid("32f71873-125e-46b3-ade7-17b3e4fb936b"), "test2", "The Eye of the Beholder is a spooky eyeball monster from the sewers of Neverweiner.")
                    }
                },
                new Logic.Objects.Game()
                {
                    GameName = "NeverwinterNights",
                    ClientID = testClients[1].ClientID,
                    GameID = Guid.NewGuid(),
                    Characters = new List<Character>()
                    {
                        testClients[0].Characters[0]
                    }
                },
                new Dbnd.Logic.Objects.Game()
                {
                    GameName = "DrunkenCampFireFollies",
                    ClientID = testClients[1].ClientID,
                    GameID = Guid.NewGuid(),
                    Characters = new List<Character>()
                    {
                        testClients[0].Characters[0],
                        testClients[2].Characters[0]
                    }
                }
            };
        }

        private void SetUpMocks()
        {
            Repository = new Mock<Logic.Interfaces.IRepository>();
            Authorizer = new Mock<IAuthorizer>();

            Authorizer
                .Setup(a => a.Authorized(It.IsNotNull<Logic.Interfaces.IRepository>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            ClientController = new ClientController(Repository.Object, Authorizer.Object);
            ClientController.ControllerContext = new ControllerContext();
            ClientController.ControllerContext.HttpContext = new DefaultHttpContext();
            ClientController.ControllerContext.HttpContext.Request.Headers["Authorization"] = "Not a token.";
        }
    }
}
