using AutoMapper;
using BusinessCape.DTOs.TypeDocument;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;

namespace SenaOnPrinting.Controllers
{
    [ApiController]
    [Route("api/type_document")]
    public class TypeDocumentController : ControllerBase
    {
        private readonly TypeDocumentService _typeDocumentService;
        private readonly IMapper _mapper;

        public TypeDocumentController(TypeDocumentService typeDocumentService, IMapper mapper)
        {
            _typeDocumentService = typeDocumentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var typeDocuments = await _typeDocumentService.Index();
            return Ok(typeDocuments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Show(long id)
        {
            var typeDocument = await _typeDocumentService.Show(id);
            if (typeDocument == null)
            {
                return NotFound();
            }
            return Ok(typeDocument);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TypeDocumentCreateDto typeDocumentDto)
        {
            var typeDocument = _mapper.Map<TypeDocument>(typeDocumentDto);

            await _typeDocumentService.Create(typeDocument);
            return Ok(typeDocument);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, TypeDocumentUpdateDto typeDocumentDto)
        {
            var typeDocument = await _typeDocumentService.Show(typeDocumentDto.Id);

            await _typeDocumentService.Update(typeDocument);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _typeDocumentService.Delete(id);
            return NoContent();
        }
    }
}
