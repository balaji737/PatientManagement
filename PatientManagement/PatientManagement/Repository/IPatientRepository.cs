using PatientManagement.Model;

namespace PatientManagement.Repository
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllPatientsDetails();
        Task<Patient> GetPatientById(int id);
        Task<int> AddPatient(Patient patient);
        Task<Patient> EntireResourceUpdateInPatient(int id, Patient patient);    
    }
}
