﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ClinicaOdontologicaPersistencia.Entidades
{
    public class Paciente
    {
        [Key] 
        public string CPF { get; set; }
        public string Nome { get; set; }

        [Column(TypeName = "timestamp(6)")]
        public DateTime DataNascimento { get; set; }

        public List<Consulta> Consultas { get; set; }

        [NotMapped]
        public int Idade
        {
            get
            {
                DateTime dataAtual = DateTime.Now;
                if (DataNascimento.Month > dataAtual.Month)
                    return dataAtual.Year - DataNascimento.Year;
                else
                    return dataAtual.Year - DataNascimento.Year - 1;
            }
        }

        public Paciente(string CPF, string Nome, DateTime DataNascimento)
        {
            this.CPF = CPF;
            this.Nome = Nome;
            this.DataNascimento = DataNascimento;
        }
    }
}
