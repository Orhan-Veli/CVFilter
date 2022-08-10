using CVFilter.Application.Abstract;
using CVFilter.Application.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CVFilter.Presentation.WebAPI.Controllers
{
    public class CVController : BaseController
    {
        private readonly ICVService _cvService;
        public CVController(ICVService cvService)
        {
            _cvService = cvService;
        }

        /// <summary>
        /// Adds Cvs to the db
        /// </summary>
        /// <param name="cvWorkerRequestDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CVWorkerRequestDto cvWorkerRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Model is not valid" });
            }

            var result = await _cvService.CVWorkerAsync(cvWorkerRequestDto);

            return StatusCode(result.HttpResponse, new { result.Status, result.Data });
        }
    }
}
