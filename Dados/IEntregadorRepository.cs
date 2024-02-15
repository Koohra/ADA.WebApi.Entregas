using Dados.Models;

namespace Dados
{
    public interface IEntregadorRepository
    {
        List<Entregador> GetAll();
        Entregador Add(Entregador entregador);
        Entregador GetByCpf(string cpf);
    }
}
