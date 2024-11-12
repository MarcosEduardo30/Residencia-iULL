using ConsultorioOdontologico.Entidades;

namespace ConsultorioOdontologico.LogicaDeNegocio.Validações
{
    public static class ConsultaValidacoes
    {
        // Classe estática com as validações referentes a interface gráfica e a classe de Consultas.
        public static string isCpfValid(Consultorio consultorio, string CPF)
        {
            if (!consultorio.isCPFCadastrado(CPF))
                return "Erro: Não há paciente com o CPF cadastrado";
            if (consultorio.existeConsultaFutura(CPF))
                return "Erro: paciente já possui uma consulta marcada";
            else
                return "";
        }
        public static string isHorarioValid(Consultorio consultorio, string Data, TimeOnly horaInicial, TimeOnly horaFinal)
        {
            DateOnly dataConsulta = DateOnly.Parse(Data);
            if (horaInicial > horaFinal)
                return "Erro: Horário selecionado deve ser um horário válido";
            if (!isDataFutura(dataConsulta, horaInicial))
                return "Erro: Horário selecionado já passou. Por favor selecionar um horário no futuro.";
            if (consultorio.isHoraOcupada(dataConsulta, horaInicial, horaFinal))
                return "Erro: Já existe uma consulta neste horário. Por favor selecione outro.";
            return "";

        }
        public static bool isDataFutura(DateOnly dataConsulta, TimeOnly HoraInicial) {
            DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly horaAtual = TimeOnly.FromDateTime(DateTime.Now);
            if (dataConsulta < dataAtual || (dataConsulta == dataAtual && HoraInicial < horaAtual))
                return false;
            return true;
        }
        public static bool temSobreposicaoHorario(this Consulta consulta, TimeOnly inicio, TimeOnly fim)
        {
            if (consulta.horaInicio >= inicio && consulta.horaInicio <= fim) return true;
            else if (consulta.horaFim >= inicio && consulta.horaFim <= fim) return true;
            else if (inicio >= consulta.horaInicio && inicio <= consulta.horaFim) return true;
            else if (fim >= consulta.horaInicio && fim <= consulta.horaFim) return true;
            else return false;
        }
    }
}
