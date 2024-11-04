using ConsultorioOdontologico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOdontologico.LogicaDeNegocio.Validações
{
    public static class PacienteValidacoes
    {
        public static string validarCPF(string CPF, Consultorio consultorio)
        {
            if (CPF == null || CPF == "")  
                return "Erro: CPF não pode ser nulo";
            if (!Int64.TryParse(CPF, out Int64 result)) 
                return "Erro: Favor digitar apenas números no CPF";
            if (!isCPFValid(CPF)) 
                return "Erro: CPF Inválido!";
            if (isCPFCadastrado(consultorio, CPF)) 
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


        public static string isDataFormatValid(string data)
        {
            string[] subData = data.Split('/');
            if (subData.Length != 3) return "Erro: Data formatada errada! Por favor colocar a data no formato DD/MM/AAAA";
            if (subData[0].Length != 2 || subData[1].Length != 2 || subData[2].Length != 4) 
                return "Erro: Data formatada errada! Por favor colocar a data no formato DD/MM/AAAA";
            int dia;
            int mes;
            int ano;

            if (!int.TryParse(subData[0], out dia) || !int.TryParse(subData[1], out mes) || !int.TryParse(subData[2], out ano))
                return "Erro: Data possui um valor não númerico";

            if (mes > 12 || mes < 1) return "Erro: Mes inválido";
            switch (mes)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    if (dia > 31 || dia < 1) return "Erro: Dia Inválido"; 
                    break;
                case 4: case 9: case 11:
                    if (dia > 30 || dia < 1) return "Erro: Dia Inválido";
                    break;
                case 2:
                    if (ano % 4 == 0){
                        if (dia > 29 || dia < 1) return "Erro: Dia Inválido";
                    }
                    else{
                        if (dia > 28 || dia < 1) return "Erro: Dia Inválido";
                    }
                    break;
            }
            if (ano < 1) return "Erro: Ano Inválido!";
            else return "";

        }

        public static string isDataNascValid(string data)
        {
            string retorno;
            retorno = isDataFormatValid(data);
            if (retorno != "") return retorno;
            DateTime dataNasc = DateTime.Parse(data);

            DateTime dataAtual = DateTime.Now;
            int idade = 0;
            if (dataNasc.Month > dataAtual.Month) idade = dataAtual.Year - dataNasc.Year;
            else idade = dataAtual.Year - dataNasc.Year - 1;

            if (idade >= 13) return "";
            else return "Erro: O paciente deve possuir mais de 13 anos";
        }

        public static bool isCPFCadastrado(this Consultorio consultorio, string CPF)
        {
            if (consultorio.pacientes.Exists(p => p.CPF == CPF)) return true;
            else return false;
        }

    }
}
