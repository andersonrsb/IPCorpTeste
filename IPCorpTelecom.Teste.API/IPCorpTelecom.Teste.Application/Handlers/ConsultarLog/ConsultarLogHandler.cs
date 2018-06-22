using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IPCorpTelecom.Teste.Application.Queries.GetLogAPI;
using IPCorpTelecom.Teste.Application.Queries.GetLogBase;
using AutoMapper;
using IPCorpTelecom.Teste.Application.Commands.Cadastrar;
using System.Linq;

namespace IPCorpTelecom.Teste.Application.Handlers.ConsultarLog
{
    public class ConsultarLogHandler : IConsultarLogHandler
    {
        readonly IGetLogAPIQuery _queryConsultarLog;
        readonly IGetLogBaseQuery _queryBase;
        readonly ICadastrarLogCommand _commandLog;

        public ConsultarLogHandler(IGetLogAPIQuery queryConsultarLog, IGetLogBaseQuery queryBase, ICadastrarLogCommand commandLog)
        {
            _queryConsultarLog = queryConsultarLog;
            _queryBase = queryBase;
            _commandLog = commandLog;
        }

        public async Task<IList<GetLogBaseQueryResponse>> Execute()
        {
            var getLogBase = await _queryBase.Execute();
            if (getLogBase.Count > 0)
                return getLogBase.ToList();
            else
            {
                // Buscar da API
                var getLogAPI = await _queryConsultarLog.GetLogAPI();

                // Cadastrar na base de dados
                if (getLogAPI.Count > 0)
                {
                    foreach (var log in getLogAPI)
                    {
                        var requestRepository = Mapper.Map<Domain.Entities.Log, CadastrarLogCommandRequest>(log);
                        await _commandLog.Execute(requestRepository);
                    }
                }

                //Buscar da base de dados
                var getLogBaseTwo = await _queryBase.Execute();
                return getLogBaseTwo.ToList();
            }
        }

        public async Task<GetLogBaseQueryResponse> Execute(int id)
        {
            var getLogBase = await Execute();
            var result = getLogBase.FirstOrDefault(s => s.LogSistemaId == id);

            return result;
            
        }
    }
}
