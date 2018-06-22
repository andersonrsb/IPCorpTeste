using AutoMapper;
using IPCorpTelecom.Teste.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPCorpTelecom.Teste.Application.Queries
{
    public class ConsultarLogQuery : IConsultarLogQuery
    {
        private readonly ILogRepository _repositoryLog;

        public ConsultarLogQuery(ILogRepository repositoryLog)
        {
            _repositoryLog = repositoryLog;
        }

        public async Task<IList<ConsultarLogQueryResponse>> Execute()
        {
            var responseRepository = await _repositoryLog.ListarLog();
            var result = Mapper.Map<IList<Domain.Entities.Log>, IList<ConsultarLogQueryResponse>>(responseRepository);

            return result;
        }
    }
}
