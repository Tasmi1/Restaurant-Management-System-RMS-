using DatabaseLayer;
using RMS.Model.viewModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Model.Converters
{
    public class InvoiceConverter
    {
        public DatabaseLayer.Invoice ConverToEntity(InvoiceDTOs model, Invoice invoice)
        {
            invoice.VAT = model.VAT;
            invoice.ServiceTax = model.ServiceTax;
            invoice.ITotal = model.ITotal;
            invoice.Status = model.Status;
            invoice.CartDetailID = model.CartDetailID;

            return invoice;
        }

        public InvoiceDTOs ConvertToModel(DatabaseLayer.Invoice model)
        {
            InvoiceDTOs invoice = new InvoiceDTOs();
            invoice.InvoiceID = model.InvoiveID;
            invoice.VAT = (decimal)model.VAT;
            invoice.ServiceTax = (decimal)model.ServiceTax;
            invoice.ITotal = model.ITotal;
            invoice.Status = (bool)model.Status;
            invoice.CartDetailID = model.CartDetailID;
            

            return invoice;
        }
    }
}