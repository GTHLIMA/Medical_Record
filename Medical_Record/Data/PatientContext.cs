using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_Record.Data
{
    public class PatientContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<AnamneseAdulto> AnamnesesAdulto { get; set; }
        public DbSet<AnamneseInfantil> AnamnesesInfantil { get; set; }
        public DbSet<EvolucaoPaciente> Evolucoes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = patient.db");
        }


    }
}
