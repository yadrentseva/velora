using System.ComponentModel.DataAnnotations;

namespace velora.Models
{
    public class EventRequestDto : IValidatableObject
    {
        [Required]
        [MaxLength(500)]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public DateTime? StartAt { get; set; }

        [Required]
        public DateTime? EndAt { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartAt == DateTime.MinValue || EndAt == DateTime.MinValue)
                yield return new ValidationResult("The StartAt and EndAt cannot be empty.");
            
            if (EndAt <= StartAt)
                yield return new ValidationResult("The EndAt is earlier than the StartAt");
        }
    }

}
