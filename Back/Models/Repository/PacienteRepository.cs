using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Back.Models.Repository
{
    public class PacienteRepository : IPacienteRepositoriy
    {
        private readonly AplicationDbContext _context;

        public PacienteRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Paciente> AddPaciente(Paciente paciente)
        {
            _context.Add(paciente);
            try
            {
                await _context.SaveChangesAsync();
                return paciente;
            }
            catch (Exception ex)
            {
                var mesnaje = ex.Message.Split(' ');
                return paciente;
            }
            
        }

        public async Task DeletePaciente(Paciente paciente)
        {
            _context.pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Paciente>> GetListPacientes()
        {
            return await _context.pacientes.ToListAsync();
        }

        public async Task<Paciente> GetPaciente(int id)
        {
            return await _context.pacientes.FindAsync(id);
        }

        public async Task UpdatePaciente(Paciente paciente)
        {
            var pacienteItem = await _context.pacientes.FirstOrDefaultAsync(x => x.Id == paciente.Id);

            if (pacienteItem != null)
            {
                pacienteItem.Nombres = paciente.Nombres;
                pacienteItem.Apellidos = paciente.Apellidos;
                pacienteItem.TipoDocumento = paciente.TipoDocumento;
                pacienteItem.NumeroDocumento = paciente.NumeroDocumento;
                pacienteItem.fechaNacimiento = paciente.fechaNacimiento;
                pacienteItem.CiudadRecidencia = paciente.CiudadRecidencia;

                await _context.SaveChangesAsync();

            }
        }
    }
}
