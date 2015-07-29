using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONS.Compiler.Tests.ValidacaoLimites
{
    public class SheetRow_N_NE_SE
    {
        // Propriedades fonte de dados (memória de cáclulo: MC_)
        public KeyValuePair<string, string> PK_HoraInicFim = new KeyValuePair<string, string>();
        public double MC_EXP_N = 0.0;
        public double MC_RNE = 0.0;
        public double MC_FNE = 0.0;
        public double MC_EXP_SE = 0.0;
        public double MC_FMCCO = 0.0;
        public double MC_FSENE = 0.0;
        public double MC_FNS = 0.0;
        public double MC_FSM = 0.0;
        public double MC_SMGerando = 0.0;
        public double MC_Maqs_Laj = 0.0;
        public double MC_Maqs_Px = 0.0;
        public double MC_Maqs_SMCOp = 0.0;
        public double MC_CARGASIN = 0.0;
        public double MC_CargaNE = 0.0;
        public double MC_Xingo_Gera = 0.0;
        public double MC_Xingo_NumUgs = 0.0;
        public double MC_Gera_Porto_Pecem = 0.0;
        

        // Propriedades funções (lista de decisões: LD_)
        public string LDvalorplanilha_ECETUCIPU = string.Empty;
        public string LDretorno_ECETUCIPU = string.Empty;

        public string LDvalorplanilha_PerCargaNNE = string.Empty;
        public string LDretorno_PerCargaNNE = string.Empty;

        public double LDvalorplanilha_LimiteEXPN_SUP = 0.0;
        public double LDretorno_LimiteEXPN_SUP = 0.0;

        public double LDvalorplanilha_LimiteEXPN_INF = 0.0;
        public double LDretorno_LimiteEXPN_INF = 0.0;

    }
}
