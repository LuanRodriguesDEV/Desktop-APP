using Microsoft.EntityFrameworkCore;
using MonowProject.Context;
using MonowProject.Models;

namespace MonowProject.Services
{
    public class ProdutosServices 
    {
        private readonly AppDbContext _context;

        public ProdutosServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateProduto(Produto produto)
        {
                   
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public Task DeleteProduto(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Produto?> GetProdutoById(int id)
            => await _context.Produtos.FindAsync(id);
     

        public async Task<IEnumerable<Produto>> GetProdutoByName(string name) 
            => await _context.Produtos.Where(n => n.Nome.Contains(name)).ToListAsync();
        

        public async Task<IEnumerable<Produto>> GetProdutos()
            => await _context.Produtos.Include(p => p.Categoria).ToListAsync();           

        

    }
}
