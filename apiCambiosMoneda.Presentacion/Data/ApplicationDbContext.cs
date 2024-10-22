using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apiCambiosMoneda.Dominio.Entidades;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<apiCambiosMoneda.Dominio.Entidades.Moneda> Moneda { get; set; } = default!;
    }
