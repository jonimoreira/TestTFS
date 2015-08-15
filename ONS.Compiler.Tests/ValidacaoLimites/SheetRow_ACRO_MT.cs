﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONS.Compiler.Tests.ValidacaoLimites
{
    public class SheetRow_ACRO_MT
    {
        // Propriedades fonte de dados (memória de cáclulo: MC_)
        public KeyValuePair<string, string> PK_HoraInicFim = new KeyValuePair<string, string>();
        public double MC_GeracaoItqPPdr = 0.0;
        public double MC_FBtB = 0.0;
        public double MC_FTRpr = 0.0;
        public double MC_POLO1 = 0.0;
        
        
        // Propriedades funções (lista de decisões: LD_)
        public double LDvalorplanilha_Limite_FMT = 0.0;
        public double LDvalorplanilha_Lim_FACROSup = 0.0;
        public double LDvalorplanilha_Lim_FACROInf = 0.0;
        public double LDvalorplanilha_LimiteSm_Aq = 0.0;
        public double LDvalorplanilha_LimiteFBtB = 0.0;
        public double LDvalorplanilha_LimiteFTRpr = 0.0;
        public double LDvalorplanilha_LimitePOLO = 0.0;
        public double LDvalorplanilha_LimiteSAJirau = 0.0;


    }
}
