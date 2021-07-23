using DatabaseLayer;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class DishSubCategoryConverter
    {
        public DishSubCategory ConvertToEntity(DishSubCategoryDTOs dishSub, DishSubCategory dishSubCategory)
        {
            dishSubCategory.SubCategoryName = dishSub.SubCategoryName;
            return dishSubCategory;

        }

        public DishSubCategoryDTOs ConvertToModel(DishSubCategory dishSub)
        {
            DishSubCategoryDTOs dishSubCategory = new DishSubCategoryDTOs();
            dishSubCategory.SubCategoryId = dishSub.SubCategoryID;
            dishSubCategory.SubCategoryName = dishSub.SubCategoryName;


            return dishSubCategory;


        }



    }
}