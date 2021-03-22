using DevRupt.Core.Contracts;
using DevRupt.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevRupt.App.Controllers
{
    public class RatePlanController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        public RatePlanController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRatePlans()
        {
            var rateplans = await _repoWrapper.RatePlan.GetAllRatePlansAsync();

            return Ok(rateplans);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRatePlan(string id)
        {
            var rateplan = await _repoWrapper.RatePlan.GetExistingRatePlan(id);

            return Ok(rateplan);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRatePlan(string id)
        {
            var rateplan = await _repoWrapper.RatePlan.GetExistingRatePlan(id);
            if (rateplan == null)
            {
                return NotFound();
            }

            await _repoWrapper.RatePlan.DeleteRatePlanAsync(rateplan);
            _repoWrapper.Save();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRatePlan(RatePlan rateplan)
        {
            if (rateplan == null)
            {
                return BadRequest("Folio object is null");
            }

            await _repoWrapper.RatePlan.CreateRatePlanAsync(rateplan);
            _repoWrapper.Save();

            return CreatedAtRoute("GetRatePlan", new { id = rateplan.Id }, rateplan);
        }
    }
}
