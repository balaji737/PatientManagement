using System.ComponentModel.DataAnnotations;

namespace PatientManagement.Model
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be between 1 and 50 characters.", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be between 1 and 50 characters.", MinimumLength = 1)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "ContactNumber is required.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        [Range(0, 1000, ErrorMessage = "Weight must be between 0 and 1000.")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Height is required.")]
        [Range(0, 300, ErrorMessage = "Height must be between 0 and 300.")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address must be less than 100 characters.")]
        public string Address { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Medical comments must be less than 500 characters.")]
        public string MedicalComments { get; set; }

        [Required(ErrorMessage = "AnyMedication Taking is required.")]
        public bool AnyMedicationsTaking { get; set; }

        [Required(ErrorMessage = "CreatedDate is required.")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "UpdatedDate is required.")]
        public DateTime UpdatedDate { get; set; }
    }
}
