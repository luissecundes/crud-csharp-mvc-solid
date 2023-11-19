using PrimeiraAPI.Model;

namespace PrimeiraAPI.Infraestrutura
{
    public class FuncionariosRepositorio : IFuncionariosRepositorio
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public List<Funcionarios> Get()
        {
            return _context.Funcionarios.ToList();
        }

        public Funcionarios GetById(int id)
        {
            return _context.Funcionarios.FirstOrDefault(f => f.id == id);
        }
        public void Add(Funcionarios funcionarios)
        {
            _context.Funcionarios.Add(funcionarios);
            _context.SaveChanges();

        }
        public void Put(int id, Funcionarios funcionarios)
        {
            var funcionarioExistente = _context.Funcionarios.FirstOrDefault(f => f.id == id);

            if (funcionarios != null)
            {
                _context.Funcionarios.Update(funcionarios);
                _context.SaveChanges();
            }
        }



        public void Delete(Funcionarios funcionarios)
        {
            if (funcionarios != null)
            {
                _context.Funcionarios.Remove(funcionarios);
                _context.SaveChanges();
            }
        }



    }
}
