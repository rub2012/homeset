using System;
using System.Collections.Generic;
using System.Text;

namespace HomeSet.Domain
{
    public class Resultado
    {
        public IDictionary<string, string> Errores { get; private set; } = new Dictionary<string, string>();

        public bool HayErrores
        {
            get { return Errores.Count != 0; }
        }

        public void Error(string clave, string descripcion)
        {
            Errores.Add(clave, descripcion);
        }
    }
}
