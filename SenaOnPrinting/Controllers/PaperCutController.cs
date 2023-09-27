using AutoMapper;
using BusinessCape.DTOs.PaperCut;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SenaOnPrinting.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaperCutsController : ControllerBase
    {
        private readonly PaperCutService _paperCutService;
        private readonly IMapper _mapper;

        public PaperCutsController(PaperCutService paperCutService, IMapper mapper)
        {
            _paperCutService = paperCutService;
            _mapper = mapper;
        }
        // GET: api/<paperCutController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var paperCut = await _paperCutService.GetAllAsync();
            return Ok(paperCut);
        }

        // GET api/<paperCutController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var paperCut = await _paperCutService.GetByIdAsync(id);
            if (paperCut == null)
            {
                return NotFound();
            }
            return Ok(paperCut);
        }

        // POST api/<paperCutController>
        [HttpPost]
        public async Task<IActionResult> Add(PaperCutCreateDto paperCutDto)
        {
            var paperCutToCreate = _mapper.Map<PaperCutModel>(paperCutDto);

            await _paperCutService.AddAsync(paperCutToCreate);
            return Ok(paperCutToCreate);
        }

        // PUT api/<paperCutController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, PaperCutUpdateDto paperCutDto)
        {
            var paperCutToUpdate = await _paperCutService.GetByIdAsync(paperCutDto.Id);
            _mapper.Map(paperCutDto, paperCutToUpdate);
            await _paperCutService.UpdateAsync(paperCutToUpdate);
            return NoContent();
        }

        // DELETE api/<paperCutController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _paperCutService.DeleteAsync(id);
            return NoContent();
        }
    }
}
