using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiUbs.WebApp.Models
{
    [Table("AfericoesGlicemia")]
    public class AfericaoGlicemia
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Data de Aferição")]
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime DataHoraAfericao { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int Valor { get; set; }
        [Display(Name = "Em Jejum")]
        [Required(ErrorMessage = "Campo Requerido")]
        [DefaultValue(false)]
        public bool Jejum { get; set; }

        public int ClienteId { get; set; }

        virtual public Cliente Cliente { get; set; }
    }
}