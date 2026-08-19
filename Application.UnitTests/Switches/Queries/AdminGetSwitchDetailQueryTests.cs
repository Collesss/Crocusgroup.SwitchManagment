using Application.Common.Exceptions;
using Application.Switches.Queries.GetSwitchDetail;
using Application.UnitTests.Common;
using Infrastructure.Persistence.SQLite.Implementations;

namespace Application.UnitTests.Switches.Queries
{
    public class AdminGetSwitchDetailQueryTests : TestBase
    {
        [Fact]
        public async Task AdminGetSwitchDetailQuery_GetExistSwitch_ReturnSwitchWithId1()
        {
            //Arrange
            var getSwitch = new AdminGetSwitchDetailQuery 
            {
                Id = 1 
            };

            var handler = new AdminGetSwitchDetailQueryHandler(new SwitchRepository(_dbContext, _mapper), _mapper);

            //Act
            var @switch = await handler.Handle(getSwitch, CancellationToken.None);

            //Assert
            Assert.NotNull(@switch);
        }

        [Fact]
        public async Task AdminGetSwitchDetailQuery_GetNotExistSwitch_ThrownApplicationLaerException()
        {
            //Arrange
            var getSwitch = new AdminGetSwitchDetailQuery
            {
                Id = 100000
            };

            var handler = new AdminGetSwitchDetailQueryHandler(new SwitchRepository(_dbContext, _mapper), _mapper);

            //Act & Assert
            await Assert.ThrowsAsync<ApplicationLayerException>(() => handler.Handle(getSwitch, CancellationToken.None));
        }
    }
}
