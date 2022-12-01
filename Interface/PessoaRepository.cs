using Exemple.API.Application.Models;

namespace Exemple.API.Interface
{
    public class PessoaRepository : IRepository<Pessoa>
    {
        private static Dictionary<int,Pessoa> pessoas = new Dictionary<int,Pessoa>();
        public async Task Add(Pessoa item)
        {
            await Task.Run(() => pessoas.Add(item.Id, item));
        }

        public async Task Delete(int id)
        {
            await Task.Run(()=> pessoas.Remove(id));    
        }

        public async Task Edit(Pessoa item)
        {
            await Task.Run(() =>
            {
                pessoas.Remove(item.Id);
                pessoas.Add(item.Id, item);
            });
        }

        public async Task<Pessoa> Get(int id)
        {
            return await Task.Run(() => pessoas.GetValueOrDefault(id));
        }

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await Task.Run(() => pessoas.Values.ToList());
        }
    }
}
