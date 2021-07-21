using DatabaseLayer;
using RMS.Model.Converters;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Services
{
    public class UserService
    {
        private readonly UserConverter userConverter = new UserConverter();

        public bool Create(UserDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DatabaseLayer.User user = new DatabaseLayer.User();
                    user.UserId = Guid.NewGuid();
                    user = userConverter.ConverToEntity(model, user);

                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public bool Update(UserDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DatabaseLayer.User user = db.Users.FirstOrDefault(c => c.UserId == model.UserId);
                    if (user != null)
                    {
                        user = userConverter.ConverToEntity(model, user);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public UserDTOs GetById(Guid userId)
        {
            UserDTOs model = new UserDTOs();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DatabaseLayer.User user = db.Users.FirstOrDefault(c => c.UserId == userId);
                   if (user != null)
                    {
                        model = userConverter.ConvertToModel(user);
                    }
                    return model;
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<UserDTOs> GetAll()
        {
            List<UserDTOs> users = new List<UserDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    var dbUser = db.Users.ToList();
                    foreach (var user in dbUser)
                    {

                        users.Add(userConverter.ConvertToModel(user));
                    }
                    return users;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public bool Delete(Guid userId)
        {

            using (var db = new ResturantManagementDBEntities())
            {

                var user = db.Users.FirstOrDefault(x => x.UserId == userId);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }

}