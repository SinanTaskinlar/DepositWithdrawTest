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
			var users = new List<UserModel> {
				new UserModel() {
					First_name = "John",
					Last_name = "Doe",
					Balance = 1000,
					Country = "United Kingdom",
					Id = 1
				},

				new UserModel() {
					First_name = "Rupert",
					Last_name = "Doe",
					Balance = 5000,
					Country = "United Kingdom",
					Id = 2
				},

				new UserModel() {
					First_name = "Koray",
					Last_name = "Yapar",
					Balance = 4000,
					Country = "Turkey",
					Id = 3
				},

				new UserModel() {
					First_name = "Yigit",
					Last_name = "Dondu",
					Balance = 0,
					Country = "Turkey",
					Id = 4
				},

				new UserModel() {
					First_name = "Dirk",
					Last_name = "Kross",
					Balance = 10000,
					Country = "Germany",
					Id = 5
				},

				new UserModel() {
					First_name = "Kevin",
					Last_name = "Leno",
					Balance = 2000,
					Country = "Germany",
					Id = 6
				},

				new UserModel() {
					First_name = "Mark",
					Last_name = "John",
					Balance = 7000,
					Country = "United States",
					Id = 7
				},

				new UserModel() {
					First_name = "John",
					Last_name = "Brown",
					Balance = 0,
					Country = "United States",
					Id = 8
				},

				new UserModel() {
					First_name = "Marty",
					Last_name = "Mark",
					Balance = 0,
					Country = "United Kingdom",
					Id = 9
				},

				new UserModel() {
					First_name = "Helga",
					Last_name = "Gattuso",
					Balance = 0,
					Country = "Germany",
					Id = 10
				}
			};

			StaticModel.Users = users;
        }
    }
}