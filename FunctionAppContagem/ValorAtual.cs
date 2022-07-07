using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FunctionAppContagem.Contagem;

namespace FunctionAppContagem;

public static class ValorAtual
{
    [FunctionName("ValorAtual")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log,
        [Sql("SELECT TOP 1 * FROM dbo.HistoricoContagem ORDER BY Id DESC",
            CommandType = System.Data.CommandType.Text,
            ConnectionStringSetting = "BaseContagem")]
            IEnumerable<ResultadoContador> resultados)
    {
        var resultado = resultados.FirstOrDefault();
        log.LogInformation($"Valor mais recente do Contador: {resultado?.ValorAtual}");
        return new OkObjectResult(resultado);
    }
}