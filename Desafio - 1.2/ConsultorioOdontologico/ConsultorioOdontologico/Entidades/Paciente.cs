using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico.Entidades
{
    public class Paciente
    {
        public string CPF;
        public string Nome;
        public DateTime DataNascimento;

        public Paciente(string CPF, string Nome, DateTime DataNascimento)
        {
            this.CPF = CPF;
            this.Nome = Nome;
            this.DataNascimento = DataNascimento;
        }
    }
}
