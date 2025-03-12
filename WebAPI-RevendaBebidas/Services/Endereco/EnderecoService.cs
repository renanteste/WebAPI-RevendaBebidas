using WebAPI_RevendaBebidas.Data;
using WebAPI_RevendaBebidas.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI_RevendaBebidas.Services.Endereco
{
    public class EnderecoService : IEnderecoInterface
    {
        private readonly AppDbContext _context;

        public EnderecoService(AppDbContext context)
        {
            _context = context;
        }

        // Adicionar um novo endereço
        public EnderecoModel AdicionarEndereco(EnderecoModel endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return endereco;
        }

        // Obter um endereço pelo ID
        public EnderecoModel ObterEnderecoPorId(int id)
        {
            return _context.Enderecos.Find(id);
        }

        // Listar endereços de uma revenda específica
        public IEnumerable<EnderecoModel> ObterEnderecosPorRevenda(int revendaId)
        {
            return _context.Enderecos.Where(e => e.RevendaId == revendaId).ToList();
        }

        // Atualizar um endereço existente
        public EnderecoModel AtualizarEndereco(int id, EnderecoModel enderecoAtualizado)
        {
            var endereco = _context.Enderecos.Find(id);
            if (endereco == null) return null;

            endereco.Endereco = enderecoAtualizado.Endereco;
            _context.SaveChanges();
            return endereco;
        }

        // Remover um endereço
        public bool RemoverEndereco(int id)
        {
            var endereco = _context.Enderecos.Find(id);
            if (endereco == null) return false;

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return true;
        }
    }
}
