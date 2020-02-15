using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointBarber.br.com.imepac.entidades
{
    class Cliente
    {
        public int id { set; get; }
        public string nome { set; get; }
        public string cpf { set; get; }
        public string rg { set; get; }
        public DateTime nascimento { set; get; }
        public int plano { set; get; }
        public String valor { set; get; }
        public List<Imagens> imagens { get; set; }


    }
}
