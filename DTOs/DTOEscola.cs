using api_terain.model;

namespace api_terain.Dto
{
    public class DTOEscola
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Classificacao { get; set; }

        public string? RazaoSocial { get; set;}

        public bool EstaBloqueado { get; set;}

        public string? CnpjEscola { get; set;}

        public List<ModuloAutorizado> moduloAutorizados { get; set; }
    }
}
