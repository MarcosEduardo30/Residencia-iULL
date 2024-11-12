using ConsultorioOdontologico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico.LogicaDeNegocio.Validações
{
    // Classe estática com as validações referentes a interface gráfica e a criação de Pacientes.
    public static class PacienteValidacoes
    {
        public static string validarCPF(Consultorio consultorio, string CPF)
        {
            if (CPF == null || CPF == "")  
                return "Erro: CPF não pode ser nulo";
            if (!Int64.TryParse(CPF, out Int64 result)) 
                return "Erro: Favor digitar apenas números no CPF";
            if (!isCPFValid(CPF)) 
                return "Erro: CPF Inválido!";
            if (consultorio.isCPFCadastrado(CPF)) 
                return "Erro: CPF já cadastrado!";
            return "";
        }

        public static string isNomeValid(string nome)
        {
            if (nome == null || nome == "") return "Erro: Nome não pode ser nulo";
            if (nome.Length < 5) return "Erro: Nome deve ter mais de 5 letras";
            else return "";
        }
        public static bool isCPFValid(string CPF)
        {
            if (CPF.Length != 11) return false;
            else if (isAllNumbersTheSame(CPF)) return false;
            else if (!isDigitoVerificadorValid(10, CPF)) return false;
            else if (!isDigitoVerificadorValid(11, CPF)) return false;
            else return true;
        }
        public static bool isAllNumbersTheSame(string CPF)
        {
            for (int i = 0; i < CPF.Length - 2; i++)
            {
                if (CPF[i] != CPF[i + 1]) return false;
            }
            return true;
        }
        public static bool isDigitoVerificadorValid(int posicaoDigito, string CPF)
        {
            int somaDigitos = 0;
            int valMultiplicacao = posicaoDigito;
            for (int i = 0; i < posicaoDigito - 1; i++)
            {
                somaDigitos += int.Parse(CPF[i].ToString()) * valMultiplicacao;
                valMultiplicacao--;
            }
            int resto = somaDigitos % 11;
            string digito = resto == 0 || resto == 1 ? "0" : (11 - resto).ToString();

            if (CPF[posicaoDigito - 1].ToString() == digito) return true;
            else return false;
        }

        public static string isDataNascValid(string data)
        {
            string retorno;
            retorno = Validacoes.isDataFormatValid(data);
            if (retorno != "") return retorno;
            DateTime dataNasc = DateTime.Parse(data);

            DateTime dataAtual = DateTime.Now;
            int idade = 0;
            if (dataNasc.Month > dataAtual.Month) idade = dataAtual.Year - dataNasc.Year;
            else idade = dataAtual.Year - dataNasc.Year - 1;

            if (idade >= 13) return "";
            else return "Erro: O paciente deve possuir mais de 13 anos";
        }

        public static string isPacienteDeleteValid(Consultorio consultorio, string CPF)
        {
            if (!consultorio.isCPFCadastrado(CPF))
                return "Erro: CPF não cadastrado";
            if (consultorio.existeConsultaFutura(CPF))
                return "Erro: Paciente possui uma consulta futura. Não foi possível a exclusão.";
            return "";
        }
    }
}
