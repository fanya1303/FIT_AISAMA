using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIT_AISTAMA.Validation.Models
{
    public class ValidationInfo
    {
        public bool IsValid { get; set; }

        public string ValidationMessage { get; set; }


        public ValidationInfo(bool valid = true, string message = null)
        {
            IsValid = valid;
            ValidationMessage = message;
        }

        public static ValidationInfo addError(string errorMessage)
        {
            return new ValidationInfo(false, errorMessage);
        }

        public static ValidationInfo isValid()
        {
            return new ValidationInfo();
        }
    }
}
