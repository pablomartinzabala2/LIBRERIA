using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaFact.Clases;
using System.Data;
namespace SistemaFact.Clases
{
    public class cPorcentaje
    {
        public DataTable GetPorcentaje()
        {
            string sql = "select * from Porcentaje ";
            return cDb.GetDatatable(sql);
        }

        public void PorEfeJuguete(Double Por)
        {
            string sql = " Update Porcentaje set PorEfeJuguete=" + Por.ToString().Replace(",", ".");
            cDb.Grabar(sql);
        }

        public void PorTarJuguete(Double Por)
        {
            string sql = " Update Porcentaje set PorTarJuguete=" + Por.ToString().Replace(",", ".");
            cDb.Grabar(sql);
        }
    }
}
