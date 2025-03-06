using ConFinServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private static List<Cidade> Lista = new List<Cidade>();


        [HttpGet]
        public string Cidade()
        {
            var valor = "Teste";
            return valor;
        }

        [HttpGet("Cidade2")]
        public string Cidade(string valor)
        {
            return valor;
        }

        [HttpGet]
        [Route("Lista")]
        public List<Cidade> CidadeLista()
        {
            return Lista;
        }

        [HttpPost]
        public string PostCidade(Cidade cidade)
        {
            Lista.Add(cidade);
            return "Cidade cadastrada com sucesso";
        }

        [HttpPut]
        public string PutCidade(Cidade cidade)
        {
            var cidadeExiste = Lista
                                .Where(L => L.Codigo == cidade.Codigo)
                                .FirstOrDefault();
            if (cidadeExiste != null)
            {
                cidadeExiste.Nome = cidade.Nome;
                return "Cidade alterado com sucesso";
            }
            else
            {
                return "Cidade não encontrado";
            }

        }

        [HttpDelete]
        public string DeleteCidade(Cidade cidade)
        {
            var cidadeExiste = Lista
                                .Where(L => L.Nome == cidade.Nome)
                                .FirstOrDefault();
            if (cidadeExiste != null)
            {
                Lista.Remove(cidadeExiste);
                return "Cidade excluido com sucesso";
            }
            else
            {
                return "Cidade não encontrado";
            }

        }

    }
}