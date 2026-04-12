using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {

        //Loguear lo que hace es hacer una consulta con las credenciales que haya cargado el usuario y si coinciden con algun archivo
        // en la base de datos significa que existe el perfil por ende devuelve true, sino devuelve false
        public bool loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, TipoUsuario,ImagenPerfil, Nombre, Apellido, FechaNacimiento, Email, Admin WHERE Usuario = @usuario AND Pass = @pass");
                datos.setearParametro("@usuario", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.TipoUsuario = (int)(datos.Lector["TipoUser"]) == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    if (!(datos.Lector["imagenPerfil"] is DBNull))
                        usuario.ImagenPerfil = (string)datos.Lector["imagenPerfil"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["Apellido"];
                    if (!(datos.Lector["FechaNacimiento"] is DBNull))
                        usuario.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNacimiento"].ToString());

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        //Insertar nuevo es para registrar un usuario. Inserta un archivo con estos datos. Email y Pass
        public int insertarNuevo(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //Actualizar es para cuando el usuario completa su perfil en la pestaña "mi perfil" donde completa nombre, apellido, imagen, etc. Entonces mandamos los datos y lo completamos también en la base de datos.
        public void actualizar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update USERS set imagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido, fechaNacimiento = @fecha Where Id = @id");
                datos.setearParametro("@imagen", (object)usuario.ImagenPerfil ?? DBNull.Value); // -> NULL COALESCING
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@fecha", usuario.FechaNacimiento);
                datos.setearParametro("@id", usuario.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
