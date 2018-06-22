using AutoMapper;
using IPCorpTelecom.Teste.Application.Commands.Cadastrar;
using IPCorpTelecom.Teste.Application.Queries.GetLogBase;

namespace IPCorpTelecom.Teste.Application.Mapping.Profiles
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<Domain.Entities.Log, GetLogBaseQueryResponse>();

            CreateMap<Domain.Entities.Log, CadastrarLogCommandRequest>();

            CreateMap<CadastrarLogCommandRequest, Domain.Entities.Log>();
        }
    }
}
