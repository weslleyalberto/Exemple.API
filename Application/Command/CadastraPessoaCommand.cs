

using MediatR;

namespace Exemple.API.Application.Command
{
    public class CadastraPessoaCommand : IRequest<string>
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
    }
}
