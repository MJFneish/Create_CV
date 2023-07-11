using cv_web_application.Models;
using System.ComponentModel.DataAnnotations;

public static class VerificationValidator
{
    public static ValidationResult ValidateVerification(VerficationNumber verification, ValidationContext validationContext)
    {
        if (verification.Nbr3 == (verification.Nbr1 + verification.Nbr2))
        {
            return ValidationResult.Success;
        }

        string errorMessage = "The summation of Nbr1 and Nbr2 is incorrect.";
        return new ValidationResult(errorMessage, new[] { validationContext.MemberName });
    }
}
