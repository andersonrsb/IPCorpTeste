﻿using Newtonsoft.Json;
using System;

namespace IPCorpTelecom.Teste.Domain.Entities
{
    public class Log
    {
        public int LogSistemaId { get; set; }

        public DateTime Data { get; set; }

        public string Origem { get; set; }

        public string Context { get; set; }

        public string Severidade { get; set; }

        public string Mensagem { get; set; }

        public string ArquivoFonte { get; set; }

        public string MetodoFonte { get; set; }

        public string Maquina { get; set; }

        public int? LinhaFonte { get; set; }

        public string Propriedades { get; set; }

        public string Excecao { get; set; }

        public int? OrigemId { get; set; }

        public int? LogContextoId { get; set; }
    }
}
