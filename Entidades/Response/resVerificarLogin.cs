using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampGPTBack.Entidades.Entities;

namespace VampGPTBack.Entidades
{
    public class resVerificarLogin : resBase
    {

        public List<Cuenta> cuentasVerificacion { get; set; }

    }
}
