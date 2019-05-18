using System;
using System.Collections.Generic;
using WorkoutAnalytics.UI.Models;

namespace WorkoutAnalytics.UI.DAL
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserByUserID(int UserID);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int UserID);
        void Save();
    }
}
