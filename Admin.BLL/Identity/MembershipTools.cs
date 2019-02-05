﻿using Admin.DAL;
using Admin.Models.Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Admin.BLL.Identity
{
    public static class MembershipTools
    {
        private static MyContext _db;

        public static UserStore<User> NewUserStore() => new UserStore<User>(_db ?? new MyContext());
        public static UserManager<User> NewUserManager() => new UserManager<User>(NewUserStore());

        public static RoleStore<Role> NewRoleStore() => new RoleStore<Role>(new MyContext());
        public static RoleManager<Role> NewRoleManager() => new RoleManager<Role>(NewRoleStore());


    }
}