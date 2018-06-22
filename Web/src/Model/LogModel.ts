export class LogModel {
    LogSistemaId?: number;
    Data?: Date;
    Origem?: string;
    Context?: string;
    Severidade?: string;
    Mensagem?: string;
    ArquivoFonte?: string;
    MetodoFonte?: string;
    Maquina?: string;
    LinhaFonte?: number;
    Propriedades?: string;
    Excecao?: string;
    OrigemId?: number;
    LogContextoId?: number;
}
