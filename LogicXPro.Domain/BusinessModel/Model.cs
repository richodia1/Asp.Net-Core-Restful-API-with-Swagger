using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LogicXPro.Domain.BusinessModel
{
    public class Model : IValidatableObject
    {
        public void Validate()
        {
            var errors = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, new ValidationContext(this, serviceProvider: null, items: null), errors, true);
            if (!isValid)
            {
                var errorMessages = errors.Select(e => e.ErrorMessage);
                var message = string.Join(",", errorMessages);
                throw new Exception(message);
            }
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            return errors;
        }
    }
}
