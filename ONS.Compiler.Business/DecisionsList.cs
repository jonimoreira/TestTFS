using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONS.Compiler.Business
{
    /// <summary>
    /// Ordered decisions list by key (int)
    /// </summary>
    public class DecisionsList : Dictionary<int, Decision>
    {
        private int _index = 0;
        public void AddDecision(Decision decision)
        {
            this.Add(_index, decision);
            _index++;
        }
    }
}
