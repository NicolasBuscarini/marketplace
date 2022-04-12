using Microsoft.AspNetCore.Mvc;

namespace IntegracaoPix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PixController : ControllerBase
    {
        private readonly IPixService _pixService;

        public PixController(IPixService pixService)
        {
            _pixService = pixService;
        }


        [HttpPost("create-pix")]
        public async Task<ActionResult> CreatePix([FromBody] Pix pix)
        {
            try
            {
                return Ok(await _pixService.CreatePix(pix));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
