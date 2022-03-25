using Microsoft.EntityFrameworkCore;
using NominaCheck.Data.Models;
using NominaCheck.Database;
using Serilog;

namespace NominaCheck.Data.Services
{
    public class TiposEmpleadoServices
    {
        public async void Add(TiposEmpleado entity)
        {
            try
            {
                using NominaPropietariaContext Context = new();
                Context.TiposEmpleados.Add(entity);
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

        public async Task<TiposEmpleado?> Get(int id)
        {
            using NominaPropietariaContext context = new();
            return await context.TiposEmpleados.FindAsync(id);
        }

        public async Task<List<TiposEmpleado>> GetAllAsync()
        {
            using NominaPropietariaContext context = new();
            return await context.TiposEmpleados.ToListAsync();
        }

        public Task<int> CountAll()
        {
            using NominaPropietariaContext context = new();
            return Task.FromResult(context.TiposEmpleados.Count());
        }
    }
}
