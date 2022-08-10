using CVFilter.Application.Abstract;
using CVFilter.Application.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CVFilter.Presentation.WebAPI.Controllers
{
    public class ApplicantController : BaseController
    {
        private readonly IApplicantService _applicantService;
        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        /// <summary>
        /// Gets All Applicant
        /// </summary>
        /// <param name="getAllQueryRequestDto"></param>
        /// <returns></returns>
        [HttpPost("getall")]
        public async Task<IActionResult> GetAllAsync(GetAllApplicantQueryRequestDto getAllQueryRequestDto)
        {
            var result = await _applicantService.GetAllAsync(getAllQueryRequestDto);
            return StatusCode(result.HttpResponse, new {result.Status, result.Data});
        }

        /// <summary>
        /// Gets applicant by id
        /// </summary>
        /// <param name="getApplicantQueryRequestDto"></param>
        /// <returns></returns>
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetAsync([FromQuery]GetApplicantQueryRequestDto getApplicantQueryRequestDto)
        {
            var result = await _applicantService.GetAsync(getApplicantQueryRequestDto);

            return StatusCode(result.HttpResponse, new { result.Status, result.Data });
        }

        /// <summary>
        /// Creates Applicant
        /// </summary>
        /// <param name="createApplicantCommandRequestDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]CreateApplicantCommandRequestDto createApplicantCommandRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,new { Message = "Model is not valid" });
            }

            var result = await _applicantService.CreateAsync(createApplicantCommandRequestDto);

            return StatusCode(result.HttpResponse, new { result.Status, result.Data });
        }

        /// <summary>
        /// Updates applicant
        /// </summary>
        /// <param name="updateApplicantCommandRequestDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdateApplicantCommandRequestDto updateApplicantCommandRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Model is not valid" });
            }

            var result = await _applicantService.UpdateAsync(updateApplicantCommandRequestDto);

            return StatusCode(result.HttpResponse, new {result.Status, result.Data});
        }

        /// <summary>
        /// Delete applicant
        /// </summary>
        /// <param name="deleteApplicantCommandRequestDto"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery]DeleteApplicantCommandRequestDto deleteApplicantCommandRequestDto)
        {
            if (!ModelState.IsValid) 
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Model is not valid" });
            }

            var result = await _applicantService.DeleteAsync(deleteApplicantCommandRequestDto);
            return StatusCode(result.HttpResponse, new { result.Status, result.Data });
        }
    }
}
