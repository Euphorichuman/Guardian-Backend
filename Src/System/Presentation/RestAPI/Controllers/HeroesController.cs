using Guardian.System.Core.Domain.Services;

namespace Guardian.System.Presentation.RestAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroesService _heroesService;

        public HeroesController(IHeroesService heroesService)
        {
            this._heroesService = heroesService ?? throw new ArgumentNullException(nameof(heroesService));
        }

        [HttpGet]
        public async Task<IActionResult> GetHeroesAsync()
        {
            return this.Ok(await this._heroesService.GetHeroesAsync());
        }
    }
}
