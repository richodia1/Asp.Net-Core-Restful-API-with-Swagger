using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicXPro.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LogicXPro.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/logs")]
    public class LoggerController : Controller
    {
        private ILoggerRepository _logRepository;
        public LoggerController(ILoggerRepository logRepository)
        {
            _logRepository = logRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var logs = await _logRepository.GetLogs();
            return Ok(logs);
        }
    }
}