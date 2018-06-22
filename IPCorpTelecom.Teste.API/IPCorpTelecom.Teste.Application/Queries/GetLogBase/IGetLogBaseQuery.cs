using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPCorpTelecom.Teste.Application.Queries.GetLogBase
{
    public interface IGetLogBaseQuery
    {
        Task<IList<GetLogBaseQueryResponse>> Execute();
    }
}
