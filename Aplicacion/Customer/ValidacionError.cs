using System;
using System.Net;

namespace Aplicacion.Customer
{
    public class ValidacionError : Exception
    {
        public HttpStatusCode _codigo { get; }
        public object _errores { get; }

        public ValidacionError(HttpStatusCode codigo, object errores = null)
        {
            this._codigo = codigo;
            this._errores = errores;
        }
    }
}
