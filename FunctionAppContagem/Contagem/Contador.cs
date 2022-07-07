using System;
using System.Runtime.InteropServices;

namespace FunctionAppContagem.Contagem;

public class Contador
{
    private static readonly string _INSTANCIA;
    private static readonly string _KERNEL;
    private static readonly string _FRAMEWORK;

    static Contador()
    {
        _INSTANCIA = Environment.MachineName;
        _KERNEL = Environment.OSVersion.VersionString;
        _FRAMEWORK = RuntimeInformation.FrameworkDescription;
    }

    private int _valorAtual = 0;

    public int ValorAtual { get => _valorAtual; }
    public string Instancia { get => _INSTANCIA; }
    public string Kernel { get => _KERNEL; }
    public string Framework { get => _FRAMEWORK; }

    public void Incrementar()
    {
        _valorAtual++;
    }
}