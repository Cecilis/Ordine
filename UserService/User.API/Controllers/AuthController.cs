using Microsoft.AspNetCore.Mvc;
using SharedKernel.Messaging;
using User.Application.Features.User.Commands.SocialLogin;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ICustomMediator _mediator;

        public AuthController(ICustomMediator mediator)
            => _mediator = mediator;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SocialLoginCommand cmd)
            => Ok(await _mediator.Send<SocialLoginCommand, string>(cmd));
    }
}
