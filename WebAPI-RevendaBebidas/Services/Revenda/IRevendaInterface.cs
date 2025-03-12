using WebAPI_RevendaBebidas.Models;

namespace WebAPI_RevendaBebidas.Services.Revenda
{
    public interface IRevendaInterface
    {
        // Criar uma nova revenda
        RevendaModel CriarRevenda(RevendaModel revenda);

        // Obter uma revenda pelo ID
        RevendaModel ObterRevendaPorId(int id);

        // Listar todas as revendas cadastradas
        IEnumerable<RevendaModel> ObterTodasRevendas();

        // Atualizar uma revenda existente
        RevendaModel AtualizarRevenda(int id, RevendaModel revendaAtualizada);

        // Excluir uma revenda
        bool ExcluirRevenda(int id);

        // Buscar revenda pelo CNPJ
        RevendaModel ObterRevendaPorCNPJ(string cnpj);
    }
}
