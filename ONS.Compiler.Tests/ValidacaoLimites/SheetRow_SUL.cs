using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONS.Compiler.Tests.ValidacaoLimites
{
    public class SheetRow_SUL
    {
        // Propriedades fonte de dados (memória de cáclulo: MC_)
        public KeyValuePair<string, string> PK_HoraInicFim = new KeyValuePair<string, string>();
        public double MC_FRS = 0.0;
        public double MC_RSUL = 0.0;
        public double MC_Grbi_I = 0.0;
        public double MC_Grbi_II = 0.0;
        public double MC_CARGA_do_SUL = 0.0;
        public double MC_Gera_Araucara = 0.0;

        public double MC_UGs_Gerando_GBM = 0.0;
        public double MC_UGs_Gerando_GNB = 0.0;
        public double MC_UGs_Gerando_SSA = 0.0;
        public double MC_UGs_Gerando_Ita = 0.0;
        public double MC_UGs_Gerando_Mach = 0.0;
        public double MC_UGs_Gerando_BGrande = 0.0;
        public double MC_UGs_Gerando_CNO = 0.0;
        public double MC_UGs_Gerando_GPS = 0.0;
        public double MC_UGs_Gerando_S_Osorio = 0.0;
        public double MC_UGs_Gerando_Araucaria = 0.0;

        public double MC_C_Sincrono_GBM = 0.0;
        public double MC_C_Sincrono_GNB = 0.0;
        public double MC_C_Sincrono_SSA = 0.0;
        public double MC_C_Sincrono_Ita = 0.0;
        public double MC_C_Sincrono_Mach = 0.0;
        public double MC_C_Sincrono_B_Grande = 0.0;
        public double MC_C_Sincrono_CNO = 0.0;
        public double MC_C_Sincrono_GPS = 0.0;
        public double MC_C_Sincrono_S_Osorio = 0.0;

        public double MC_J_Lacerda_P = 0.0;
        public double MC_J_Lacerda_M = 0.0;
        public double MC_J_Lacerda_G = 0.0;
        public double MC_J_Lacerda_GG = 0.0;
        public double MC_G1 = 0.0;
        public double MC_G2 = 0.0;
        public double MC_G3 = 0.0;
        public double MC_G4 = 0.0;

        // Propriedades funções (lista de decisões: LD_)
        public string LD_Ugmin_Araucaria = string.Empty;
        public string LD_Geracao_Minima_Araucara = string.Empty;
        public string LD_Lim_Grbi_I_SUP_Import = string.Empty;
        public string LD_Lim_Grbi_I_INF_Export = string.Empty;
        public string LD_Lim_Grbi_II_SUP_Import = string.Empty;
        public string LD_Lim_Grbi_II_INF_Export = string.Empty;
        public string LD_PERIODO_DE_CARGA = string.Empty;
        public double LD_ValorReferenciaFRS_Usinas = 0.0;

        public double LDvalorplanilha_UgminAraucaria = 0.0;
        public double LDvalorplanilha_GeracaoMinimaAraucara = 0.0;
        public double LDvalorplanilha_LimGrbiISUPImport = 0.0;
        public double LDvalorplanilha_LimGrbiIINFExport = 0.0;
        public double LDvalorplanilha_LimGrbiIISUPImport = 0.0;
        public double LDvalorplanilha_LimGrbiIIINFExport = 0.0;

        
        
    }
}
