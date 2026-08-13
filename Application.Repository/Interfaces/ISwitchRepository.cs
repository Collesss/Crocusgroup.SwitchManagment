using Application.Repository.Models;

namespace Application.Repository.Interfaces
{
    public interface ISwitchRepository
    {
        public Task<int> AddAsync(SwitchDto switchDto, CancellationToken cancellationToken = default);

        public Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
