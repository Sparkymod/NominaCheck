using Microsoft.EntityFrameworkCore;
using NominaCheck.Data.Models;
using NominaCheck.Database;
using Serilog;

namespace NominaCheck.Data.Services
{
    public class EmpleadoServices
    {
        public async Task Add(Empleado entity)
        {
            try
            {
                using NominaPropietariaContext Context = new();
                Context.Empleados.Add(entity);
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

        public async Task<Empleado?> Get(int id)
        {
            using NominaPropietariaContext context = new();
            return await context.Empleados.FindAsync(id);
        }

        public async Task<List<Empleado>> GetAllAsync()
        {
            using NominaPropietariaContext context = new();
            return await context.Empleados.ToListAsync();
        }

        public Task<int> CountAll()
        {
            using NominaPropietariaContext context = new();
            return Task.FromResult(context.Empleados.Count());
        }
    }
}
