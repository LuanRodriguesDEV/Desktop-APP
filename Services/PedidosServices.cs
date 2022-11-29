using Microsoft.EntityFrameworkCore;
using MonowProject.Context;
using MonowProject.Models;

namespace MonowProject.Services
{
    public class PedidosServices
    {
        private readonly AppDbContext _context;
        public PedidosServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreatePedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePedido(int pedido)
        {
            var find = await _context.Pedidos.FindAsync(pedido);
            find.IsExcluido = true;
            _context.Pedidos.Update(find);
            _context.SaveChanges();
        }


        public async Task<IEnumerable<Pedido>> GetPedidoComanda(int id) =>
            await _context.Pedidos.Where(p => p.ComandaId == id && p.IsExcluido == false).Include(u => u.Produto).ToListAsync();
    }
}
