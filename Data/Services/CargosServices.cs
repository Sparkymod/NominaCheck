using Microsoft.EntityFrameworkCore;
using NominaCheck.Data.Models;
using NominaCheck.Database;
using Serilog;

namespace NominaCheck.Data.Services
{
    public class CargosServices : ServicesInstances<DepartamentoServices>
    {
        public async void Add(Cargo entity)
        {
            try
            {
                using NominaPropietariaContext Context = new();
                Context.Cargos.Add(entity);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Log.Logger.Error($"Error saving changes => {ex.InnerException.Message}");
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Error saving changes => {ex.Message}");
            }
        }

        public async Task<Cargo?> Get(int id)
        {
            using NominaPropietariaContext context = new();
            return await context.Cargos.FindAsync(id);
        }

        public async Task<List<Cargo>> GetAllAsync()
        {
            using NominaPropietariaContext context = new();
            return await context.Cargos.ToListAsync();
        }

        public Task<int> CountAll()
        {
            using NominaPropietariaContext context = new();
            return Task.FromResult(context.Cargos.Count());
        }
    }
}
