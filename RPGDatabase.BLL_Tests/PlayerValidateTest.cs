using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RPGDatabase.BLL.Implementations;
using RPGDatabase.BLL.Interfaces;
using RPGDatabase.DataAccess.Interfaces;
using RPGDatabase.DomainModel;
using RPGDatabase.DomainModel.Contracts;
using RPGDatabase.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.BLL_Tests
{
    class PlayerValidateTest
    {
        [Test]
        public void ThrowsNothing()
        {
            var playerId = new Mock<IPlayerContainer>();
            var player = new DomainPlayer();

            var playerMock = new DomainPlayerIdentityModel(playerId.Object);

            var repository = new Mock<IPlayerRepository>();
            repository.Setup(x => x.Get(playerMock)).Returns(player);

            var service = new PlayerValidateService(repository.Object);


            var action = new Action(() => service.ValidatePlayer(playerId.Object));

            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void ThrowsError()
        {
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var playerId = new Mock<IPlayerContainer>();
            playerId.Setup(x => x.PlayerId).Returns(id);

            var playerMock = new DomainPlayerIdentityModel(playerId.Object);

            var repository = new Mock<IPlayerRepository>();
            repository.Setup(x => x.Get(playerMock)).Returns((DomainPlayer)null);

            var service = new PlayerValidateService(repository.Object);

            var action = new Action(() => service.ValidatePlayer(playerId.Object));

            action.Should().Throw<InvalidOperationException>();
        }
    }
}
