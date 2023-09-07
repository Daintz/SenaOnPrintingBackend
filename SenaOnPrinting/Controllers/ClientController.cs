using AutoMapper;
using BusinessCape.DTOs.Client;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenaOnPrinting.Filters;
using SenaOnPrinting.Permissions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenaOnPrinting.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[AuthorizationFilter(ApplicationPermission.Client)]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(ClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }
        // GET: api/<ClientController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var client = await _clientService.GetAllAsync();
            return Ok(client);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<IActionResult> Add(ClientCreateDto clientDto)
        {
            var clientToCreate = _mapper.Map<ClientModel>(clientDto);

            await _clientService.AddAsync(clientToCreate);
            return Ok(clientToCreate);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, ClientUpdateDto clientDto)
        {
            var clientToUpdate = await _clientService.GetByIdAsync(clientDto.Id);
            _mapper.Map(clientDto, clientToUpdate);
            await _clientService.UpdateAsync(clientToUpdate);
            return NoContent();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _clientService.DeleteAsync(id);
            return NoContent();
        }
    }
}
