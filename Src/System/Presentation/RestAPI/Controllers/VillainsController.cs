using Guardian.System.Core.Domain.Services;

namespace Guardian.System.Presentation.RestAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class VillainsController : ControllerBase
    {
        private readonly IVillainsService _villainsService;

        public VillainsController(IVillainsService villainsService)
        {
            this._villainsService = villainsService ?? throw new ArgumentNullException(nameof(villainsService));
        }

        [HttpGet]
        public async Task<IActionResult> GetVilliansAsync()
        {
            return this.Ok(await this._villainsService.GetVillainsAsync());
        }
    }
}