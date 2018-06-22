using IPCorpTelecom.Teste.Application.Queries.GetLogBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPCorpTelecom.Teste.Application.Handlers.ConsultarLog
{
    public interface IConsultarLogHandler
    {
        Task<IList<GetLogBaseQueryResponse>> Execute();

        Task<GetLogBaseQueryResponse> Execute(int id);
    }
}
