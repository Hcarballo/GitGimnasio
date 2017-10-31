using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio.Data
{
    public class RedirecPage
    {
        public string Url(GimnasioDbContext context, string email)
        {
            string url = null;
            var user = context.Users.Where(x => x.Email == email).FirstOrDefault();
            if(user.UserRol == "Desarrollador")
            {
                url = "HomeDesarrollador";
            }
            if(user.UserRol == "Administrador")
            {
                url = "HomeAdministrador";
            }
            if(user.UserRol == "Usuario")
            {
                url = "HomeUsuario";
            }           

            return url;
        }
    }
}
