using AutoMapper;
using BusinessCape.DTOs.Finish;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinishController : ControllerBase
    {

        private readonly FinishServices _finishServices;
        private readonly IMapper _mapper;

        public FinishController(FinishServices finishServices, IMapper mapper)
        {
            _finishServices = finishServices;
            _mapper = mapper;
        }
        // GET: api/<MachineController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var finish = await _finishServices.GetAllAsync();
            return Ok(finish);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var finish = await _finishServices.GetByIdAsync(id);
            if (finish == null)
            {
                return NotFound();
            }
            return Ok(finish);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FinishDtoCreate finishDto)
        {
            var FinishToCreate = _mapper.Map<FinishModel>(finishDto);

            await _finishServices.AddAsync(FinishToCreate);
            return Ok(FinishToCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, FinishDtoUpdate finishDto)
        {
            var FinishToUpdate = await _finishServices.GetByIdAsync(finishDto.IdFinish);
            _mapper.Map(finishDto, FinishToUpdate);
            await _finishServices.UpdateAsync(FinishToUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _finishServices.DeleteAsync(id);
            return NoContent();
        }
    }
}