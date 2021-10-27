using AppLog.API.Models;
using AppLog.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLog.API.Controllers
{
    public class LoggerController : ControllerBase
    {
        private readonly LogService _logService;
        public LoggerController(LogService logService)
        {
            _logService = logService;
        }


        [HttpGet("getall")]
        public ActionResult<List<LogModel>> Get() =>
            _logService.Get();

        [HttpGet("{id:length(24)}",Name ="GetLog")]
        public ActionResult<LogModel> Get(string id)
        {
            var log = _logService.Get(id);
            if (log == null)
            {
                return NotFound();
            }
            return log;
        }


        [HttpPost("create")]
        public ActionResult<LogModel> Create(LogModel model)
        {
            _logService.Create(model);
            return CreatedAtAction("GetLog", new { id = model.Id.ToString() }, model);
        }
    }
}
