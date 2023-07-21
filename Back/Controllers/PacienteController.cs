using AutoMapper;
using Back.Models;
using Back.Models.DTO;
using Back.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPacienteRepositoriy _pacienteRepository;

        public PacienteController(IMapper mapper, IPacienteRepositoriy pacienteRepositoriy)
        {
            _mapper = mapper;
            _pacienteRepository = pacienteRepositoriy;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaPacientes = await _pacienteRepository.GetListPacientes();
                var listaPacientesDto = _mapper.Map<IEnumerable<PacienteDTO>>(listaPacientes);

                return Ok(listaPacientesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var paciente = await _pacienteRepository.GetPaciente(id);

                if (paciente == null)
                {
                    return NotFound();
                }

                var pacienteDto = _mapper.Map<PacienteDTO>(paciente);

                return Ok(pacienteDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var paciente = await _pacienteRepository.GetPaciente(id);

                if (paciente == null)
                {
                    return NotFound();
                }

                await _pacienteRepository.DeletePaciente(paciente);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Paciente PacienteDto)
        {
            try
            {
                var paciente = _mapper.Map<Paciente>(PacienteDto);

                paciente.FechaCreacion = DateTime.Now;

                paciente = await _pacienteRepository.AddPaciente(paciente);

                var pacienteItemDto = _mapper.Map<PacienteDTO>(paciente);

                return CreatedAtAction("Get", new { id = pacienteItemDto.Id }, pacienteItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PacienteDTO pacienteDto)
        {
            try
            {
                var paciente = _mapper.Map<Paciente>(pacienteDto);

                if (id != paciente.Id)
                    return BadRequest();

                var pacienteItem = await _pacienteRepository.GetPaciente(id);

                if (pacienteItem == null)
                    return NotFound();

                await _pacienteRepository.UpdatePaciente(paciente);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
