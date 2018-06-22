using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPCorpTelecom.Teste.Application.Queries
{
    public interface IConsultarLogQuery
    {
        Task<IList<ConsultarLogQueryResponse>> Execute();
    }
}
