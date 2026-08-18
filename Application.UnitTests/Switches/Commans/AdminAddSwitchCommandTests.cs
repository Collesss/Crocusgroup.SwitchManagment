using Application.UnitTests.Common;
using Application.Switches.Commands.Add;
using Infrastructure.Persistence.SQLite.Implementations;
using Application.Common.Exceptions;

namespace Application.UnitTests.Switches.Commans
{
    public class AdminAddSwitchCommandTests : CommandTestBase
    {
        [Fact]
        public async Task AdminAddSwitchCommand_AddSwitch_ReturnId11()
        {
            //Arrange
            var addingSwitch = new AdminAddSwitchCommand
            {
                IpOrName = "Host11",
                Location = "Location11",
                Description = "Description11",
                Handler = "HPComware5",
                Login = "admin",
                Password = "1111",
                SuperPassword = "1234"
            };

            int exceptedId = 11;

            var handler = new AdminAddSwitchCommandHandler(new SwitchRepository(_dbContext, _mapper), _mapper);

            //Act
            int newId = await handler.Handle(addingSwitch, CancellationToken.None);

            //Assert
            Assert.Equal(exceptedId, newId);
        }

        [Fact]
        public async Task AdminAddSwitchCommand_AddExistSwitch_ThrownApplicationLayerException()
        {
            //Arrange
            var addingExistSwitch = new AdminAddSwitchCommand
            {
                IpOrName = "Host1",
                Location = "Location1",
                Description = "Description1",
                Handler = "HPComware5",
                Login = "admin",
                Password = "1111",
                SuperPassword = "1234"
            };

            var handler = new AdminAddSwitchCommandHandler(new SwitchRepository(_dbContext, _mapper), _mapper);

            //Act & Assert
            await Assert.ThrowsAsync<ApplicationLayerException>(() => handler.Handle(addingExistSwitch, CancellationToken.None));
        }
    }
}
