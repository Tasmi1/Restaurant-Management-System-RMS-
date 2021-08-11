﻿using DatabaseLayer;
using RMS.Model.Converters;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Services
{
    public class KitchineOrderService
    {
        private readonly KitchineOrderConverter converter = new KitchineOrderConverter();

        public List<KitchineOrderDTOs> GetAll()
        {
            List<KitchineOrderDTOs> orders = new List<KitchineOrderDTOs>();
            try
            {
                using (ResturantManagementDBEntities db = new ResturantManagementDBEntities())
                {
                                     
                    var orderdate = db.OrderCarts.Where(x => x.OrderDate == DateTime.Today & x.OrderStatus == false).ToList();
                    foreach (var order in orderdate)
                    {
                        {
                            orders.Add(converter.ConvertToModel(order));

                        }
                    }
                    return orders;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}