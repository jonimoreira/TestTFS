using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONS.Compiler.Tests.ValidacaoLimites
{
    public class SheetRow_S_SE
    {
        // Propriedades fonte de dados (memória de cáclulo: MC_)
        public KeyValuePair<string, string> PK_HoraInicFim = new KeyValuePair<string, string>();
        public double MC_FSE_Programado = 0.0;
        public double MC_RSE_Eletrico = 0.0;
        public double MC_RSUL = 0.0;
        public double MC_FBAIN = 0.0;
        public double MC_FINBA = 0.0;
        public double MC_POT_ELO_CC = 0.0;
        public double MC_FIV = 0.0;
        public double MC_GIPU_60Hz = 0.0;
        public double MC_Mq_60Hz = 0.0;
        public double MC_CARGA_SIN = 0.0;
        public double MC_CARGA_SUL = 0.0;
        public string MC_LIM_ELO_CC = string.Empty;
        public double MC_Gera_Usinas = 0.0;

        // Propriedades funções (lista de decisões: LD_)
        public string LD_LIM_FBAIN = string.Empty;
        public string LD_LIM_FINBA = string.Empty;
        public string LD_LIM_FSE = string.Empty;
        public string LD_LIM_RSE = string.Empty;
        
        /// <summary>
        /// =LIMITE_RSUL(Y6,F6,N6,SUL!Z6,SUL!AN6,SUL!AO6,SUL!AP6,SUL!AQ6)
        /// =LIMITE_RSUL(LD_PERIODO_DE_CARGA,MC_RSUL,MC_CARGA_SUL,SheetRow_SUL.MC_UGs_Gerando_Araucaria,SheetRow_SUL.MC_G1,SheetRow_SUL.MC_G2,SheetRow_SUL.MC_G3,SheetRow_SUL.MC_G4)
        /// </summary>
        public List<string> LD_LIM_RSUL_FSUL_SUP_RSUL = new List<string>();
        public double LDretorno_LIM_RSUL_FSUL_SUP_RSUL = 0.0;

        public string LD_LIM_RSUL_FSUL_INF_FSUL = string.Empty;
        public string LD_Mqs_crt_IPU_max = string.Empty;
        public string LD_Limite_GIPU_SUP = string.Empty;
        public string LD_Limite_GIPU_INF = string.Empty;

        public string LD_PERIODO_DE_CARGA = string.Empty;
        public string LDretorno_PERIODO_DE_CARGA = string.Empty;
        
        public string LD_Valor_referencia_FRS_Usinas = string.Empty;



    }
}
