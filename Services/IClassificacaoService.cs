using api_terain.model;

namespace api_terain.Services
{
    public interface IClassificacaoService
    {
        String ObterClassificacao(List<ModuloAutorizado> modulosAutorizados);
    }
}
