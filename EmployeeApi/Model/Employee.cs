using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Model
{
    public class Employee
    {
        [Required]
        [StringLength(maximumLength: 5, MinimumLength = 5, ErrorMessage = "請輸入 5 個字元")]
        public required string Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "名字長度不可超過 30")]
        public required string Name { get; set; }
        [Range(1.0, 10.0)]
        public double Grade { get; set; }
    }
}
