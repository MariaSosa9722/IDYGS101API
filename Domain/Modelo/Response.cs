using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modelo
{
    public class Response<T>
    {
        public Response() { }

        public bool Success { get; set; }
        public string Mensaje { get; set; }
        public T Result { get; set; }


        public Response(string mensaje, T data)
        {
            Success = true;
            Mensaje = mensaje;
            Result = data;
        }
    }
}
