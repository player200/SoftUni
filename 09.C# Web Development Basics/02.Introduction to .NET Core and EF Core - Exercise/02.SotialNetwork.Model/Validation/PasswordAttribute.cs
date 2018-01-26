namespace _02.SotialNetwork.Model.Validation
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class PasswordAttribute : ValidationAttribute
    {
        private readonly char[] AllowedSymbols = new[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '<', '>', '?' };

        public PasswordAttribute()
        {
            this.ErrorMessage = "Password is invalid!";
        }

        public override bool IsValid(object value)
        {
            var password = value as string;
            if (password == null)
            {
                return true;
            }

            return password.All(p => char.IsLower(p) 
            || char.IsUpper(p)
            || char.IsDigit(p)
            || this.AllowedSymbols.Contains(p));
        }
    }
}