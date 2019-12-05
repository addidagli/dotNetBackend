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
    public class OrganizasyonController : ControllerBase
    {
        private IOrganizasyonService _organizasyonService;

        public OrganizasyonController(IOrganizasyonService organizasyonService)
        {
            _organizasyonService = organizasyonService;
        }

        [HttpPost("addorganizasyon")]
        public IActionResult Add(Organizasyon organizasyon)
        {
            var result = _organizasyonService.AddOrganizasyon(organizasyon);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deleteorganizasyon")]
        public IActionResult Delete(Organizasyon organizasyon)
        {
            var result = _organizasyonService.DeleteOrganizasyon(organizasyon);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updateorganizasyon")]
        public IActionResult Update(Organizasyon organizasyon)
        {
            var result = _organizasyonService.UpdateOrganizasyon(organizasyon);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getallorganizasyon")]
        public IActionResult GetList()
        {
            var result = _organizasyonService.GetAllOrganizasyon();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getorganizasyonbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _organizasyonService.GetOrganizasyonById(Id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}