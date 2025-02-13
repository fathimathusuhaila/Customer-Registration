using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistration.DAL.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,Phone]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
    }
}
