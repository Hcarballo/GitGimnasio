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
            var rol = context.UserRoles.Where(x => x.UserId == user.Id).FirstOrDefault();
            var rolName = context.Roles.Where(x=>x.Id == rol.RoleId).FirstOrDefault();

            if (rolName.Name == "Desarrollador")
            {
                url = "HomeDesarrollador";
            }
            if (rolName.Name == "Administrador")
            {
                url = "HomeAdministrador";
            }
            if (rolName.Name == "Usuario")
            {
                url = "HomeUsuario";
            }

            return url;
        }
    }
}
