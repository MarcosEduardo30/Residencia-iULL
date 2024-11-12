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
        public int Idade { 
            get 
            {
                DateTime dataAtual = DateTime.Now;
                if (DataNascimento.Month > dataAtual.Month)
                    return dataAtual.Year - DataNascimento.Year;
                else
                    return  dataAtual.Year - DataNascimento.Year - 1;
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
