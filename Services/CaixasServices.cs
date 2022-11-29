using Microsoft.EntityFrameworkCore;
using MonowProject.Context;
using MonowProject.Models;

namespace MonowProject.Services
{
    public class CaixasServices
    {
        private readonly AppDbContext _context;

        public CaixasServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Caixa> CreateCaixa(Caixa caixa)
        {
            //ToDo Verificar se existe caixa aberto
            _context.Caixas.Add(caixa);
            await _context.SaveChangesAsync();
            return caixa;
        }

        public async Task<Caixa?> GetCaixaById(int id)
            => await _context.Caixas.FindAsync(id);
            


        public async Task<IEnumerable<Caixa>> GetCaixas()
            => await _context.Caixas.ToListAsync();
        
        public async Task<Caixa?> GetCaixa()
            => await _context.Caixas.FirstOrDefaultAsync(c => c.DataFechamento == null);
        

    }
}
