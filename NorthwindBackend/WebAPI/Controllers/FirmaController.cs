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
    class Example
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        List<Example> examples = new List<Example> {
            new Example
            {
                ShortTitle = "Deneme",
                Title = "Test"
            },
            new Example
            {
                ShortTitle = "Deneme",
                Title = "Test"
            },
            new Example
            {
                ShortTitle = "Deneme",
                Title = "Test"
            },
            new Example
            {
                ShortTitle = "Deneme",
                Title = "Test"
            }
        };

        private IFirmaService _firmaService;

        public FirmaController(IFirmaService etkinlikService)
        {
            _firmaService = etkinlikService;
        }

        [HttpPost("addfirma")]
        public IActionResult Add(Firma firma)
        {
            //List<string> shortTitles = examples.Where(a => a.Title == "Deneme").Select(b=>b.ShortTitle).ToList();
            try
            {
                var result = _firmaService.AddFirma(firma);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
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