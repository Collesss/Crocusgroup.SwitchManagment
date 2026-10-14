using Application.Common.Commands.Delete;
using Application.Common.Exceptions;
using Application.Common.Query.Detail;
using Application.Common.Query.List;
using Application.Switches.Queries.GetSwitchDetail.Query;
using Application.Switches.Queries.GetSwitchDetail.Response;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAPI.Models.Dto.Common.Request;
using WebAPI.Models.Dto.Common.Response;
using WebAPI.ValidationAttributes;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CommonCRDController<TAddRequest, TAddCommand, TGetDetailQuery, TGetDetailQueryResponse, TResponseDetail, TDeleteCommand, TFilter, TQueryFilter, TQueryEntity, TQueryResponse, TResponseListEntity, TMediatrReturnEntity, TGetListQuery> : ControllerBase
        where TAddCommand : IRequest<int>
        where TGetDetailQuery : CommonDetailQuery, IRequest<TGetDetailQueryResponse>, new()
        where TGetDetailQueryResponse : class
        where TDeleteCommand : CommonDeleteCommand, IRequest, new()
        where TFilter : class, new()
        where TResponseListEntity : class
        where TQueryFilter : class, new()
        where TQueryResponse : CommonListResponse<TQueryEntity, TQueryFilter>
        where TGetListQuery : CommonListQuery<TQueryFilter>, IRequest<TQueryResponse>
        where TQueryEntity : class, new()
        where TResponseDetail : class
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        protected abstract string ErrorMessageNotFound {  get; }
        protected abstract string ErrorMessageConflictSwitchNotExist { get; }
        protected abstract string ErrorMessageConflictUniqueIndex { get; }

        public CommonCRDController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        
        [HttpGet]
        public async Task<ActionResult<GetListEntityResponseDto<TFilter, TResponseListEntity>>> Get([FromQuery] GetListEntityRequestDto<TFilter> getListRequest) => 
            _mapper.Map<TQueryResponse, GetListEntityResponseDto<TFilter, TResponseListEntity>>(await _mediator.Send(_mapper.Map<GetListEntityRequestDto<TFilter>, TGetListQuery>(getListRequest)));
        

        [HttpGet("{id}")]
        public async Task<ActionResult<TResponseDetail>> Get([FromRoute][Range(0, int.MaxValue, MinimumIsExclusive = true)]int id)
        {
            try
            {
                return Ok(_mapper.Map<TGetDetailQueryResponse, TResponseDetail>(await _mediator.Send(new TGetDetailQuery { Id = id })));
            }
            catch (NotFoundAppException)
            {
                return Problem(detail: "Entity with 'id' not exist.", statusCode: StatusCodes.Status404NotFound);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] TAddRequest addRequest)
        {
            int newId = await _mediator.Send(_mapper.Map<TAddRequest, TAddCommand>(addRequest));

            return CreatedAtAction(nameof(Get), new { id = newId }, newId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute][Range(0, int.MaxValue, MinimumIsExclusive = true)] int id)
        {
            try
            {
                await _mediator.Send(new TDeleteCommand { Id = id });

                return Ok();
            }
            catch(NotFoundAppException)
            {
                return Problem(detail: "Entity with 'id' not exist.", statusCode: StatusCodes.Status404NotFound);
            }
        }
    }
}
