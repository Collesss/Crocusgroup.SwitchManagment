using Application.Switches.Queries.GetSwitchesList;
using Application.UnitTests.Common;
using Infrastructure.Persistence.SQLite.Implementations;
using System.Threading.Tasks;

namespace Application.UnitTests.Switches.Queries
{
    public class AdminGetSwitchesListQueryTests : TestBase
    {
        [Fact]
        public async Task AdminGetSwitchesListQuery()
        {
            //Arrange
            var query = new AdminGetSwitchesListQuery
            {
                SearchByIpOrName = "1",
                SortField = SwitchSortField.Id,
                SortAsc = true,
                PageNumber = 0,
                PageSize = 25,
            };

            var handler = new AdminGetSwitchesListQueryHandler(new SwitchRepository(_dbContext, _mapper), _mapper);
            //Act

            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
        }
    }
}
