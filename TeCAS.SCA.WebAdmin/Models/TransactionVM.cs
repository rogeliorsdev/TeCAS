using System;
using System.ComponentModel.DataAnnotations;
using static TeCAS.SCA.Entities.Enumerations.EnumerationLists;

namespace TeCAS.SCA.WebAdmin.Models
{
    public class TransactionVM
    {
        public Guid Id { get; set; }
        [Display(Name = "Cuenta")]
        [Required(ErrorMessage = "La cuenta es necesaria para realizar la transacción")]
        public Guid AccountId { get; set; }


        [Display(Name = "Saldo actual")]
        public decimal CurrentBalance { get; set; }

        [Display(Name = "Movimiento")]
        [Required(ErrorMessage = "El monto es necesario para realizar la transacción")]
        public decimal Amount { get; set; }

        [Display(Name = "Tipo de transacción")]
        public string TypeTransaction { get; set; }

        [Display(Name = "No. Cuenta")]
        public string NoAccount { get; set; }
        [Display(Name = "Cliente")]
        public string CustomerName { get; set; }
        [Display(Name = "Fecha de movimiento")]
        public DateTime CreateAt { get; set; }
    }
}
