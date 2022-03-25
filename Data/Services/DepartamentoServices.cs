using Microsoft.EntityFrameworkCore;
using NominaCheck.Data.Models;
using NominaCheck.Database;
using Serilog;

namespace NominaCheck.Data.Services
{
    public class DepartamentoServices
    {
        public async void Add(Departamento entity)
        {
            try
            {
                using NominaPropietariaContext Context = new();
                Context.Departamentos.Add(entity);
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

        public async Task<Departamento?> Get(int id)
        {
            using NominaPropietariaContext context = new();
            return await context.Departamentos.FindAsync(id);
        }

        public async Task<List<Departamento>> GetAllAsync()
        {
            using NominaPropietariaContext context = new();
            return await context.Departamentos.ToListAsync();
        }

        public Task<int> CountAll()
        {
            using NominaPropietariaContext context = new();
            return Task.FromResult(context.Departamentos.Count());
        }
    }
}
