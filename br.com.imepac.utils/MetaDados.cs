using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointBarber.br.com.imepac.utils
{
    class MetaDados<T>
    {
        public int quantidadeRegistros { get; set; }
        public List<T> lista { get; set; }
        public int inicio { get; set; }
        public int fim { get; set; }
    }
}
