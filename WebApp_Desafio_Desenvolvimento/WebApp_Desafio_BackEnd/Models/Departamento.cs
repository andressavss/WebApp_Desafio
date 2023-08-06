using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp_Desafio_BackEnd.Models
{
    [Serializable]
    public class Departamento
    {
        public static readonly Departamento Empty;

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 5)]
        public string Descricao { get; set; }
    }
}
