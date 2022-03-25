using Microsoft.EntityFrameworkCore;
using NominaCheck.Data.Models;
using NominaCheck.Database;
using Serilog;

namespace NominaCheck.Data.Services
{
    public class TipoDepartamentoServices
    {
        //public async Task<List<Facturable>> GetAllAsync()
        //{
        //    using FacturaDbContext context = new();
        //    return await context.Facturables.ToListAsync();
        //}

        //public async Task<Facturable?> Get(short id)
        //{
        //    using FacturaDbContext context = new();
        //    return await context.Facturables.FindAsync(id);
        //}

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

        //public async Task<int> GetLastRno()
        //{
        //    using FacturaDbContext context = new();
        //    if (!context.FacturasDs.Any())
        //    {
        //        return 0;
        //    }
        //    FacturasD? result = await context.FacturasDs.LastOrDefaultAsync();
        //    return result == null ? 0 : result.Rno;
        //}
    }

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
