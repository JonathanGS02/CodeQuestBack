using CodeQuest.Repository.Dtos.Questao;
using CodeQuest.Repository.Dtos.Topico;
using CodeQuest.Repository.Services.Interface;
using CodeQuestAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeQuestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TopicoController : ControllerBase
    {

        private readonly ITopicoService _topicoService;
        private readonly IAccount _accountService;
        private readonly IQuestaoTopicoService _questaoTopicoService;

        public TopicoController(ITopicoService topicoService, IAccount accountService, IQuestaoTopicoService questaoTopicoService)
        {
            _topicoService = topicoService;
            _accountService = accountService;
            _questaoTopicoService = questaoTopicoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var topicos = await _topicoService.GetAllTopicoAsync();

                if (topicos == null)
                {
                    return NoContent();
                }

                return Ok(topicos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar topicos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var topico = await _topicoService.GetTopicoByIdAsync(id);

                if (topico == null)
                {
                    return NoContent();
                }
                return Ok(topico);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar topico. Erro: {ex.Message}");
            }
        }

        [HttpGet("{nivel}")]
        public async Task<IActionResult> GetRound(int nivel)
        {
            try
            {
                var topico = await _topicoService.GetTopicoByRandomAsync(nivel);

                if (topico == null)
                {
                    return NoContent();
                }
                return Ok(topico);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar topico. Erro: {ex.Message}");
            }
        }

        [HttpPost("Resposta")]
        public async Task<IActionResult> PostResposta([FromBody] TopicoDto model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Erro ao tentar salvar resposta!");
                }
                
                var retorno = await _questaoTopicoService.PostSalvaQuestaoTopicoAsync(model, User.GetUserId());

                if (retorno == null)
                {
                    return NoContent();
                }

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar topico. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TopicoDto model)
        {
            try
            {
                var usuario = User.GetUserName();
                var user = await _accountService.GetUserByUserNameAsync(usuario);

                if (user.Funcao != "Administrador")
                    return Ok("Você não possui permissão para adicionar uma topico!");

                var topico = await _topicoService.AddTopico(User.GetUserId(), model);

                if (topico == null)
                {
                    return NoContent();
                }
                return Ok(topico);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar topico. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] TopicoDto model)
        {
            try
            {
                var usuario = User.GetUserName();
                var user = await _accountService.GetUserByUserNameAsync(usuario);

                if (user.Funcao != "Administrador")
                    return Ok("Você não possui permissão para adicionar uma topico!");

                var topico = await _topicoService.UpdateTopico(User.GetUserId(), id, model);

                if (topico == null)
                {
                    return NoContent();
                }
                return Ok(topico);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar topico. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var topico = await _topicoService.DeleteTopico(User.GetUserId(), id);

                if (topico == false)
                {
                    return BadRequest("Erro ao tentar deletar topico.");
                }
                return Ok(new { message = "Deletado" });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar topico. Erro: {ex.Message}");
            }
        }
    }
}
