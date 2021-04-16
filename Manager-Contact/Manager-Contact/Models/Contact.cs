using Manager_Contact.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Manager_Contact.Models
{
    public class Contact : IValidatableObject
    {
        [Key]
        
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Index("Ix_ContactName", Order = 1, IsUnique = true)]
        public string ContactName { get; set; }
        [Required]
        public string NumberName { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public DateTime Birthday { get; set; }
        public  string  Infor { get; set; }
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            ContactContext db = new ContactContext();
            List<ValidationResult> validationResult = new List<ValidationResult>();
            var validateName = db.Contacts.FirstOrDefault(x => x.ContactName == ContactName);
            if (validateName != null)
            {
                ValidationResult errorMessage = new ValidationResult("Contact name already exists.", new[] { "ContactName" });
                validationResult.Add(errorMessage);
            }

            return validationResult;
        }
    }
}