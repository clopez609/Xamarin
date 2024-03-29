﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Web.Data.Entities;
using Xamarin.Web.Helpers;

namespace Xamarin.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }


        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Profesor");
            await _userHelper.CheckRoleAsync("Alumno");

            //Add user
            var user = await _userHelper.GetUserByEmailAsync("admin@admin.com");
            if (user == null)
            {
                user = new User
                {
                    Name = "admin",
                    LastName = "admin",
                    Email = "admin@admin.com",
                    UserName = "admin@admin.com"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }

            //Add careers
            if (!_context.Careers.Any())
            {
                AddCareer("Tecnicatura en Desarrollo de Software");
                AddCareer("Tecnicatura en Seguridad e Higuiene");
                AddCareer("Licenciatura en Logistica");
            }

            //Add courses
            if (!_context.Courses.Any())
            {
                AddCourses("Introducción al Desarrollo de Software", user);
                AddCourses("Informatica I", user);
                AddCourses("Matematica I", user);
                AddCourses("Ingles I", user);

                await _context.SaveChangesAsync();
            }

        }

        private void AddCareer(string name)
        {
            _context.Careers.Add(new Career
            {
                Name = name,
            });
        }

        private void AddCourses(string name, User user)
        {
            _context.Courses.Add(new Course
            {
                Name = name,
                DayAndHour = "Lunes - 20hs",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                User = user
            });
        }
    }
}
