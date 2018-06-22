using AutoMapper;
using IPCorpTelecom.Teste.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IPCorpTelecom.Teste.Application.Commands.Cadastrar
{
    public class CadastrarLogCommand : ICadastrarLogCommand
    {
        readonly ILogRepository _repositoryLog;

        public CadastrarLogCommand(ILogRepository repositoryLog)
        {
            _repositoryLog = repositoryLog;
        }

        public async Task<bool> Execute(CadastrarLogCommandRequest request)
        {
            var requestRepository = Mapper.Map<CadastrarLogCommandRequest, Domain.Entities.Log>(request);
            var result = await _repositoryLog.Cadastrar(requestRepository);

            return result;
        }
    }
}
