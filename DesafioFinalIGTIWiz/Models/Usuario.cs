using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.Models
{
    public class Usuario
    {
        [Required]
        public int Id { get; private set; }
        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        public DateTime CriadoEm { get; set; }

        #region Construtor
        public Usuario()
        {
          
        }
        #endregion

        #region Métodos
        public bool EhValido()
        {
            if (string.IsNullOrEmpty(Email))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Senha))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Nome))
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
