using Application.Common.Commands.Delete;
using Application.Common.Exceptions;
using Application.Common.Query.Detail;
using Application.Switches.Queries.GetSwitchDetail.Query;
using Application.Switches.Queries.GetSwitchDetail.Response;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CommonController<TAddRequest, TAddCommand, TGetDetailQuery, TDeleteCommand> : ControllerBase
        where TAddCommand : IRequest<int>
        where TGetDetailQuery : CommonDetailQuery, new()
        where TDeleteCommand : CommonDeleteCommand, IRequest, new()
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        protected abstract string ErrorMessageNotFound {  get; }
        protected abstract string ErrorMessageConflictSwitchNotExist { get; }
        protected abstract string ErrorMessageConflictUniqueIndex { get; }

        public CommonController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */

        [HttpGet("{id}")]
        public async Task<ActionResult<SwitchDetailResponse>> Get([FromRoute][Range(0, int.MaxValue, MinimumIsExclusive = true)]int id)
        {
            try
            {
                return Ok(await _mediator.Send(new TGetDetailQuery { Id = id }));
            }
            catch (NotFoundAppException)
            {
                return Problem(detail: "Entity 'id' not exist.", statusCode: StatusCodes.Status404NotFound);
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
                return Problem(detail: "Entity 'id' not exist.", statusCode: StatusCodes.Status404NotFound);
            }
        }
    }
}
