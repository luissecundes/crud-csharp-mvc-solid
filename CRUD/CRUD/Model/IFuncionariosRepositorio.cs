namespace PrimeiraAPI.Model
{
    public interface IFuncionariosRepositorio
    {
        void Add(Funcionarios funcionarios);
        List<Funcionarios> Get();

        void Delete (Funcionarios funcionarios);

        Funcionarios GetById(int id);

        void Put(int id, Funcionarios funcionarios);


    }
}
