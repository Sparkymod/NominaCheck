using Microsoft.EntityFrameworkCore;
using NominaCheck.Data.Models;
using NominaCheck.Database;
using Serilog;

namespace NominaCheck.Data.Services
{
    public class NominaServices
    {
        public async Task Add(Nomina entity)
        {
            try
            {
                using NominaPropietariaContext Context = new();
                Context.Nominas.Add(entity);
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

        public async Task<Nomina?> Get(int id)
        {
            using NominaPropietariaContext context = new();
            return await context.Nominas.FindAsync(id);
        }

        public async Task<List<Nomina>> GetAllAsync()
        {
            using NominaPropietariaContext context = new();
            return await context.Nominas.ToListAsync();
        }

        public Task<int> CountAll()
        {
            using NominaPropietariaContext context = new();
            return Task.FromResult(context.Nominas.Count());
        }
    }
}
