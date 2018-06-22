using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPCorpTelecom.Teste.Application.Interfaces
{
    public interface ILogRepository
    {
        Task<bool> Cadastrar(Domain.Entities.Log model);
        Task<IList<Domain.Entities.Log>> ListarLog();        
        void DeleteAll();
    }
}
