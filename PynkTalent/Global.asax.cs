using PynkTalent.Models;
using PynkTalent.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PynkTalent
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = new List<UserModel>();

            users.Add(new UserModel() {
                first_name = "John",
                last_name = "Doe",
                balance = 1000,
                country = "United Kingdom",
                id = 1
            });

            users.Add(new UserModel() {
                first_name = "Rupert",
                last_name = "Doe",
                balance = 5000,
                country = "United Kingdom",
                id = 2
            });

            users.Add(new UserModel() {
                first_name = "Koray",
                last_name = "Yapar",
                balance = 4000,
                country = "Turkey",
                id = 3
            });

            users.Add(new UserModel() {
                first_name = "Yigit",
                last_name = "Dondu",
                balance = 0,
                country = "Turkey",
                id = 4
            });

            users.Add(new UserModel() {
                first_name = "Dirk",
                last_name = "Kross",
                balance = 10000,
                country = "Germany",
                id = 5
            });

            users.Add(new UserModel() {
                first_name = "Kevin",
                last_name = "Leno",
                balance = 2000,
                country = "Germany",
                id = 6
            });

            users.Add(new UserModel() {
                first_name = "Mark",
                last_name = "John",
                balance = 7000,
                country = "United States",
                id = 7
            });

            users.Add(new UserModel() {
                first_name = "John",
                last_name = "Brown",
                balance = 0,
                country = "United States",
                id = 8
            });

            users.Add(new UserModel() {
                first_name = "Marty",
                last_name = "Mark",
                balance = 0,
                country = "United Kingdom",
                id = 9
            });

            users.Add(new UserModel() {
                first_name = "Helga",
                last_name = "Gattuso",
                balance = 0,
                country = "Germany",
                id = 10
            });

            StaticModel.users = users;
        }
    }
}