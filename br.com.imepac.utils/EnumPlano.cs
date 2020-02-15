using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioVisual.br.com.imepac.utils
{
    class EnumPlano
    {   
        public static readonly int DISPONIVEL = 1;
        public static readonly int INDISPONIVEL = 0;
        public static readonly Dictionary<int, string> Itens = new Dictionary<int, string>{
            { DISPONIVEL, "Disponível" },{ INDISPONIVEL, "Indisponível" }
        };

        public static string GetItens(int code)
        {
            string name;
            if (!Itens.TryGetValue(code, out name))
            {
                // Error handling here
            }
            return name;
        }
    }
}
