using Microsoft.EntityFrameworkCore;
using MonowProject.Context;
using MonowProject.Models;
using MonowProject.ModelsDTO;

namespace MonowProject.Services
{
    public class ComandasServices
    {
        private readonly AppDbContext _context;

        public ComandasServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateComanda(Comanda comanda)
        {

            _context.Comandas.Add(comanda);
            await _context.SaveChangesAsync();
        }

        public async Task<Comanda?> GetComandaById(int id) 
            => await _context.Comandas.FindAsync(id);
        

        public async Task<IEnumerable<Comanda>> GetComandas() 
            => await _context.Comandas.Where(f => f.Estado == true).ToListAsync();
     

        public async Task UpdateComanda(Comanda comanda)
        {
            _context.Comandas.Update(comanda);
            await _context.SaveChangesAsync();

        }
        public async Task CloseComanda(CloseCMD cmd)
        {
           var verify = await _context.Comandas.FindAsync(cmd.Id);
            if (verify != null)
            {
                verify.Fechamento = DateTime.Now;
                verify.Estado = false;
                verify.Valor = cmd.Valor;
                verify.Desconto= cmd.Desconto;

                _context.Comandas.Update(verify);
                await _context.SaveChangesAsync();
            }
        }
    }
}
