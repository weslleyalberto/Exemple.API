using MediatR;

namespace Exemple.API.Application.Command
{
    public class ExcluiPessoaCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
