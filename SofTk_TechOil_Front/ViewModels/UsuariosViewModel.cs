namespace SofTk_TechOil_Front.ViewModels
{
    
        public class UsuariosViewModel
        {
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public int DNI { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool Activo { get; set; }





        //public static implicit operator UsuariosViewModel(UsuarioDto usuario)
        //{
        //    var usuariosViewModel = new UsuariosViewModel();
        //    usuariosViewModel.Id = usuario.Id;
        //    usuariosViewModel.FirstName = usuario.Nombre;
        //    usuariosViewModel.UserName = usuario.UserName;
        //    usuariosViewModel.Email = usuario.Email;
        //    usuariosViewModel.dni = usuario.dni;
        //    usuariosViewModel.tipo = usuario.tipo;
        //    usuariosViewModel.contrasena = usuario.contrasena;


        //    return usuariosViewModel;
        //}
    }
    }

