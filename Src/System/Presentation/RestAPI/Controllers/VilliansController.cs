using Guardian.System.Core.Domain.Services;

namespace Guardian.System.Presentation.RestAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class VilliansController : ControllerBase
    {
        private readonly IVilliansService _villiansService;

        public VilliansController(IVilliansService villiansService)
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