using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gimnasio.Models;
using Gimnasio.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Cryptography;

namespace Gimnasio.Data
{
    public class DbInitializer
    {

        public static void Initialize(GimnasioDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Gyms.Any())
            {
                return;
            }

            //Registro Gym
            Geocodificacion geo = new Geocodificacion();
            var g = new Gym();
            g.Razon_Social = "Training Time";
            g.Telefono = "0341-4238763";
            g.Direccion = "Riobamba 2972";
            g.Latitud = geo.Latitude(g.Direccion, "Rosario", "Santa Fe");
            g.Longitud = geo.Longitude(g.Direccion, "Rosario", "Santa Fe");
            g.Logo = "~imagenes\\Logo_Gym.jpg";
            context.Gyms.Add(g);
            context.SaveChanges();

            //Registro Roles
            var rols = new IdentityRole[]
            {
                new IdentityRole{Name="Desarrollador", NormalizedName="DESARROLLADOR" },
                new IdentityRole{Name="Administrador",NormalizedName="ADMINISTRACION" },
                new IdentityRole{Name="Usuario", NormalizedName="USUARIO" }
            };
            foreach (IdentityRole r in rols)
            {
                context.Roles.Add(r);
            }
            context.SaveChanges();

            //Registro Desarrollador (User: admin@hotmail.com  //  Password: @Admin17

            var user = new ApplicationUser
            {
                AccessFailedCount = 0,
                ConcurrencyStamp = "1459792f - 599c - 4726 - 9d67 - 63d6809bc6b3",
                Email = "admin@hotmail.com",
                EmailConfirmed = false,
                LockoutEnabled = true,
                LockoutEnd = null,
                NormalizedEmail = "ADMIN@HOTMAIL.COM",
                NormalizedUserName = "ADMIN@HOTMAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAELtoMu6BMDi48VLjnFvqNx6Tlt612MZiP3eptPw4klqMsLXfWBwnlBj8dXyAmRj/xA==",
                SecurityStamp = "f3269f83-31d5-436b-bfd1-508b9e668d72",
                TwoFactorEnabled = false,
                UserName = "admin@hotmail.com",
                Activo = true,
            };

            context.Users.Add(user);
            context.SaveChanges();

            //Registro Usuario-Rol
            var rol = context.Roles.Where(x => x.Name == "Desarrollador").FirstOrDefault();
            var use = context.Users.Where(x => x.Email == "admin@hotmail.com").FirstOrDefault();

            IdentityUserRole<string> identityUserRole = new IdentityUserRole<string>();
            identityUserRole.RoleId = rol.Id;
            identityUserRole.UserId = use.Id;
            context.UserRoles.Add(identityUserRole);          
            context.SaveChanges();
        }

    }
}








        