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
        public int Login(string userName, string passWord)
        { 
            
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);//x => x.UserName == userName && x.Password == passWord)
            if (result == null)
                return 0;// "Tài khoản không tồn tại.";
            else
                if (result.Status == false)
                return -1;// "Tài khoản đang bị khóa";
            else
                if (result.Password == passWord)
                return 1;//đúng
            else return 2;//sai pass
        }
    }
}
