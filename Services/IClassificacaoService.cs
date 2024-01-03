using api_terain.model;

namespace api_terain.Services
{
    public interface IClassificacaoService
    {
        string ObterClassificacao(List<ModuloAutorizado> modulosAutorizados);
    }
}
