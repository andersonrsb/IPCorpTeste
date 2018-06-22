using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IPCorpTelecom.Teste.Application.Queries;
using System.Collections;
using IPCorpTelecom.Teste.Application.Handlers.ConsultarLog;
using IPCorpTelecom.Teste.Application.Queries.GetLogBase;

namespace IPCorpTelecom.Teste.API.Controllers
{
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        readonly IConsultarLogHandler _handlerLog;

        public LogController(IConsultarLogHandler handlerLog)
        {
            _handlerLog = handlerLog;
        }
        
        [HttpGet("[action]")]
        public async Task<IList<GetLogBaseQueryResponse>> Get()
        {
            var response = await _handlerLog.Execute();

            return response;
        }
        
        [HttpGet("[action]")]
        public async Task<GetLogBaseQueryResponse> GetId(int id)
        {
            var response = await _handlerLog.Execute(id);

            return response;
        }
    }
}
