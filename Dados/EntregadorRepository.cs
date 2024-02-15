using Dados.Models;

namespace Dados
{
    public class EntregadorRepository : IEntregadorRepository
    {
        private List<Entregador> _entregadores = new List<Entregador>
        {
            new Entregador
            {
                Nome = "Miguel",
                CPF = "212345677"
            },
            new Entregador
            {
                Nome = "João",
                CPF = "1234412345"
            }
        };

        public Entregador Add(Entregador entregador)
        {
            _entregadores.Add(entregador);
            return entregador;
        }

        public List<Entregador> GetAll()
        {
            return _entregadores;
        }

        public Entregador GetByCpf(string cpf)
        {
            return _entregadores.FirstOrDefault(x => x.CPF == cpf)!;
        }
    }
}
