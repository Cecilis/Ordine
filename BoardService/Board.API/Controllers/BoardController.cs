using BoardApplication.Features.Board.Commands.CreateBoard;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Messaging;

namespace BoardAPI.Controllers
{
    [ApiController]
    [Route("api/boards")]
    public class BoardController : ControllerBase
    {
        private readonly ICustomMediator _mediator;

        public BoardController(ICustomMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBoardCommand command)
            => Ok(await _mediator.Send<CreateBoardCommand, Guid>(command));
    }

}
