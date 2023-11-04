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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Phone(ErrorMessage = "Invalid contact number.")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Range(0, 1000, ErrorMessage = "Weight must be between 0 and 1000.")]
        public double Weight { get; set; }

        [Range(0, 300, ErrorMessage = "Height must be between 0 and 300.")]
        public double Height { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Address must be less than 100 characters.")]
        public string Address { get; set; }

        [StringLength(500, ErrorMessage = "Medical comments must be less than 500 characters.")]
        [Display(Name = "Medical Comments")]
        public string MedicalComments { get; set; }

        [Display(Name = "Any Medications Taking")]
        public bool AnyMedicationsTaking { get; set; }

        [Required(ErrorMessage = "CreatedDate is required.")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "UpdatedDate is required.")]
        public DateTime UpdatedDate { get; set; }
    }
}
