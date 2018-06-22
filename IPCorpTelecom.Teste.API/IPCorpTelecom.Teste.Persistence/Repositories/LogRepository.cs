using System;
using System.Data;
using System.Collections.Generic;
using IPCorpTelecom.Teste.Domain.Entities;
using System.Threading.Tasks;
using IPCorpTelecom.Teste.Application.Interfaces;
using IPCorpTelecom.Teste.Persistence.Connections;
using Dapper;

namespace IPCorpTelecom.Teste.Persistence.Repository
{
    public class LogRepository : ILogRepository
    {
        public async Task<IList<Log>> ListarLog()
        {
            try
            {
                using (IDbConnection conn = ConnectionsString.GetDefaultSqlServerConnection())
                {
                    var sql = $@"SELECT TOP 10 * FROM Log";
                    var data = await conn.QueryAsync<Log>(sql);

                    return data.AsList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void DeleteAll()
        {
            try
            {
                using (IDbConnection conn = ConnectionsString.GetDefaultSqlServerConnection())
                {
                    var sql = $@"DELETE FROM Log";
                    await conn.ExecuteAsync(sql);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Cadastrar(Log model)
        {
            try
            {
                using (IDbConnection conn = ConnectionsString.GetDefaultSqlServerConnection())
                {
                    var sql = $@"INSERT INTO Log(LogSistemaId,Data,Origem,Context,Severidade,Mensagem,ArquivoFonte,MetodoFonte,Maquina,LinhaFonte,Propriedades,Excecao,OrigemId,LogContextoId)
                                VALUES(@LogSistemaId,@Data,@Origem,@Context,@Severidade,@Mensagem,@ArquivoFonte,@MetodoFonte,@Maquina,@LinhaFonte,@Propriedades,@Excecao,@OrigemId,@LogContextoId)";
                        
                    var result = await conn.ExecuteAsync(sql, new {
                        model.ArquivoFonte,
                        model.Context,
                        model.Data,
                        model.Excecao,
                        model.LinhaFonte,
                        model.LogContextoId,
                        model.LogSistemaId,
                        model.Maquina,
                        model.Mensagem,
                        model.MetodoFonte,
                        model.Origem,
                        model.OrigemId,
                        model.Propriedades,
                        model.Severidade
                    });
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
