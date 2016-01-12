using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiUbs.WebApp.Models
{
    [Table("AfericoesPressaoArterial")]
    public class AfericaoPressaoArterial
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Data de Aferição")]
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime DataHoraAfericao { get; set; }
        [Display(Name = "Pressão Sistólica")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int Sistolica { get; set; }
        [Display(Name = "Pressão Diastólica")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int Diastolica { get; set; }

        public int ClienteId { get; set; }

        virtual public Cliente Cliente { get; set; }
    }
}