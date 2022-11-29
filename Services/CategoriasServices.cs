using Microsoft.EntityFrameworkCore;
using MonowProject.Context;
using MonowProject.Models;

namespace MonowProject.Services
{
    public class CategoriasServices
    {
        private readonly AppDbContext _context;

        public CategoriasServices(AppDbContext context)
        {
            _context = context;
        }


        public async Task CreateCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Categoria>> GetCategorias() 
            => await _context.Categorias.ToListAsync();
            
           
        
    }
}
