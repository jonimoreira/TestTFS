using Ciloci.Flee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONS.Compiler.Business
{
    public class InequationEngine
    {
        private CalculationMemory _calculationMemory;
        private DecisionsList _decisionList;
        private ExpressionContext _context;

        public CalculationMemory CalculationMemory
        {
            get 
            {
                return _calculationMemory;
            }
        }

        public DecisionsList DecisionsList
        {
            get
            {
                if (_decisionList == null)
                    _decisionList = new DecisionsList();
                return _decisionList;
            }
        }

        public InequationEngine()
        {
            _context = new ExpressionContext();
            _context.Imports.AddType(typeof(CustomFunctions));
            _context.Options.EmitToAssembly = false;
            _calculationMemory = new CalculationMemory(_context);
        }

        public void Compile()
        {
            // Compile decisions
            //DecisionsList.OrderBy()
            foreach (Decision decision in DecisionsList.Values)
            {
                decision.Compile(_context, CalculationMemory);
            }

        }

        public void Execute()
        {
            //DecisionsList.OrderBy()
            foreach (Decision decision in DecisionsList.Values)
            {
                // Execute inequation expression
                decision.Execute(_context, CalculationMemory);

            }
        }

    }
}
