using Guardian.System.Core.Domain.Services;

namespace Guardian.System.Presentation.RestAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class VillainsController : ControllerBase
    {
        private readonly IVillainsService _villiansService;

        public VillainsController(IVillainsService villiansService)
        {
            this._villiansService = villiansService ?? throw new ArgumentNullException(nameof(villiansService));
        }

        [HttpGet]
        public async Task<IActionResult> GetVilliansAsync()
        {
            return this.Ok(await this._villiansService.GetVillansAsync());
        }
    }
}