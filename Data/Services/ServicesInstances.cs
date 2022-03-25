namespace NominaCheck.Data.Services
{
    /// <summary>
    /// Servicios Genericos para compartir Instancias entre servicios.
    /// </summary>
    public class ServicesInstances<T1>
    {
        // Singleton
        private T1? _instance;
        public T1 Instance => _instance ??= Activator.CreateInstance<T1>();
    }
}
