using api_terain.ENUMs;
using api_terain.model;

namespace api_terain.Services
{
    public class ClassificacaoService : IClassificacaoService
    {
        public string ObterClassificacao(List<ModuloAutorizado> modulosAutorizados)
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
                return EnumeradorClassificacao.Diamante.ToString();
            }
            else if (classificacao >= 3361 && classificacao <= 5760)
            {
                return EnumeradorClassificacao.Ouro.ToString();
            }
            else if (classificacao >= 1360 && classificacao <= 3360)
            {
                return EnumeradorClassificacao.Prata.ToString();
            }
            else if (classificacao >= 800 && classificacao <= 1360)
            {
                return EnumeradorClassificacao.Bronze.ToString();
            }
            else
            {
                return EnumeradorClassificacao.Niquel.ToString();
            }
        }
    }
}
