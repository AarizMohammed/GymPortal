using System;
using System.ComponentModel.DataAnnotations;

namespace GymPortal.Models;

public class MemberSignupViewModel
{
    [Required]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
    public string Name { get; set; }

    [Required]
    [Range(16, 120, ErrorMessage = "Age must be 16 or older.")]
    public int Age { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [Required]
    [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number.")]
    public string Phone { get; set; }

    [Required]
    public string MembershipType { get; set; }

    [Required]
    public int Discount { get; set; }
    




}
