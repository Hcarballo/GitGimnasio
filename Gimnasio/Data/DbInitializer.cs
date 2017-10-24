﻿using System;
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
            g.Logo = "~Imagenes\\Logo_Gym.jpg";            
            context.Gyms.Add(g);
            context.SaveChanges();        

            //Registro Roles
            var rols = new IdentityRole[]
            {
                new IdentityRole{Name="Desarrollador"},
                new IdentityRole{Name="Administrador" },
                new IdentityRole{Name="Usuario"}                
            };
            foreach(IdentityRole r in rols)
            {
                context.Roles.Add(r);
            }
            context.SaveChanges();

            //Registro Desarrollador
            string password = "ADMIN";
            var user = new ApplicationUser
            {
                Email = "hernancarballo@hotmail.com",
                EmailConfirmed = true,
                UserName = "hernancarballo@hotmail.com",
                PasswordHash = GetHashCode(),
                UserRol = "Desarrollador"
            };

            context.Users.Add(user);
            context.SaveChanges();

            //Asignar Rol
           
                        
            
            
                               
                    
                

                
            




        }
    }
}