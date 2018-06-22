using AutoMapper;
using IPCorpTelecom.Teste.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPCorpTelecom.Teste.Application.Queries.GetLogBase
{
    public class GetLogBaseQuery : IGetLogBaseQuery
    {
        private readonly ILogRepository _repositoryLog;

        public GetLogBaseQuery(ILogRepository repositoryLog)
        {
            _repositoryLog = repositoryLog;
        }

        public async Task<IList<GetLogBaseQueryResponse>> Execute()
        {
            var responseRepository = await _repositoryLog.ListarLog();
            var result = Mapper.Map<IList<Domain.Entities.Log>, IList<GetLogBaseQueryResponse>>(responseRepository);

            return result;
        }
    }
}
