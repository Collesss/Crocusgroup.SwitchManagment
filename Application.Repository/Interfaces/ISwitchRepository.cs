using Application.Repository.Models;

namespace Application.Repository.Interfaces
{
    public interface ISwitchRepository
    {
        public Task<SwitchDto> GetById(int id, CancellationToken cancellationToken = default);

        public Task<int> AddAsync(SwitchAddDto switchAddDto, CancellationToken cancellationToken = default);

        public Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
