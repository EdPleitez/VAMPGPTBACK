using System;
using System.Collections.Generic;
using System.Linq;
using VampGPTBack.Entidades;
using VampGPTBack.Entidades.Entities;
using VampGPTBack.Entidades.Request;
using VampGPTBack.Entidades.Response;
using VampGPTBack.AccesoDatos;

namespace VampGPTBack.Logica
{
    public class LogCuentas
    {
        public ResCrearCuenta CrearCuenta(ReqCrearCuenta req)
        {
            ResCrearCuenta res = new ResCrearCuenta();
            res.listaDeErrores = new List<string>();
            try
            {
                if (req == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Credenciales incorrectas");
                }
                else
                {
                    linqDataContext linq = new linqDataContext();
                    sp_CrearJugador cuentaLinq = linq.sp_Cuenta(req.correoElectronico, req.password).FirstOrDefault();
                    if (cuentaLinq == null)
                    {
                        res.resultado = false;
                        res.listaDeErrores.Add("Cuenta no encontrada");
                    }
                    else
                    {
                        res.cuenta = ArmarCuenta(cuentaLinq);
                        res.resultado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.Message);
            }
            return res;
        }

        private Cuenta ArmarCuenta(sp_CrearJugador cuentaLinq)
        {
            if (cuentaLinq == null)
            {
                return null;
            }

            Cuenta cuenta = new Cuenta();
            cuenta.id = (int)cuentaLinq.id_Cuenta;
            cuenta.nombreJugador = cuentaLinq.NombreJugador;

            return cuenta;
        }
    }
}
