using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flyinn.Models
{
    public class Programas
    {
        public int idPrograma { get; set; }
        public int CodigoPrograma { get; set; }
        public string Descripcion { get; set; }
        public string CodigoAnterior { get; set; }
        public int Estado { get; set; }
        public List<Contratos> listContratos { get; set; }
        public Contratos contratos { get; set; }


        #region ATRIBUTOS DE PARÁMETROS (PARA REPORTE CLOSING DE CONTRATOS PROCESABLES)
        public DateTime fini { get; set; }
        public DateTime ffin { get; set; }
        public int codcoc { get; set; }
        public int codpla { get; set; }
        public int codisl { get; set; }
        public int codcos { get; set; }
        public int codsal5 { get; set; }
        public int codsal7 { get; set; }
        public string PVB { get; set; }
        public string PPF { get; set; }

        public string nombre_programa { get; set; }
        #endregion
    }
}