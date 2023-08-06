using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp_Desafio_BackEnd.Models
{
    [Serializable]
    public class Chamado
    {
        public static readonly Chamado Empty;
        public Chamado()
        {
            Departamento = new Departamento();
        }

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "O Assunto é obrigatório")]
        [DataType(DataType.Text)]
        [StringLength(256, MinimumLength = 5)]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "O Solicitante é obrigatório")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 5)]
        public string Solicitante { get; set; }

        [Required(ErrorMessage = "O Departamento é obrigatório")]
        public Departamento Departamento { get; set; }

        public DateTime DataAbertura { get; set; }
    }
}
