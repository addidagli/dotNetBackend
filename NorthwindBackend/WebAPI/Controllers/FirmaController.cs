using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        private IFirmaService _firmaService;

        public FirmaController(IFirmaService etkinlikService)
        {
            _firmaService = etkinlikService;
        }

        [HttpPost("addfirma")]
        public IActionResult Add(Firma firma)
        { 
                var result = _firmaService.AddFirma(firma);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message); 
        }

        [HttpPost("deletefirma")]
        public IActionResult Delete(Firma firma)
        {
            var result = _firmaService.DeleteFirma(firma);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updatefirma")]
        public IActionResult Update(Firma firma)
        {
            var result = _firmaService.UpdateFirma(firma);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getallfirma")]
        public IActionResult GetList()
        {
            var result = _firmaService.GetAllFirma();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getfirmabyid")]
        public IActionResult GetById(int Id)
        {
            var result = _firmaService.GetFirmaById(Id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}