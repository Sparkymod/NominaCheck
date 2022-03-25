namespace NominaCheck
{
    public static class Settings
    {
        internal static string GetConnectionStringMssql()
        {
            string server = Environment.GetEnvironmentVariable("MSSQL_IP") ?? "";
            string port = Environment.GetEnvironmentVariable("MSSQL_PORT") ?? "";
            string database = Environment.GetEnvironmentVariable("MSSQL_NAME") ?? "";
            string user = Environment.GetEnvironmentVariable("MSSQL_USER") ?? "";
            string password = Environment.GetEnvironmentVariable("MSSQL_PASSWORD") ?? "";

            if (Environment.GetEnvironmentVariable("MSSQL_LOCAL") == "true")
            {
                return $"Server={server}; Database={database}; Trusted_Connection=True;";
            }
            return $"Server={server}; Database={database}; User ID={user}; Password={password};";
        }

        public static bool IsDevelopingMode()
        {
            string result = Environment.GetEnvironmentVariable("DEVELOPMENT") ?? "";
            return result == "true";
        }

        public static class Paths
        {
            public static readonly string SOLUTION_DIR = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../.."));
            public static readonly string PRODUCTION_DIR = "../";
        }

        // Dot Environment Settings.
        public static class DotEnv
        {
            public static string FilePath { get; set; }

            public static void Load(string filepath = ".env")
            {
                FilePath = IsDevelopingMode() ? Path.Combine(Paths.SOLUTION_DIR, filepath) : Path.Combine(Paths.PRODUCTION_DIR, filepath);

                if (!File.Exists(FilePath))
                {
                    StreamWriter writer = new(FilePath) { AutoFlush = true };

                    writer.WriteLine("# MSSQL Server");
                    writer.WriteLine("MSSQL_IP=PC-HOME-RAFA\\SQLEXPRESS");
                    writer.WriteLine("MSSQL_PORT=1433");
                    writer.WriteLine("MSSQL_NAME=dbTest");
                    writer.WriteLine("MSSQL_USER=root");
                    writer.WriteLine("MSSQL_PASSWORD=Admin");
                    writer.WriteLine("MSSQL_LOCAL=true");
                    writer.WriteLine("DEVELOPMENT=true");
                    writer.Close();
                }
                foreach (string line in File.ReadAllLines(FilePath))
                {
                    string[] parts = line.Split('=', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != 2)
                    {
                        continue;
                    }

                    Environment.SetEnvironmentVariable(parts[0], parts[1]);
                }
            }
        }
    }
}
