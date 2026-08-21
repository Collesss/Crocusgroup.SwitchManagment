using Application.Repository.Models;
using Application.Repository.Exceptions;

namespace Application.Repository.Interfaces
{
    public interface ISwitchRepository
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
        /// getDto.SearchByIpOrName, getDto.SearchByLocation, getDto.SearchByDescription, getDto.SearchBtHandler; great than 100.</exception>
        /// <returns>Switches list.</returns>
        public Task<SwitchesListDto> Get(GetSwitchesListDto getDto, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get switch by id.
        /// </summary>
        /// <param name="id">Switch id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="RepositoryException">Throw if an unknown error occurs.</exception>
        /// <exception cref="NotFoundRepositoryException">Thrown if switch not found.</exception>
        /// <exception cref="OperationCanceledException">Thrown if a cancellation was requested.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if id is less than 1.</exception>
        /// <returns>Switch.</returns>
        public Task<SwitchDto> GetById(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add switch.
        /// </summary>
        /// <param name="switchAddDto">New switch.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="RepositoryException">Throw if an unknown error occurs.</exception>
        /// <exception cref="ConfilictRepositoryException">Throw if switch with same value field "IpOrName" already exists.</exception>
        /// <exception cref="OperationCanceledException">Thrown if a cancellation was requested.</exception>
        /// <exception cref="ArgumentNullException">Throw if param switchAddDto or switchAddDto.IpOrName is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throw if length next string params: switchAddDto.IpOrName, switchAddDto.Location, switchAddDto.Description, switchAddDto.Handler,
        /// switchAddDto.Login, switchAddDto.Password, switchAddDto.SuperPassword; great than 100.</exception>
        /// <returns>New switch id.</returns>
        public Task<int> AddAsync(AddSwitchDto switchAddDto, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update switch.
        /// </summary>
        /// <param name="switchUpdateDto">Updating switch.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="RepositoryException">Throw if an unknown error occurs.</exception>
        /// <exception cref="ConfilictRepositoryException">Throw if switch with same value field "IpOrName" already exists.</exception>
        /// <exception cref="NotFoundRepositoryException">Thrown if switch not found.</exception>
        /// <exception cref="OperationCanceledException">Thrown if a cancellation was requested.</exception>
        /// <exception cref="ArgumentNullException">Throw if param switchUpdateDto is null.</exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public Task UpdateAsync(UpdateSwitchDto switchUpdateDto, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete switch.
        /// </summary>
        /// <param name="id">Switch id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="RepositoryException">Throw if an unknown error occurs.</exception>
        /// <exception cref="NotFoundRepositoryException">Thrown if switch not found.</exception>
        /// <exception cref="OperationCanceledException">Thrown if a cancellation was requested.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if id is less than 1.</exception>
        /// <returns></returns>
        public Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
