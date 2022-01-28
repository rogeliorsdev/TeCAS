using System;
using System.ComponentModel.DataAnnotations;
using static TeCAS.SCA.Entities.Enumerations.EnumerationLists;

namespace TeCAS.SCA.WebAdmin.Models
{
    public class CustomerVM
    {
        public Guid Id { get; set; }
 
        [Display(Name ="Nombre completo")]
        [Required(ErrorMessage ="El nombre del cliente es necesario")]
        public string FullName { get; set; }
 
        [Display(Name = "INE")]
        [Required(ErrorMessage = "El INE es necesario")]
        public string INE { get; set; }
        
        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El número de teléfono es necesario")]
        public string Phone { get; set; }
        
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "La dirección de residencia es necesaria")]
        public string Address { get; set; }

        [Display(Name = "Estado")]
        public Status Status { get; set; }

        public string CreateById { get; set; }
        [Display(Name = "Fecha de registro")]
        public DateTime CreateAt { get; set; }
    }
}
