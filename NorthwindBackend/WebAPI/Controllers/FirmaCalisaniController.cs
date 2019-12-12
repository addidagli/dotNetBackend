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
    public class FirmaCalisaniController : ControllerBase
    {
        private IFirmaCalisaniService _firmaCalisaniService;
        private IUserService _userService;

        public FirmaCalisaniController(IFirmaCalisaniService firmaCalisaniService, IUserService userService)
        {
            _firmaCalisaniService = firmaCalisaniService;
            _userService = userService;
        }

        
    }
}