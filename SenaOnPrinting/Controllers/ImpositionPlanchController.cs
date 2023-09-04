using AutoMapper;
using BusinessCape.DTOs.ImpositionPlanch;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class impositionPlanchController : ControllerBase
    {
        private readonly ImpositionPlanchService _impositionPlanchService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public impositionPlanchController(ImpositionPlanchService impositionPlanchService, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _impositionPlanchService = impositionPlanchService;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }
        // GET: api/<LineatureController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var impositionPlanches = await _impositionPlanchService.GetAllAsync();
            return Ok(impositionPlanches);
        }

        // GET api/<LineatureController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var impositionPlanch = await _impositionPlanchService.GetByIdAsync(id);
            if (impositionPlanch == null)
            {
                return NotFound();
            }
            return Ok(impositionPlanch);
        }

        // POST api/<LineatureController>
        [HttpPost]
        public async Task<IActionResult> Add( ImpositionPlanchCreateDto impositionPlanchDto)
        {
            var impositionPlanchToCreate = _mapper.Map<ImpositionPlanchModel>(impositionPlanchDto);

            await _impositionPlanchService.AddAsync(impositionPlanchToCreate);
            return Ok(impositionPlanchToCreate);
        }
        
        // PUT api/<LineatureController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, ImpositionPlanchUpdateDto impositionPlanchDto)
        {
            if (id != impositionPlanchDto.Id)
            {
                return BadRequest();
            }

            var lineatureToUpdate = await _impositionPlanchService.GetByIdAsync(impositionPlanchDto.Id);

            _mapper.Map(impositionPlanchDto, lineatureToUpdate);

            await _impositionPlanchService.UpdateAsync(lineatureToUpdate);
            return Ok(lineatureToUpdate);
        }


        // DELETE api/<LineatureController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> ChangeState(long id)
        {
            await _impositionPlanchService.ChangeState(id);
            return NoContent();
        }
    }
}
