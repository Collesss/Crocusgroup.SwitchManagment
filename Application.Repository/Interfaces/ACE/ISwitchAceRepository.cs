using Application.Repository.Models.ACE.Port;
using Application.Repository.Models.ACE.Switch;
using Application.Repository.Models.Common;
using Application.Repository.Exceptions;

namespace Application.Repository.Interfaces.ACE
{
    public interface ISwitchAceRepository
    {
        /// <summary>
        /// Get switch list.
        /// </summary>
        /// <param name="getDto">Filters, sort and pagination.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="RepositoryException">Throw if an unknown error occurs.</exception>
        /// <exception cref="OperationCanceledException">Thrown if a cancellation was requested.</exception>
        /// <exception cref="ArgumentNullException">Throw if param "getDto" is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if param "getDto.PageSize" less than 1 or great than 100 or if param "getDto.PageNumber" less than 1 or if length next string params: 
        /// getDto.Filter.GroupId; great than 100.</exception>
        /// <returns>Switches list.</returns>
        public Task<ListDto<SwitchAceSortFieldDto, GetSwitchesAcesFilterDto, SwitchAceDto>> Get(GetListDto<SwitchAceSortFieldDto, GetSwitchesAcesFilterDto> getDto, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get switch by id.
        /// </summary>
        /// <param name="id">Switch id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="RepositoryException">Throw if an unknown error occurs.</exception>
        /// <exception cref="NotFoundRepositoryException">Thrown if switch ace not found.</exception>
        /// <exception cref="OperationCanceledException">Thrown if a cancellation was requested.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if id is less than 1.</exception>
        /// <returns>Switch ace.</returns>
        public Task<PortAceDto> GetById(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add switch.
        /// </summary>
        /// <param name="switchAceAddDto">New switch ace.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="RepositoryException">Throw if an unknown error occurs.</exception>
        /// <exception cref="ConfilictRepositoryException">Throw if switchAce with same value fields: SwitchId, GroupId; or Id already exists.</exception>
        /// <exception cref="OperationCanceledException">Thrown if a cancellation was requested.</exception>
        /// <exception cref="ArgumentNullException">Throw if param switchAce.GroupId is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throw if length string param "switchAce.GroupId" great than 100.</exception>
        /// <returns>New switch ace id.</returns>
        public Task<int> AddAsync(SwitchAceDto switchAceAddDto, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update switch.
        /// </summary>
        /// <param name="switchAceUpdateDto">Updating switch.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="RepositoryException">Throw if an unknown error occurs.</exception>
        /// <exception cref="ConfilictRepositoryException">Throw if switch with same value field "IpOrName" already exists.</exception>
        /// <exception cref="NotFoundRepositoryException">Thrown if switch not found.</exception>
        /// <exception cref="OperationCanceledException">Thrown if a cancellation was requested.</exception>
        /// <exception cref="ArgumentNullException">Throw if param switchUpdateDto is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throw if length string param "switchAce.GroupId" great than 100.</exception>
        /// <returns></returns>
        public Task UpdateAsync(SwitchAceDto switchAceUpdateDto, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete switch.
        /// </summary>
        /// <param name="id">Switch id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="RepositoryException">Throw if an unknown error occurs.</exception>
        /// <exception cref="NotFoundRepositoryException">Thrown if switch ace not found.</exception>
        /// <exception cref="OperationCanceledException">Thrown if a cancellation was requested.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if id is less than 1.</exception>
        /// <returns></returns>
        public Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
