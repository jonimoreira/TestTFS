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
        public double LDvalorplanilha_LIM_FBAIN = 0.0;
        public double LDretorno_LIM_FBAIN = 0.0;

        public double LDvalorplanilha_LIM_FINBA = 0.0;
        public double LDretorno_LIM_FINBA = 0.0;

        public double LDvalorplanilha_LIM_FSE = 0.0;
        public double LDretorno_LIM_FSE = 0.0;

        public double LDvalorplanilha_LIM_RSE = 0.0;
        public double LDretorno_LIM_RSE = 0.0;
        
        public double LDvalorplanilha_LIM_RSUL_FSUL_SUP_RSUL = 0.0;
        public double LDretorno_LIM_RSUL_FSUL_SUP_RSUL = 0.0;

        public double LDvalorplanilha_LIM_RSUL_FSUL_INF_FSUL = 0.0;
        public double LDretorno_LIM_RSUL_FSUL_INF_FSUL = 0.0;

        public double LDvalorplanilha_Mqs_crt_IPU_max = 0.0;
        public double LDretorno_Mqs_crt_IPU_max = 0.0;

        public string LD_Limite_GIPU_SUP = string.Empty;
        public string LD_Limite_GIPU_INF = string.Empty;

        public string LDvalorplanilha_PERIODO_DE_CARGA = string.Empty;
        public string LDretorno_PERIODO_DE_CARGA = string.Empty;
        
        public string LD_Valor_referencia_FRS_Usinas = string.Empty;



    }
}
