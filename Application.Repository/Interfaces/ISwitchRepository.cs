using Application.Repository.Models;

namespace Application.Repository.Interfaces
{
    public interface ISwitchRepository
    {
        public Task<SwitchesListDto> Get(GetSwitchesListDto getDto, CancellationToken cancellationToken = default);

        public Task<IEnumerable<SwitchDto>> GetAll(CancellationToken cancellationToken = default);

        public Task<SwitchDto> GetById(int id, CancellationToken cancellationToken = default);

        public Task<int> AddAsync(AddSwitchDto switchAddDto, CancellationToken cancellationToken = default);

        public Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
