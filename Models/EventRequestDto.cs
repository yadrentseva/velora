using System.ComponentModel.DataAnnotations;

namespace velora.Models
{
    public class EventRequestDto: IValidatableObject
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }
        
        [Required]
        public DateTime? StartAt { get; set; }
        
        [Required]
        public DateTime? EndAt { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndAt <= StartAt)
                yield return new ValidationResult("The EndAt is earlier than the StartAt");
        }
    }

}
