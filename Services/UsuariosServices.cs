using Microsoft.EntityFrameworkCore;
using MonowProject.Context;
using MonowProject.Models;

namespace MonowProject.Services
{
    public class UsuariosServices
    {
        private readonly AppDbContext _context;

        public UsuariosServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetFuncionarios()
            => await _context.Usuarios.ToListAsync();
        public async Task<Usuario?> GetFuncionarioById(int id)
            => await _context.Usuarios.FindAsync(id);
        public async Task<Usuario> GetFuncionario(string nome, string senha)
            => await _context.Usuarios.Where(f => f.Nome == nome && f.Senha == senha).FirstAsync();
    

        public async Task CreateFuncionario(Usuario funcionario)
        {
            _context.Usuarios.Add(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFuncionario(Usuario funcionario)
        {
            _context.Entry(funcionario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteFuncionario(Usuario funcionario)
        {
            _context.Usuarios.Remove(funcionario);
            await _context.SaveChangesAsync();

        }
    }
}
