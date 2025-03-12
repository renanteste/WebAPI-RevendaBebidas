using WebAPI_RevendaBebidas.Models;

namespace WebAPI_RevendaBebidas.Services.Endereco
{
    public interface IEnderecoInterface
    {
        EnderecoModel AdicionarEndereco(EnderecoModel endereco);
        EnderecoModel ObterEnderecoPorId(int id);
        IEnumerable<EnderecoModel> ObterEnderecosPorRevenda(int revendaId);
        EnderecoModel AtualizarEndereco(int id, EnderecoModel enderecoAtualizado);
        bool RemoverEndereco(int id);
    }
}

