using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoIntegrador_Subway.Models
{
    public class Pedido
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public string nomeCliente { get; set; }

        [Required]
        [Display(Name = "Data")]
        public DateTime dataPedido { get; set; }

        [Required]
        [Display(Name = "Valor total")]
        public decimal valorTotal { get; set; }

        [Display(Name = "Status do pagamento")]
        public string pgtRecebido { get; set; }
    }
}