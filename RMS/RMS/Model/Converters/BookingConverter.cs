using DatabaseLayer;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class BookingConverter
    {
        public DatabaseLayer.Booking ConverToEntity(BookingDTOs model, DatabaseLayer.Booking booking)
        {

            booking.Date = model.Date;
            booking.TableNumber = model.TableNumber;
            booking.Description = model.Description;
            booking.CustomerID = model.CustomerID;
            return booking;
        }
        public BookingDTOs ConvertToModel(DatabaseLayer.Booking model)
        {
            BookingDTOs booking = new BookingDTOs();
            booking.BookingID = model.BookingID;
            booking.Date = model.Date;
            booking.TableNumber = model.TableNumber;
            booking.Description = model.Description;
            booking.CustomerID = model.CustomerID;
            booking.Customer = model.Customer.CustomerName;
            return booking;
        }

    }
}