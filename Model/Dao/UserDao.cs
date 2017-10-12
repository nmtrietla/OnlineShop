using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{   
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public bool Login(string userName, string passWord)
        {
            //var result = (from p in db.Users select p.ID).Count();
            var result = db.Users.Count(x => x.UserName == userName && x.Password == passWord);//x => x.UserName == userName && x.Password == passWord)
            if (result > 0)
                return true;
            return false;
        }
    }
}
