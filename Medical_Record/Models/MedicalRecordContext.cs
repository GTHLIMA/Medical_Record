using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_Record.Models
{
    public class MedicalRecordContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<EvolucaoPaciente> Evolucoes { get; set; }
        public DbSet<AnamneseAdulto> AnamnesesAdulto { get; set; }
        public DbSet<AtendimentoAdulto> AtendimentosAdulto { get; set; }
        public DbSet<ExamePsiquico> ExamesPsiquicos { get; set; }
        public DbSet<Pensamento> Pensamentos { get; set; }
        public DbSet<Linguagem> Linguagens { get; set; }
        public DbSet<Humor> Humores { get; set; }
        public DbSet<AnamneseInfantil> AnamnesesInfantil { get; set; }
        public DbSet<AtendimentoInfantil> AtendimentosInfantil { get; set; }
        public DbSet<Concepcao> Concepcoes { get; set; }
        public DbSet<DesenvolvimentoMotor> Desenvolvimentos { get; set; }
        public DbSet<Social> Sociais { get; set; }
        public DbSet<DadosEscolares> DadosEscolares { get; set; }
        public DbSet<SaudeFisica> SaudeFisicas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= MedicalRecord.db");
        }
    }
}
