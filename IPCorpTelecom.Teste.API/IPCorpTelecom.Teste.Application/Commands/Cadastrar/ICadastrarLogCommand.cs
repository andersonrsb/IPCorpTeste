using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IPCorpTelecom.Teste.Application.Commands.Cadastrar
{
    public interface ICadastrarLogCommand
    {
        Task<bool> Execute(CadastrarLogCommandRequest request);
    }
}
