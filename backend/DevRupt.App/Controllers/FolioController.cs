using DevRupt.Core.Contracts;
using DevRupt.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevRupt.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FolioController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public FolioController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFolios()
        {
            var folios = await _repoWrapper.Folio.GetAllFoliosAsync();

            return Ok(folios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFolio(string Id)
        {
            var folios = await _repoWrapper.Folio.GetExistingFolio(Id);

            return Ok(folios);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFolio(string id)
        {
            var folio = await _repoWrapper.Folio.GetExistingFolio(id);
            if (folio == null)
            {
                return NotFound();
            }

            await _repoWrapper.Folio.DeleteFolioAsync(folio);
            _repoWrapper.Save();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFolio(Folio folio)
        {
            if (folio == null)
            {
                return BadRequest("Folio object is null");
            }

            await _repoWrapper.Folio.CreateFolioAsync(folio);
            _repoWrapper.Save();

            return CreatedAtRoute("GetFolio", new { id = folio.Id }, folio);
        }


    }
}
