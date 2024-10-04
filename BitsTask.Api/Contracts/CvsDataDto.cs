using System.ComponentModel.DataAnnotations;

namespace BitsTask.Contracts;

public record CsvDataDto
{
   public Guid Id { get; set; }
   [Required] public string Name { get; init; }
   [Required] public DateTime DateOfBirth { get; init; }
   [Required] public bool Married { get; init; }
   [Required] public string Phone { get; init; }
   [Required] public decimal Salary { get; init; }
}