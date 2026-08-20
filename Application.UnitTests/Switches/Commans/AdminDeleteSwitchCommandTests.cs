using Application.Common.Exceptions;
using Application.Switches.Commands.Delete;
using Application.UnitTests.Common;
using Infrastructure.Persistence.SQLite.Implementations;

namespace Application.UnitTests.Switches.Commans
{
    public class AdminDeleteSwitchCommandTests : TestBase
    {
        [Fact]
        public async Task AdminDeleteSwitchCommand_DeleteExistSwitch_ExecutionWithoutErrors()
        {
            //Arrange
            var deletingSwitch = new AdminDeleteSwitchCommand
            {
                Id = 1
            };

            var handler = new AdminDeleteSwitchCommandHandler(new SwitchRepository(_dbContext, _mapper));

            //Act & Assert
            await handler.Handle(deletingSwitch, CancellationToken.None);
        }


        [Fact]
        public async Task AdminDeleteSwitchCommand_DeleteNotExistSwitch_ThrownApplicationLaerException()
        {
            //Arrange
            var deletingSwitch = new AdminDeleteSwitchCommand
            {
                Id = 10000
            };

            var handler = new AdminDeleteSwitchCommandHandler(new SwitchRepository(_dbContext, _mapper));

            //Act & Assert
            await Assert.ThrowsAsync<AppException>(() => handler.Handle(deletingSwitch, CancellationToken.None));
        }
    }
}
