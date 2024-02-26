using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	public class Employer
	{
        [Column("EmployerId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Company Name is a required !!")]
        public string CompanyName { get; set; }
       
        public string Location { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        //Navigation
        public string UserId { get; set; }
        public User User { get; set; }
    }
}

