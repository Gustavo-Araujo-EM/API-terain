namespace api_terain.model
{
    public class Escola
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public string? Classificacao { get; set; }

        public bool EstaBloqueado { get; set; }
        public bool? ExCliente { get; set; }
        public int? IdContato { get; set; }
        public List<Conexao> Conexoes { get; set; }
    }
}
