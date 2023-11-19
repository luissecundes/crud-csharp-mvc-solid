using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.Model;
using PrimeiraAPI.ViewModel;

namespace PrimeiraAPI.Controllers
{
    [ApiController]
    [Route("api/v1/funcionarios")]
    public class FuncionariosControlador : ControllerBase
    {
        private readonly IFuncionariosRepositorio _funcionariosRepositorio;

        public FuncionariosControlador(IFuncionariosRepositorio funionariosRepositorio)
        {
            _funcionariosRepositorio = funionariosRepositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {


            var funcionarios = _funcionariosRepositorio.Get();
            return Ok(funcionarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var funcionarios = _funcionariosRepositorio.GetById(id);
            if (funcionarios == null)
            {
                return NotFound("Funcionário não encontrado!");
            }
            return Ok(funcionarios);
        }
        [HttpPost]
        public IActionResult Add(FuncionariosViewModel funcionariosView)
        {   
            
            var funcionarios = new Funcionarios(funcionariosView.Nome,funcionariosView.Idade, null );
            Console.WriteLine(funcionarios);

            _funcionariosRepositorio.Add(funcionarios);

            return Ok();
        }

                

        [HttpPut("{id}")]
        public IActionResult Put(int id, FuncionariosViewModel funcionariosView)
        {
            var funcionarios = new Funcionarios(funcionariosView.Nome, funcionariosView.Idade, null);
            Console.WriteLine(funcionarios);
            try
            {
                _funcionariosRepositorio.Put(id, funcionarios);
                return Ok("Funcionário atualizado com sucesso!");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound("Funcionário não encontrado!!!");
            }
            catch (Exception ex)
            {
                // Lidar com outras exceções, se necessário
                return StatusCode(500, "Erro interno do servidor");
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var funcionarios = _funcionariosRepositorio.GetById(id); 
        if (funcionarios == null)
            {
                return NotFound("Não Encontrado");
            }
            _funcionariosRepositorio.Delete(funcionarios);
            return Ok("Seu funcionário foi demitido!");
        
        }


    }
}
