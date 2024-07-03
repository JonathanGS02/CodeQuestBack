using CodeQuest.Repository.Dtos.Questao;
using CodeQuest.Repository.Services.Interface;
using CodeQuestAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeQuestAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestaoController : ControllerBase
    {

        private readonly IQuestaoService _questaoService;
        private readonly IAccount _accountService;

        public QuestaoController(IQuestaoService questaoService, IAccount accountService)
        {
            _questaoService = questaoService;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var questoes = await _questaoService.GetAllQuestaoAsync();

                if (questoes == null)
                {
                    return NoContent();
                }

                return Ok(questoes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar questão. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var questao = await _questaoService.GetQuestaoByIdAsync(id);

                if (questao == null)
                {
                    return NoContent();
                }
                return Ok(questao);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar questão. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QuestaoDto model)
        {
            try
            {
                var usuario = User.GetUserName();
                var user = await _accountService.GetUserByUserNameAsync(usuario);

                //if (user.Funcao != "Administrador")
                //    return Ok("Você não possui permissão para adicionar uma Questão!");

                var questao = await _questaoService.AddQuestao(User.GetUserId(), model);

                if (questao == null)
                {
                    return NoContent();
                }
                return Ok(questao);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar questão. Erro: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] QuestaoDto model)
        {
            try
            {
                var usuario = User.GetUserName();
                var user = await _accountService.GetUserByUserNameAsync(usuario);

                if (user.Funcao != "Administrador")
                    return Ok("Você não possui permissão para adicionar uma Questão!");

                var questao = await _questaoService.UpdateQuestao(User.GetUserId(), id, model);

                if (questao == null)
                {
                    return NoContent();
                }
                return Ok(questao);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar questão. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var questao = await _questaoService.DeleteQuestao(User.GetUserId(), id);

                if (questao == false)
                {
                    return BadRequest("Erro ao tentar deletar questão.");
                }
                return Ok(new { message = "Deletado" });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar questão. Erro: {ex.Message}");
            }
        }
    }
}
