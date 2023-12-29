using api_terain.model;

namespace api_terain.Services
{
    public static class ClassificacaoService
    {
        public static String ObterClassificacao(List<ModuloAutorizado> modulosAutorizados)
        {
            double classificacao = 0;
            foreach (var modulo in modulosAutorizados)
            {
                double qtdPontos = 0;
                if (modulo.IdModulo.Equals(Terabyte.EnumeradorDeModulosTerabyte.Smart.Codigo))
                {
                    qtdPontos += 2;
                }
                if (modulo.IdModulo.Equals(Terabyte.EnumeradorDeModulosTerabyte.EnsinoRegular.Codigo) || modulo.IdModulo.Equals(Terabyte.EnumeradorDeModulosTerabyte.Curso.Codigo))
                {
                    qtdPontos += 5;
                }

                if (modulo.IdModulo.Equals(Terabyte.EnumeradorDeModulosTerabyte.NotaFiscalEletronica.Codigo))  // NFS-e , NF-e e NFC-e
                {
                    qtdPontos += 0.5;
                }

                if (modulo.IdModulo.Equals(Terabyte.EnumeradorDeModulosTerabyte.CupomFiscal.Codigo))  
                {
                    qtdPontos += 0.5;
                }

                if (modulo.IdModulo.Equals(Terabyte.EnumeradorDeModulosTerabyte.PortalProfessor.Codigo)) 
                {
                    qtdPontos += 0.5;
                }

                double qtdLicenca = modulo.QuantidadeLicencas.HasValue ? (int)modulo.QuantidadeLicencas : 0;

                classificacao += qtdLicenca * qtdPontos;
            }

            if (classificacao > 5761)
            {
                return "diamante";
            }
            else if (classificacao >= 3361 && classificacao <= 5760)
            {
                return "ouro";
            }
            else if (classificacao >= 1360 && classificacao <= 3360)
            {
                return "prata";
            }
            else if (classificacao >= 800 && classificacao <= 1360)
            {
                return "bronze";
            }
            else
            {
                return "niquel";
            }
        }
    }
}
