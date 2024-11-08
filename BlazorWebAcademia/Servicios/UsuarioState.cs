using Entidades;

namespace BlazorWebAcademia.Servicios
{
    public class UsuarioState
    {

        public Usuario UsuarioActual { get; private set; }


        public void SetUsuario(Usuario usuario)
        {
            UsuarioActual = usuario;
        }


        public void ClearUsuario()
        {
            UsuarioActual = null;
        }


        public bool IsAuthenticated()
        {
            return UsuarioActual != null;
        }


        public string GetUserRole()
        {
            return UsuarioActual?.Rol;
        }

        public string GetRol()
        {
            return UsuarioActual?.Rol;
        }
    }
}
