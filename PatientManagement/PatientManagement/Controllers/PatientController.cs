using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Model;
using PatientManagement.Repository;

namespace PatientManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientRepository.GetAllPatientsDetails();
            if (patients != null && patients.Count() > 0)
            {
                return Ok(patients);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById([FromRoute] int id)
        {
            var patients = await _patientRepository.GetPatientById(id);
            if (patients == null)
            {
                return NotFound();
            }
            return Ok(patients);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewPatient([FromBody] Patient patient)
        {
            try
            {
                var newPatientId = await _patientRepository.AddPatient(patient);
                return CreatedAtAction(nameof(GetPatientById), new { id = newPatientId, Controller = "Patient" }, newPatientId);
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid request data");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAllElementsInPatient([FromBody] Patient patient, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatedPatient = await _patientRepository.EntireResourceUpdateInPatient(id, patient);

                if (updatedPatient == null)
                {
                    return NotFound();
                }

                return Ok(updatedPatient);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while processing the request.");
            }
        }
    }
}
