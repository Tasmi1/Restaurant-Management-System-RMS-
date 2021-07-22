using DatabaseLayer;
using RMS.Model.Converters;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Services
{
    public class MenuService
    {
        private readonly MenuConverter converter = new MenuConverter();
        public bool Create(MenuDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                    DatabaseLayer.Menu menu = new DatabaseLayer.Menu();
                    menu.MenuID = Guid.NewGuid();
                    menu = converter.ConverToEntity(model, menu);

                    db.Menus.Add(menu);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool Update(MenuDTOs model)
        {
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DatabaseLayer.Menu menu = db.Menus.FirstOrDefault(c => c.MenuID == model.MenuID);
                    if (menu != null)
                    {
                        menu = converter.ConverToEntity(model, menu);
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

        public MenuDTOs GetById(Guid menuId)
        {
            MenuDTOs model = new MenuDTOs();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    DatabaseLayer.Menu menu = db.Menus.FirstOrDefault(c => c.MenuID == menuId);
                    if (menu != null)
                    {
                        model = converter.ConvertToModel(menu);

                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public List<MenuDTOs> GetAll()
        {
            List<MenuDTOs> menus = new List<MenuDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {

                    var dbMenus = db.Menus.ToList();
                    foreach (var menu in dbMenus)
                    {
                        menus.Add(converter.ConvertToModel(menu));

                    }
                    return menus;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}