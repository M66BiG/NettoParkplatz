using System.ComponentModel.DataAnnotations;

namespace BeeckerLearningGround.Models;

public class Number
{
    [Required()]
    [MinLength(3)]
    public string? Term { get; set; }
}
