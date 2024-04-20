using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using minimal_api.Domain.Services;

namespace minimal_api.Infraestrutura.Db
{
    public class MinimalContext : DbContext
    {
        private readonly IConfiguration _configuracaoAppSettings;

        public MinimalContext(IConfiguration configurationAppSettings)
        {
            _configuracaoAppSettings = configurationAppSettings;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var stringConexao = _configuracaoAppSettings.GetConnectionString("mysql")?.ToString();
                if (!string.IsNullOrEmpty(stringConexao))
                {
                    optionsBuilder.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
                }
            }
        }

        public DbSet<Administrador> administradores { get; set; } = default!;
    }
}