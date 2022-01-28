using System.ComponentModel.DataAnnotations;

namespace TeCAS.SCA.WebAdmin.Models
{
    public class TransactionMoneyVM
    {
        [Display(Name = "Número de cuenta")]
        [Required(ErrorMessage = "El número de cuenta es necesario")]
        public string NoAccount { get; set; }
        [Display(Name = "Monto")]
        [Required(ErrorMessage = "El monto es necesario")]
        public decimal Amount { get; set; }
    }
}
