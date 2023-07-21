namespace Back.Models.Repository
{
    public interface IPacienteRepositoriy
    {
        Task<List<Paciente>> GetListPacientes();
        Task<Paciente> GetPaciente(int id);
        Task DeletePaciente(Paciente paciente);
        Task<Paciente> AddPaciente(Paciente paciente);
        Task UpdatePaciente(Paciente paciente);
    }
}
