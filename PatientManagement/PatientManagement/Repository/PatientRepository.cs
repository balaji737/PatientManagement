using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientManagement.Model;

namespace PatientManagement.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientDbContext _context;
        private readonly IMapper _mapper;

        public PatientRepository(PatientDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Patient>> GetAllPatientsDetails()
        {
            var records = await _context.Patients.ToListAsync();
            return records;
        }

        public async Task<Patient> GetPatientById(int id)
        {
            var patientsInfo = await _context.Patients.FindAsync(id);
            return _mapper.Map<Patient>(patientsInfo);

        }

        public async Task<bool> GetUniquePatient(string name)
        {
            return await _context.Patients.AnyAsync(patients => patients.FirstName == name);
        }

        public async Task<int> AddPatient(Patient patient)
        {
            if (await GetUniquePatient(patient.FirstName))
            {
                throw new Exception("Employee with similar name already exists.");
            }
            patient.CreatedDate = DateTime.Now;
            _context.Patients.Add(patient);

            await _context.SaveChangesAsync();
            return patient.Id;
        }

        public async Task<Patient> EntireResourceUpdateInPatient(int id, Patient patient)
        {
            var existingPatient = await _context.Patients.FindAsync(id);

            if (existingPatient == null)
            {
                return null;
            }

            patient.UpdatedDate = DateTime.Now;
            _context.Patients.Add(patient);

            await _context.SaveChangesAsync();
            return existingPatient;
        }
    }
}
