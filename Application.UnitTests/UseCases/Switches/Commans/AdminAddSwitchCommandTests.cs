using Application.UnitTests.UseCases.Common;
using MediatR;
using Moq;

namespace Application.UnitTests.UseCases.Switches.Commans
{
    public class AdminAddSwitchCommandTests : CommandTestBase
    {
        [Fact]
        public void AdminAddSwitchCommand_AddSwitch_ReturnId2() 
        {
            //Arrange
            var mediatorMock = new Mock<IMediator>();
            //Act

            //Assert
        }
    }
}
