using AutoMapper;
using CodeQuest.Data.Dtos.Login;
using CodeQuest.Data.Login;
using CodeQuest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeQuest.Controllers.Login
{
    [ApiController]
    [Route("[controler]")]
    public class LoginController : ControllerBase
    {
        private LoginContext _context;
        private IMapper _mapper;

        public LoginController(LoginContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionarCadastro([FromBody] CreateCadastroDto cadastroDto)
        {
            Cadastro cadastro = _mapper.Map<Cadastro>(cadastroDto);

            if(CadastroExistente(cadastroDto.Email)) 
            {
                return BadRequest("Não é possível criar o cadastro. O e-mail já está em uso.");
            }

            _context.cadastros.Add(cadastro);
            _context.SaveChanges();
            return Ok();
        }

        private bool CadastroExistente(string email)
        {
            return _context.cadastros.Any(c => c.Email == email);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto loginDto) 
        { 
            var cadastro= _context.cadastros.FirstOrDefault(c =>  c.Email == loginDto.Email);

            if(cadastro==null)
            {
                return NotFound("Login não encontrado");
            }

            return Ok("Login bem sucedido");
        }
    }
}
