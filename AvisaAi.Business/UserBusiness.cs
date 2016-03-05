using AvisaAi.Data.Entities;
using AvisaAi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisaAi.Business
{
    public class UserBusiness
    {
        private IUserRepository repo;

        public UserBusiness(IUserRepository repo)
        {
            this.repo = repo;
        }

        public User Get(int Id)
        {
            return repo.Get(Id);
        }

        //public User Get(int Id)
        //{
        //    var user = new User
        //    {
        //        UserId = 1,
        //        Name = "Michael Costa",
        //        Email = "michaelbh@gmail.com",
        //        ReceiveEmail = true
        //    };

        //    return user;
        //}
    }
}
