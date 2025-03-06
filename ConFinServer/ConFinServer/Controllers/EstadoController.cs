using ConFinServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private static List<Estado> Lista = new List<Estado>();


        [HttpGet]
        public string Estado()
        {
            var valor = "Teste";
            return valor;
        }

        [HttpGet("Estado2")]
        public string Estado(string valor)
        {
            return valor;
        }

        [HttpGet]
        [Route("Lista")]
        public List<Estado> EstadoLista()
        {
            return Lista;
        }

        [HttpPost]
        public string PostEstado(Estado estado)
        { 
            Lista.Add(estado);
            return "Estado cadastradoi com sucesso";
        }

        [HttpPut]
        public string PutEstado(Estado estado)
        {
            var estadoExiste = Lista
                                .Where(L => L.Sigla == estado.Sigla)
                                .FirstOrDefault();
            if(estadoExiste != null)
            {
                estadoExiste.Nome = estado.Nome;
                return "Estado alterado com sucesso";
            }
            else
            {
                return "Estado não encontrado";
            }
            
        }

        [HttpDelete]
        public string DeleteEstado(Estado estado)
        {
            var estadoExiste = Lista
                                .Where(L => L.Sigla == estado.Sigla)
                                .FirstOrDefault();
            if (estadoExiste != null)
            {
                Lista.Remove(estadoExiste);
                return "Estado excluido com sucesso";
            }
            else
            {
                return "Estado não encontrado";
            }

        }

        [HttpDelete("Exclui2")]
        public string DeleteEstado2([FromQuery] string sigla)
        {
            var estadoExiste = Lista
                                .Where(L => L.Sigla == sigla)
                                .FirstOrDefault();
            if (estadoExiste != null)
            {
                Lista.Remove(estadoExiste);
                return "Estado excluido com sucesso";
            }
            else
            {
                return "Estado não encontrado";
            }

        }

        [HttpDelete("Exclui3")]
        public string DeleteEstado3([FromHeader] string sigla)
        {
            var estadoExiste = Lista
                                .Where(L => L.Sigla == sigla)
                                .FirstOrDefault();
            if (estadoExiste != null)
            {
                Lista.Remove(estadoExiste);
                return "Estado excluido com sucesso";
            }
            else
            {
                return "Estado não encontrado";
            }

        }

        [HttpDelete("{Sigla}")]
        public string DeleteEstado4([FromRoute] string sigla)
        {
            var estadoExiste = Lista
                                .Where(L => L.Sigla == sigla)
                                .FirstOrDefault();
            if (estadoExiste != null)
            {
                Lista.Remove(estadoExiste);
                return "Estado excluido com sucesso";
            }
            else
            {
                return "Estado não encontrado";
            }

        }

    }
}
