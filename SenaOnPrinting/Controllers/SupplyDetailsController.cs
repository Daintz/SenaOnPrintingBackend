using AutoMapper;
using BusinessCape.DTOs.QuotationProviders;
using BusinessCape.DTOs.SupplyCategory;
using BusinessCape.DTOs.SupplyDetails;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SenaOnPrinting.Filters;
using SenaOnPrinting.Permissions;


namespace SenaOnPrinting.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    //[AuthorizationFilter(ApplicationPermission.Supply)]
    public class SupplyDetailsController : ControllerBase
    {
        private readonly SupplyDetailsService _supplyDetailService;
        private readonly IMapper _mapper;
        private readonly SENAONPRINTINGContext _context;


        public SupplyDetailsController(SupplyDetailsService supplyDetailService, IMapper mapper, SENAONPRINTINGContext context)
        {
            _supplyDetailService = supplyDetailService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var supplyDetails = await _supplyDetailService.GetAllAsync();
            return Ok(supplyDetails);
        }
        //{
        //    var scheme = "https";
        //    var host = Request.Host;
        //    var pathBase = Request.PathBase.ToString();
        //    var supplyDetails = await _supplyDetailService.GetAllAsync();
        //    Console.WriteLine(supplyDetails);
        //    foreach (var supplyDetail in supplyDetails)
        //    {
        //        supplyDetail.security_file = string.Format("{0}://{1}/{2}images/SupplyDetails/{3}",
        //            scheme, host, pathBase, supplyDetail.security_file);
        //        supplyDetail.security_file = supplyDetail.security_file;
        //    }
        //    return Ok(supplyDetails);
        //}



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var supplyDetail = await _supplyDetailService.GetByIdAsync(id);
            if (supplyDetail == null)
            {
                return NotFound();
            }


            return Ok(supplyDetail);
        }




[HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Add([FromForm] SupplyDetailsCreateDto supplyDetailDto)
        {
            var supplyDetailsToCreate = _mapper.Map<SupplyDetailModel>(supplyDetailDto);

            await _supplyDetailService.AddAsync(supplyDetailsToCreate);

            foreach (var supplyId in supplyDetailDto.SupplyId)
            {
                var supplyDetail = await _context.Supplies.FindAsync(supplyId);
                if (supplyDetail == null)
                {
                    return BadRequest("ERROR EN LOS INSUMOS");
                }

                var supplySupplyDetailsModel = new SupplySupplyDetailsModel
                {
                    SupplyId = supplyDetailsToCreate.Id,
                    supplydetails_id = supplyDetail.Id
                };

                _context.SupplySupplyDetails.Add(supplySupplyDetailsModel);
            }
            
            //var permissions = _context.ApplicationPermissions.Where(p => roleDto.PermissionIds.Contains(p.Id)).ToList();
            //role.Permissions = permissions;

            await _context.SaveChangesAsync();
            return Ok(supplyDetailsToCreate);
        }


        //{
        //    supplyDetailDto.security_file = await SaveImages(supplyDetailDto.security_fileInfo);

        //    var supplyDetailToCreate = _mapper.Map<SupplyDetailModel>(supplyDetailDto);

        //    await _supplyDetailService.AddAsync(supplyDetailToCreate);
        //    return Ok(supplyDetailToCreate);
        //}

        [NonAction]
        


        //public async Task<string> SaveImages(Microsoft.AspNetCore.Http.IFormFile security_fileInfo)
        //{
        //    //string imageName = new string(Path.GetFileNameWithoutExtension(PictogramFileInfo.FileName).Take(10).ToArray()).Replace(' ','_');
        //    string imageName = new string(Path.GetFileNameWithoutExtension(security_fileInfo.FileName).Take(10).ToArray()).Replace(' ', '_');
        //    imageName = imageName + Path.GetExtension(security_fileInfo.FileName);
        //    var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images\\SupplyDetails\\",imageName);

        //    using (var fileStream = new FileStream(imagePath, FileMode.Create))
        //    {
        //        await security_fileInfo.CopyToAsync(fileStream);
        //    }
  

        //    return imageName;
        //}

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]

        public async Task<IActionResult> Update(long id, SupplyDetailsUpdateDto supplyDetailDto)
        {
            if (id != supplyDetailDto.Id)
            {
                return BadRequest();
            }

            var supplyDetailToUpdate = await _supplyDetailService.GetByIdAsync(supplyDetailDto.Id);

            _mapper.Map(supplyDetailDto, supplyDetailToUpdate);

            await _supplyDetailService.UpdateAsync(supplyDetailToUpdate);
            return Ok(supplyDetailToUpdate);
        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> ChangeState(long id)
        {
            await _supplyDetailService.ChangeState(id);
            return NoContent();
        }

        //[HttpGet("file/{id}")]
        //public async Task<IActionResult> DownloadFile(int id)
        //{
        //    var file = await _supplyDetailService.GetByIdAsync(id);

        //    if (file == null)
        //    {
        //        return NotFound();
        //    }
        //    var filePath = "Images/SupplyDetails/" + file.security_file;
        //    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        //    return File(fileStream, "application/octet-stream", Path.GetFileName(filePath));
        //}

        
        //[HttpGet("custom")]
        //public async Task<IActionResult> GetCustomSupplyDetails([FromQuery] long supplyDetail)
        //{
        //    var customSupplyDetails = await _supplyDetailService.GetSupplyDetailsForSupplyAsync(supplyDetail);
        //    if (customSupplyDetails == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(customSupplyDetails);
        //}


    }
}
