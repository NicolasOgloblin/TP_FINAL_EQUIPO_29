using Business.Articulo;
using Dao.Implements;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Business.MetodoPago
{
    public class MetodoPagoBusiness
    {

        
            public int GuardarMetodoPago(string metodoPago)
            {
                MetodoPagoImp metodoPagoImp = new MetodoPagoImp();
                try
                {
                    return metodoPagoImp.GuardarMetodoPago(metodoPago);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        
    }
}
