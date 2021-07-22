using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class MenuConverter
    {
        public DatabaseLayer.Menu ConverToEntity(MenuDTOs model, DatabaseLayer.Menu menu)
        {
            menu.MenuName = model.MenuName;
            menu.MenuPrice = model.MenuPrice;
            return menu;
        }
        public MenuDTOs ConvertToModel(DatabaseLayer.Menu model)
        {
            MenuDTOs menu = new MenuDTOs();
            menu.MenuID = model.MenuID;
            menu.MenuName = model.MenuName;
            menu.MenuPrice = model.MenuPrice;
            //menu.SubCategoryID = (Guid)model.SubCategoryID;

            return menu;
        }

    }
}