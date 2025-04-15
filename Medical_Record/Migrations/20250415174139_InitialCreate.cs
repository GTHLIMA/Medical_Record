using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical_Record.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id_Paciente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Idade = table.Column<int>(type: "INTEGER", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Sexo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id_Paciente);
                });

            migrationBuilder.CreateTable(
                name: "AnamnesesAdulto",
                columns: table => new
                {
                    Id_Adulto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Paciente = table.Column<int>(type: "INTEGER", nullable: false),
                    Data_Anamnese = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Data_Nascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Naturalidade = table.Column<string>(type: "TEXT", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnamnesesAdulto", x => x.Id_Adulto);
                    table.ForeignKey(
                        name: "FK_AnamnesesAdulto_Pacientes_Id_Paciente",
                        column: x => x.Id_Paciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id_Paciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnamnesesInfantil",
                columns: table => new
                {
                    Id_Infantil = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Paciente = table.Column<int>(type: "INTEGER", nullable: false),
                    Data_Anamnese = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nome_Mae = table.Column<string>(type: "TEXT", nullable: false),
                    Idade_Mae = table.Column<int>(type: "INTEGER", nullable: false),
                    Profissao_Mae = table.Column<string>(type: "TEXT", nullable: false),
                    Nome_Pai = table.Column<string>(type: "TEXT", nullable: false),
                    Idade_Pai = table.Column<int>(type: "INTEGER", nullable: false),
                    Profissao_Pai = table.Column<string>(type: "TEXT", nullable: false),
                    Data_Nascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Naturalidade = table.Column<string>(type: "TEXT", nullable: false),
                    Irmaos = table.Column<int>(type: "INTEGER", nullable: false),
                    Masculino = table.Column<int>(type: "INTEGER", nullable: false),
                    Feminino = table.Column<int>(type: "INTEGER", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnamnesesInfantil", x => x.Id_Infantil);
                    table.ForeignKey(
                        name: "FK_AnamnesesInfantil_Pacientes_Id_Paciente",
                        column: x => x.Id_Paciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id_Paciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evolucoes",
                columns: table => new
                {
                    Id_Evolucao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Paciente = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evolucoes", x => x.Id_Evolucao);
                    table.ForeignKey(
                        name: "FK_Evolucoes_Pacientes_Id_Paciente",
                        column: x => x.Id_Paciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id_Paciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtendimentosAdulto",
                columns: table => new
                {
                    Id_Atendimento_Adulto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Adulto = table.Column<int>(type: "INTEGER", nullable: false),
                    Neuropsicologo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Neuropsquiatra = table.Column<bool>(type: "INTEGER", nullable: false),
                    Psicologo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Ambulatorio = table.Column<bool>(type: "INTEGER", nullable: false),
                    Internamento = table.Column<bool>(type: "INTEGER", nullable: false),
                    Encaminhado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Queixa_Motivo = table.Column<string>(type: "TEXT", nullable: false),
                    Avaliacao_Demanda = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentosAdulto", x => x.Id_Atendimento_Adulto);
                    table.ForeignKey(
                        name: "FK_AtendimentosAdulto_AnamnesesAdulto_Id_Adulto",
                        column: x => x.Id_Adulto,
                        principalTable: "AnamnesesAdulto",
                        principalColumn: "Id_Adulto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamesPsiquicos",
                columns: table => new
                {
                    Id_Exame = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Adulto = table.Column<int>(type: "INTEGER", nullable: false),
                    Aparencia = table.Column<string>(type: "TEXT", nullable: false),
                    Comportamento = table.Column<string>(type: "TEXT", nullable: false),
                    Cooperativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Resistente = table.Column<bool>(type: "INTEGER", nullable: false),
                    Indiferente = table.Column<bool>(type: "INTEGER", nullable: false),
                    Memoria = table.Column<string>(type: "TEXT", nullable: false),
                    Inteligencia = table.Column<string>(type: "TEXT", nullable: false),
                    Sensopercepcao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamesPsiquicos", x => x.Id_Exame);
                    table.ForeignKey(
                        name: "FK_ExamesPsiquicos_AnamnesesAdulto_Id_Adulto",
                        column: x => x.Id_Adulto,
                        principalTable: "AnamnesesAdulto",
                        principalColumn: "Id_Adulto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtendimentosInfantil",
                columns: table => new
                {
                    Id_Atendimento_Infantil = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Infantil = table.Column<int>(type: "INTEGER", nullable: false),
                    Neuropsicologo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Neuropsquiatra = table.Column<bool>(type: "INTEGER", nullable: false),
                    Psicologo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Ambulatorio = table.Column<bool>(type: "INTEGER", nullable: false),
                    Internamento = table.Column<bool>(type: "INTEGER", nullable: false),
                    Encaminhado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Queixa_Motivo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentosInfantil", x => x.Id_Atendimento_Infantil);
                    table.ForeignKey(
                        name: "FK_AtendimentosInfantil_AnamnesesInfantil_Id_Infantil",
                        column: x => x.Id_Infantil,
                        principalTable: "AnamnesesInfantil",
                        principalColumn: "Id_Infantil",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Concepcoes",
                columns: table => new
                {
                    Id_Concepcao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Infantil = table.Column<int>(type: "INTEGER", nullable: false),
                    Gravidez_Planejada = table.Column<bool>(type: "INTEGER", nullable: false),
                    Idade_Concepcao_Mae = table.Column<int>(type: "INTEGER", nullable: false),
                    Idade_Concepcao_Pai = table.Column<int>(type: "INTEGER", nullable: false),
                    Gestacoes_Anteriores = table.Column<bool>(type: "INTEGER", nullable: false),
                    Quantidade_Gestacoes = table.Column<int>(type: "INTEGER", nullable: false),
                    Ordem_Nascimento = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concepcoes", x => x.Id_Concepcao);
                    table.ForeignKey(
                        name: "FK_Concepcoes_AnamnesesInfantil_Id_Infantil",
                        column: x => x.Id_Infantil,
                        principalTable: "AnamnesesInfantil",
                        principalColumn: "Id_Infantil",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DadosEscolares",
                columns: table => new
                {
                    Id_Escolar = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Infantil = table.Column<int>(type: "INTEGER", nullable: false),
                    Frequenta_Escola = table.Column<bool>(type: "INTEGER", nullable: false),
                    Idade_Inicio = table.Column<int>(type: "INTEGER", nullable: false),
                    Adptacao = table.Column<string>(type: "TEXT", nullable: false),
                    Atendimento_Especializado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Quais_Atendimentos = table.Column<string>(type: "TEXT", nullable: false),
                    Atendimento_Motivo = table.Column<string>(type: "TEXT", nullable: false),
                    Problemas_Escolares = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tipo_Problemas = table.Column<string>(type: "TEXT", nullable: false),
                    Quando_Comecaram = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosEscolares", x => x.Id_Escolar);
                    table.ForeignKey(
                        name: "FK_DadosEscolares_AnamnesesInfantil_Id_Infantil",
                        column: x => x.Id_Infantil,
                        principalTable: "AnamnesesInfantil",
                        principalColumn: "Id_Infantil",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Desenvolvimentos",
                columns: table => new
                {
                    Id_Desenvolvimento = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Infantil = table.Column<int>(type: "INTEGER", nullable: false),
                    Idade_Engatinhou = table.Column<int>(type: "INTEGER", nullable: false),
                    Idade_Andou = table.Column<int>(type: "INTEGER", nullable: false),
                    Idade_Falou = table.Column<int>(type: "INTEGER", nullable: false),
                    Problema_Fala = table.Column<bool>(type: "INTEGER", nullable: false),
                    Detalhes_Problema_Fala = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvimentos", x => x.Id_Desenvolvimento);
                    table.ForeignKey(
                        name: "FK_Desenvolvimentos_AnamnesesInfantil_Id_Infantil",
                        column: x => x.Id_Infantil,
                        principalTable: "AnamnesesInfantil",
                        principalColumn: "Id_Infantil",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaudeFisicas",
                columns: table => new
                {
                    Id_Saude = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Infantil = table.Column<int>(type: "INTEGER", nullable: false),
                    Doencas_Infantis = table.Column<string>(type: "TEXT", nullable: false),
                    Cirugias_Internacoes = table.Column<string>(type: "TEXT", nullable: false),
                    Tratamentos = table.Column<string>(type: "TEXT", nullable: false),
                    Uso_Medicamento = table.Column<bool>(type: "INTEGER", nullable: false),
                    Quais_Medicamentos = table.Column<string>(type: "TEXT", nullable: false),
                    Antecedentes_Familiares = table.Column<string>(type: "TEXT", nullable: false),
                    Motivo_Queixa = table.Column<string>(type: "TEXT", nullable: false),
                    Quando_Como_Iniciou = table.Column<string>(type: "TEXT", nullable: false),
                    Enxergam_Problema = table.Column<string>(type: "TEXT", nullable: false),
                    Espectativas = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaudeFisicas", x => x.Id_Saude);
                    table.ForeignKey(
                        name: "FK_SaudeFisicas_AnamnesesInfantil_Id_Infantil",
                        column: x => x.Id_Infantil,
                        principalTable: "AnamnesesInfantil",
                        principalColumn: "Id_Infantil",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sociais",
                columns: table => new
                {
                    Id_Social = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Infantil = table.Column<int>(type: "INTEGER", nullable: false),
                    Interacao_Pais = table.Column<string>(type: "TEXT", nullable: false),
                    Interacao_Irmaos = table.Column<string>(type: "TEXT", nullable: false),
                    Interacao_Outros = table.Column<string>(type: "TEXT", nullable: false),
                    Atitude_Estranhos = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sociais", x => x.Id_Social);
                    table.ForeignKey(
                        name: "FK_Sociais_AnamnesesInfantil_Id_Infantil",
                        column: x => x.Id_Infantil,
                        principalTable: "AnamnesesInfantil",
                        principalColumn: "Id_Infantil",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Humores",
                columns: table => new
                {
                    Id_Humor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Exame = table.Column<int>(type: "INTEGER", nullable: false),
                    IsHumorous = table.Column<bool>(type: "INTEGER", nullable: false),
                    Exaltado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Baixo_Humor = table.Column<bool>(type: "INTEGER", nullable: false),
                    Quebra_Subta = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humores", x => x.Id_Humor);
                    table.ForeignKey(
                        name: "FK_Humores_ExamesPsiquicos_Id_Exame",
                        column: x => x.Id_Exame,
                        principalTable: "ExamesPsiquicos",
                        principalColumn: "Id_Exame",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Linguagens",
                columns: table => new
                {
                    Id_Linguagem = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Exame = table.Column<int>(type: "INTEGER", nullable: false),
                    Suicida = table.Column<bool>(type: "INTEGER", nullable: false),
                    Disartria = table.Column<bool>(type: "INTEGER", nullable: false),
                    Afasias = table.Column<bool>(type: "INTEGER", nullable: false),
                    Parafasia = table.Column<bool>(type: "INTEGER", nullable: false),
                    Neologismo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Mussitacao = table.Column<bool>(type: "INTEGER", nullable: false),
                    Logorreia = table.Column<bool>(type: "INTEGER", nullable: false),
                    Para_Respostas = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linguagens", x => x.Id_Linguagem);
                    table.ForeignKey(
                        name: "FK_Linguagens_ExamesPsiquicos_Id_Exame",
                        column: x => x.Id_Exame,
                        principalTable: "ExamesPsiquicos",
                        principalColumn: "Id_Exame",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pensamentos",
                columns: table => new
                {
                    Id_Pensamento = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Exame = table.Column<int>(type: "INTEGER", nullable: false),
                    Acelerado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Retardado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Fuga = table.Column<bool>(type: "INTEGER", nullable: false),
                    Bloqueio = table.Column<bool>(type: "INTEGER", nullable: false),
                    Prolixo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Repeticao = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pensamentos", x => x.Id_Pensamento);
                    table.ForeignKey(
                        name: "FK_Pensamentos_ExamesPsiquicos_Id_Exame",
                        column: x => x.Id_Exame,
                        principalTable: "ExamesPsiquicos",
                        principalColumn: "Id_Exame",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnamnesesAdulto_Id_Paciente",
                table: "AnamnesesAdulto",
                column: "Id_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_AnamnesesInfantil_Id_Paciente",
                table: "AnamnesesInfantil",
                column: "Id_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentosAdulto_Id_Adulto",
                table: "AtendimentosAdulto",
                column: "Id_Adulto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentosInfantil_Id_Infantil",
                table: "AtendimentosInfantil",
                column: "Id_Infantil",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concepcoes_Id_Infantil",
                table: "Concepcoes",
                column: "Id_Infantil",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DadosEscolares_Id_Infantil",
                table: "DadosEscolares",
                column: "Id_Infantil",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Desenvolvimentos_Id_Infantil",
                table: "Desenvolvimentos",
                column: "Id_Infantil",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evolucoes_Id_Paciente",
                table: "Evolucoes",
                column: "Id_Paciente");

            migrationBuilder.CreateIndex(
                name: "IX_ExamesPsiquicos_Id_Adulto",
                table: "ExamesPsiquicos",
                column: "Id_Adulto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Humores_Id_Exame",
                table: "Humores",
                column: "Id_Exame",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Linguagens_Id_Exame",
                table: "Linguagens",
                column: "Id_Exame",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pensamentos_Id_Exame",
                table: "Pensamentos",
                column: "Id_Exame",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaudeFisicas_Id_Infantil",
                table: "SaudeFisicas",
                column: "Id_Infantil",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sociais_Id_Infantil",
                table: "Sociais",
                column: "Id_Infantil",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtendimentosAdulto");

            migrationBuilder.DropTable(
                name: "AtendimentosInfantil");

            migrationBuilder.DropTable(
                name: "Concepcoes");

            migrationBuilder.DropTable(
                name: "DadosEscolares");

            migrationBuilder.DropTable(
                name: "Desenvolvimentos");

            migrationBuilder.DropTable(
                name: "Evolucoes");

            migrationBuilder.DropTable(
                name: "Humores");

            migrationBuilder.DropTable(
                name: "Linguagens");

            migrationBuilder.DropTable(
                name: "Pensamentos");

            migrationBuilder.DropTable(
                name: "SaudeFisicas");

            migrationBuilder.DropTable(
                name: "Sociais");

            migrationBuilder.DropTable(
                name: "ExamesPsiquicos");

            migrationBuilder.DropTable(
                name: "AnamnesesInfantil");

            migrationBuilder.DropTable(
                name: "AnamnesesAdulto");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
