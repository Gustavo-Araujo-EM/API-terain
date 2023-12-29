namespace api_terain.model
{
    public class Conexao
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string NomeEscola { get; set; }
        public string? RazaoEscola { get; set; }
        public string CnpjEscola { get; set; }
        public List<EmpresaSecundaria> EmpresasSecundarias { get; set; }
        public List<ModuloAutorizado> ModulosAutorizados { get; set; }
    }
}
