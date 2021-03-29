using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RPGDatabase.BLL.Implementations;
using RPGDatabase.BLL.Interfaces;
using RPGDatabase.DataAccess.Interfaces;
using RPGDatabase.DomainModel;
using RPGDatabase.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.BLL_Tests
{
    class ItemServiceTest
    {
        [Test]
        public void SuccessfulCreate()
        {
            var input = new DomainItemUpdateModel();
            var output = new DomainItem();

            var serviceMockup = new Mock<IPlayerValidate>();
            serviceMockup.Setup(x => x.ValidatePlayer(input));

            var repositoryMockup = new Mock<IItemRepository>();
            repositoryMockup.Setup(x => x.Add(input)).Returns(output);

            var service = new ItemService(repositoryMockup.Object, serviceMockup.Object);

            var result = service.CreateEntity(input);

            result.Should().Be(output);
        }

        [Test]
        public void UnsuccessfulCreate_ErrorThrown()
        {
            var fixture = new Fixture();
            var input = new DomainItemUpdateModel();
            var output = fixture.Create<string>();

            var serviceMockup = new Mock<IPlayerValidate>();
            serviceMockup.Setup(x => x.ValidatePlayer(input))
                         .Throws(new InvalidOperationException(output));

            var repositoryMockup = new Mock<IItemRepository>();

            var service = new ItemService(repositoryMockup.Object, serviceMockup.Object);

            var action = new Func<DomainItem>(() => service.CreateEntity(input));

            action.Should().Throw<InvalidOperationException>().WithMessage(output);
            repositoryMockup.Verify(x => x.Add(input), Times.Never);
        }
    }
}
