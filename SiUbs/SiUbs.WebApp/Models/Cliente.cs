using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiUbs.WebApp.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public enum GeneroSexual
        {
            Masculino,
            Feminino
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Nome { get; set; }
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Campo Requerido")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataDeNascimento { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public GeneroSexual Sexo { get; set; }

        virtual public ICollection<AfericaoGlicemia> AfericoesGlicemia { get; set; }
        virtual public ICollection<AfericaoPressaoArterial> AfericoesPressaoArterial { get; set; }
    }
}