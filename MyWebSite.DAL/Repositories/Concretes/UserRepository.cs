﻿using MyWebSite.DAL.MyEntities;
using MyWebSite.DAL.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.DAL.Repositories.Concretes
{
   public class UserRepository : IUserRepository
    {
        MyWebSiteContext _db;
        public UserRepository()
        {
           _db = new MyWebSiteContext();
        }

        public int AddItem(User item)
        {
            _db.User.Add(item);
            int sonuc;
            sonuc = _db.SaveChanges();
            return sonuc;
        }

        public int DeleteItem(User item)
        {
            _db.User.Remove(item);
            int sonuc;
            sonuc = _db.SaveChanges();
            return sonuc;
        }

        public ICollection<User> GetAllItem(Expression<Func<User, bool>> lambda = null)
        {
             return lambda == null ? 
                _db.User.ToList() :
                _db.User.Where(lambda).ToList();
        }

        public User GetItem(Expression<Func<User, bool>> lambda = null)
        {
            return _db.User.Where(lambda).FirstOrDefault();
        }

        public int UpdateItem(User item)
        {
           User oldUser = _db.User.Where(x => x.UserId == item.UserId).FirstOrDefault();
            oldUser.FirstName = item.FirstName;
            oldUser.LastName = item.LastName;
            oldUser.Gender = item.Gender;
            oldUser.Password = item.Password;
            oldUser.Email = item.Email;
            int sonuc;
            sonuc = _db.SaveChanges();
            return sonuc;
        }
    }
}
