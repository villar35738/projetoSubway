using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoIntegrador_Subway.Models
{
    public class CategoriaProduto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome da categoria")]
        public string nomeCategoria { get; set; }
    }
}