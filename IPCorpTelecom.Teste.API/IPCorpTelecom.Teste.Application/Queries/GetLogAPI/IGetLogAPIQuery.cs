using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPCorpTelecom.Teste.Application.Queries.GetLogAPI
{
    public interface IGetLogAPIQuery
    {
        Task<IList<Domain.Entities.Log>> GetLogAPI();
    }
}
