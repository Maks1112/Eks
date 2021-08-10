using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Repositories.Interfaces;
using Models.Entities;
using Server.Data;


namespace Server.Repositories.Implementation
{
    class UserRepository : IRepository<User>
    {
        private DataManagerMCC dm = new DataManagerMCC();


        public void Create(User item)
        {
            dm.Users.Add(item);
        }

        public void Delete(int id)
        {
            dm.Users.Remove(dm.Users.FirstOrDefault(u => u.Id == id));
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public User GetItem(int id)
        {
            return dm.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetItemsList()
        {
            return dm.Users.ToList();
        }

        public void Save()
        {
            dm.SaveChanges();
        }

        public void Update(User item)
        {
            var user = dm.Users.FirstOrDefault(u => u.Id == item.Id);
            if(user == null)
            {
                return;
            }

            dm.Entry(user).CurrentValues.SetValues(item);
        }


        public User GetUser(string email, string password)
        {
            return dm.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
