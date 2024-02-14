using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class User : BaseDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage = "The Email attribute to format")]
        public string Email { get; set; }

		public DateTime? CreateDate { get; set; }
		public DateTime BirthDate { get; set; }

        public string? UserCode { get; set; }

        [Required(ErrorMessage = "OwnedBy is required.")]
        public string OwnedBy { get; set; }

        [RegularExpression(@"^[6-8][0-9]{7}$", ErrorMessage = "Phone Number...")]
        [StringLength(8,ErrorMessage = "Phone Number 8 Characters",MinimumLength = 8)]
        public string? PhoneNumber { get; set; }

        public int Age
        {
            get
            {
                var dateNow = DateTime.Today;
                int calAge = dateNow.Year - BirthDate.Year;

                //Comprueba si el cumpleaños del usuario ya sucedio

                if(BirthDate > dateNow.AddYears(-calAge))
                {
                    calAge--;
                }
                return calAge;
            }
        }
        //El signo ? indica que No es un campo requerido
        
    }
}
