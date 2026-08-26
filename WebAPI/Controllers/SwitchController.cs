using Application.Common.Exceptions;
using Application.Switches.Commands.Add;
using Application.Switches.Queries.GetSwitchDetail;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Dto.Response;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwitchController : ControllerBase
    {
        private readonly IMediator _mediator;
        //private readonly IMapper _mapper;


        public SwitchController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */

        [HttpGet("{id}/admin")]
        public async Task<ActionResult<AdminSwitchDetailVm>> Get(int id)
        {
            try
            {
                return Ok(await _mediator.Send(new AdminGetSwitchDetailQuery { Id = id }));
            }
            catch(NotFoundAppException e)
            {
                return Problem(detail: "Switch with this 'id' not exist.", statusCode: StatusCodes.Status404NotFound);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] AdminAddSwitchCommand addSwitch) =>
            Ok(await _mediator.Send(addSwitch));


        /*
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
