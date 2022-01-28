using System;
using System.ComponentModel.DataAnnotations;
using static TeCAS.SCA.Entities.Enumerations.EnumerationLists;

namespace TeCAS.SCA.WebAdmin.Models
{
    public class AccountVM
    {
        public Guid Id { get; set; }

        [Display(Name = "No Cuenta")]
        [Required(ErrorMessage = "El número de cuenta es necesario")]
        public string NoAccount { get; set; }

        [Display(Name = "Tipo de cuenta")]
        public TypeAccount TypeAccount { get; set; }
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "El cliente es necesario")]
        public Guid CustomerId { get; set; }

        [Display(Name = "Cliente")]
        public string CustomerName { get; set; }
        [Display(Name = "Tipo de cuenta")]
        public string TypeNameAccount { get; set; }
        [Display(Name = "Fecha de registro")]
        public DateTime CreateAt { get; set; }
    }
}
