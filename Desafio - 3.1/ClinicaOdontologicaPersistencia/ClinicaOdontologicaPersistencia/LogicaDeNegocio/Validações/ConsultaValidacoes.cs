using ClinicaOdontologicaPersistencia.Entidades;

namespace ClinicaOdontologicaPersistencia.LogicaDeNegocio.Validações
{
    public static class ConsultaValidacoes
    {
        // Classe estática com as validações referentes a interface gráfica e a classe de Consultas.
        static readonly PacienteController PacCon = new PacienteController();
        static readonly ConsultaController ConsulCon = new ConsultaController();

        public static string isCpfValid(string CPF)
        {
            if (!PacienteValidacoes.isCPFCadastrado(CPF))
                return "Erro: Não há paciente com o CPF cadastrado";
            if (existeConsultaFutura(CPF))
                return "Erro: paciente já possui uma consulta marcada";
            else
                return "";
        }
        public static string isHorarioValid(string Data, TimeOnly horaInicial, TimeOnly horaFinal)
        {
            DateOnly dataConsulta = DateOnly.Parse(Data);
            if (horaInicial > horaFinal)
                return "Erro: Horário selecionado deve ser um horário válido";
            if (!isDataFutura(dataConsulta, horaInicial))
                return "Erro: Horário selecionado já passou. Por favor selecionar um horário no futuro.";
            if (isHoraOcupada(dataConsulta, horaInicial, horaFinal))
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

        public static bool existeConsultaFutura(string CPF)
        {
            DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly horaAtual = TimeOnly.FromDateTime(DateTime.Now);
            Consulta? consultaFutura = ConsulCon.ListarConsultasFuturas(CPF);

            if (consultaFutura != null)
                return true;
            else
                return false;
        }

        public static bool isHoraOcupada(DateOnly dataConsulta, TimeOnly horaInicial, TimeOnly horaFinal)
        {
            List<Consulta> consultas = ConsulCon.ListarConsultas();
            if (consultas.Exists(c => c.dataConsulta == dataConsulta && c.temSobreposicaoHorario(horaInicial, horaFinal)))
                return true;
            else
                return false;
        }
    }
}
