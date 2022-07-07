using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using FunctionAppContagem.Contagem;

namespace FunctionAppContagem;

public class GerarValor
{
    private static readonly Contador CONTADOR = new();

    [FunctionName("GerarValor")]
    public async Task Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log,
        [Sql("dbo.HistoricoContagem",
            ConnectionStringSetting = "BaseContagem")] IAsyncCollector<DadosContador> resultados)
    {
        CONTADOR.Incrementar();
        await resultados.AddAsync(new ()
        {
            ValorAtual = CONTADOR.ValorAtual,
            Instancia = CONTADOR.Instancia,
            Kernel = CONTADOR.Kernel,
            Framework = CONTADOR.Framework,
            Mensagem = "Testes com Azure SQL Output Binding"
        });
        await resultados.FlushAsync();

        log.LogInformation($"Valor do contador = {CONTADOR.ValorAtual}");
    }
}