using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AvisaAi.Domain;

namespace AvisaAi.Controllers
{
    [RoutePrefix("api/v1")] // Inclui um prefixo para as chamadas para esse controller. ex: http://localhost/api/v1.
    public class PessoaController : ApiController
    {
        #region Métodos Públicos

        [HttpGet] // Indique o método HTTP que esse método responde
        [Route("pessoas")] // Configura uma rota específica para essa operação, nesse caso será http://localhost/api/v1/pessoas (por convenção REST, colocar o nome no plural)
        public HttpResponseMessage ObterPessoas() // A resposta de uma operação será sempre HttpResponseMessage, que é uma resposta HTTP (lembrando que API é RESTfull que é totalmente baseado no protocolo HTTP).
        {
            var pessoas = ObterPessoasDoBancoDeDados();

            // Tudo certo, então retorna as pessoas e status HTTP OK.
            return Request.CreateResponse(HttpStatusCode.OK, pessoas);
        }

        [HttpPost]
        [Route("pessoas")] // Repare que é a mesma rota anterior, só que agora o método é diferente (POST ao invés de GET), então OK
        public HttpResponseMessage IncluirPessoa([FromBody]Pessoa pessoa) // [FromBody] indica que o parâmetro 'pessoa' vem do content da request
        {
            // Deu erro ao incluir
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Mensagem = "Ocorreu um erro interno." });
        }

        [HttpGet]
        [Route("pessoas/{id}")]
        public HttpResponseMessage ObterPessoaPorId(int id)
        {
            var pessoa = ObterPessoaDoBancoDeDados(id);

            if (pessoa == null)
            {
                // Não achou a pessoa, então retorna o status que não encontrou
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, pessoa);
        }

        [HttpGet]
        [Route("pessoas/{idPessoa}/endereco")] 
        public HttpResponseMessage ObterEnderecoPorIdPessoa(int idPessoa)
        {
            var pessoa = ObterPessoaDoBancoDeDados(idPessoa);

            if (pessoa == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var endereco = ObterEnderecoDoBancoDeDados(idPessoa);

            return Request.CreateResponse(HttpStatusCode.OK, endereco);
        }        

        #endregion

        #region Métodos Auxiliares

        private Pessoa ObterPessoaDoBancoDeDados(int id)
        {
            //return null;
            return new Pessoa() { Nome = "Ivan", Sobrenome = "Bicalho", Idade = 27 };
        }

        private IEnumerable<Pessoa> ObterPessoasDoBancoDeDados()
        {
            return new List<Pessoa>()
            {
                new Pessoa() { Nome = "Ivan", Sobrenome = "Bicalho", Idade = 27 },
                new Pessoa() { Nome = "Dani", Sobrenome = "Marinho Bicalho", Idade = 21 }
            };
        }

        private object ObterEnderecoDoBancoDeDados(int idPessoa)
        {
            return new
            {
                Rua = "Rua Longe demais depois vire a esquerda",
                Numero = 1956,
                Bairro = "Bairro distante"
            };
        }

        #endregion
    }
}
