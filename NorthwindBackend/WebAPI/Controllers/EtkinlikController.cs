using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtkinlikController : ControllerBase
    {
        private IEtkinlikService _etkinlikService;

        public EtkinlikController(IEtkinlikService etkinlikService)
        {
            _etkinlikService = etkinlikService;
        }

        [HttpPost("addetkinlik")]
        public IActionResult Add(Etkinlik etkinlik)
        {
            var result = _etkinlikService.AddEtkinlik(etkinlik);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deleteetkinlik")]
        public IActionResult Delete(Etkinlik etkinlik)
        {
            var result = _etkinlikService.DeleteEtkinlik(etkinlik);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updateetkinlik")]
        public IActionResult Update(Etkinlik etkinlik)
        {
            var result = _etkinlikService.UpdateEtkinlik(etkinlik);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getalletkinlik")]
        public IActionResult GetList()
        {
            var result = _etkinlikService.GetAllEtkinlik();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getetkinlikbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _etkinlikService.GetEtkinlikById(Id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}