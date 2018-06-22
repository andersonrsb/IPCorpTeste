using AutoMapper;
using IPCorpTelecom.Teste.Application.Mapping.Profiles;

namespace IPCorpTelecom.Teste.Application.Mapping
{
    public class AutoMapping
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(x => {
                x.AddProfile<LogProfile>();
            });
        }
    }
}
