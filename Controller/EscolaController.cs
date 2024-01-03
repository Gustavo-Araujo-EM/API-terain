using api_terain.Dto;
using api_terain.model;
using api_terain.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace api_terain.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IClassificacaoService _classificacaoService;
        public EscolaController(IConfiguration configuration, IClassificacaoService classificacaoService) {
            _configuration = configuration;
            _classificacaoService = classificacaoService;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarEscolas()
        {
            string apiUrl = _configuration.GetValue<string>("ApiTerain:url");
            string apiKey = _configuration.GetValue<string>("ApiTerain:value");

            var client = new RestClient(apiUrl);
            var request = new RestRequest("/Registro", Method.Get);
            request.AddHeader(_configuration.GetValue<string>("ApiTerain:key"), apiKey);

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<Escola> escolasDeserializado = JsonConvert.DeserializeObject<List<Escola>>(response.Content);

                List<DTOEscola> escolasDto = new();

                foreach (var escola in escolasDeserializado)
                {
                    DTOEscola escolaDto = new() {
                        Id = escola.Id,
                        Nome = escola.Nome,
                        CnpjEscola = escola.Conexoes.Select(x => x.CnpjEscola).FirstOrDefault(),
                        EstaBloqueado = escola.EstaBloqueado,
                        RazaoSocial = escola.Conexoes.Select(x => x.RazaoEscola).FirstOrDefault(),
                        moduloAutorizados = escola.Conexoes.SelectMany(x => x.ModulosAutorizados).ToList(),
                    };
                    
                    escolaDto.Classificacao = _classificacaoService.ObterClassificacao(escolaDto.moduloAutorizados);
                    escolasDto.Add(escolaDto);
                }
                return Ok(escolasDto.Take(2));
            }
            else
            {
                return BadRequest($"Erro na chamada à API. Status: {response.StatusCode}, Mensagem: {response.ErrorMessage}");
            }
        }
    }
}
