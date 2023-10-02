using Data.DTOs;

namespace SofTk_TechOil_Front.ViewModels
{
    
        public class UsuariosViewModel
        {
        public int Id { get; set; }
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public int DNI { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool Activo { get; set; }


        public static implicit operator UsuariosViewModel(UsuariosDto usuario)
        {
            var usuariosViewModel = new UsuariosViewModel();
            usuariosViewModel.Id = usuario.Id;
            usuariosViewModel.CodUsuario = usuario.CodUsuario;
            usuariosViewModel.Nombre = usuario.Nombre;
            usuariosViewModel.DNI = usuario.DNI;
            usuariosViewModel.Password = usuario.Password;
            usuariosViewModel.RoleId = usuario.RoleId;
            return usuariosViewModel;
        }
    }
    }

