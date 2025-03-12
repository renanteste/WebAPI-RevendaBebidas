using WebAPI_RevendaBebidas.Data;
using WebAPI_RevendaBebidas.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_RevendaBebidas.Services.Revenda
{
    public class RevendaService : IRevendaInterface
    {
        private readonly AppDbContext _context;

        public RevendaService(AppDbContext context)
        {
            _context = context;
        }

        // Criar uma nova revenda
        public RevendaModel CriarRevenda(RevendaModel revenda)
        {
            _context.Revendas.Add(revenda);
            _context.SaveChanges();
            return revenda;
        }

        // Obter uma revenda pelo ID
        public RevendaModel ObterRevendaPorId(int id)
        {
            return _context.Revendas
                .Include(r => r.Telefones)
                .Include(r => r.Enderecos)
                .FirstOrDefault(r => r.Id == id);
        }

        // Listar todas as revendas
        public IEnumerable<RevendaModel> ObterTodasRevendas()
        {
            return _context.Revendas
                .Include(r => r.Telefones)
                .Include(r => r.Enderecos)
                .ToList();
        }

        // Atualizar uma revenda existente
        public RevendaModel AtualizarRevenda(int id, RevendaModel revendaAtualizada)
        {
            var revenda = _context.Revendas.Find(id);
            if (revenda == null) return null;

            revenda.CNPJ = revendaAtualizada.CNPJ;
            revenda.RazaoSocial = revendaAtualizada.RazaoSocial;
            revenda.NomeFantasia = revendaAtualizada.NomeFantasia;
            revenda.Email = revendaAtualizada.Email;
            revenda.Telefones = revendaAtualizada.Telefones;
            revenda.Enderecos = revendaAtualizada.Enderecos;

            _context.SaveChanges();
            return revenda;
        }

        // Excluir uma revenda
        public bool ExcluirRevenda(int id)
        {
            var revenda = _context.Revendas.Find(id);
            if (revenda == null) return false;

            _context.Revendas.Remove(revenda);
            _context.SaveChanges();
            return true;
        }

        // Buscar revenda pelo CNPJ
        public RevendaModel ObterRevendaPorCNPJ(string cnpj)
        {
            return _context.Revendas.FirstOrDefault(r => r.CNPJ == cnpj);
        }
    }
}

