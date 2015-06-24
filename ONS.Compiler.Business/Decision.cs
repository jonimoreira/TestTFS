using Ciloci.Flee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONS.Compiler.Business
{
    public class Decision
    {
        private Inequation _inequation;
        private ActionBlock _trueActionBlock;
        private ActionBlock _falseActionBlock;

        public Inequation Inequation
        {
            get { return _inequation; }
            set { _inequation = value; }
        }
        
        public ActionBlock TrueActionBlock
        {
            get { return _trueActionBlock; }
            set { _trueActionBlock = value; }
        }

        public ActionBlock FalseActionBlock
        {
            get { return _falseActionBlock; }
            set { _falseActionBlock = value; }
        }

        public Decision(Inequation inequation, ActionBlock trueActionBlock, ActionBlock falseActionBlock)
        {
            _inequation = inequation;
            _trueActionBlock = trueActionBlock;
            _falseActionBlock = falseActionBlock;
        }

        public void Compile(ExpressionContext context, CalculationMemory calculationMemory)
        {
            // Compile inequation expression
            Inequation.Compile(context);

            // Compile Action Blocks
            TrueActionBlock.Compile(context, calculationMemory);
            FalseActionBlock.Compile(context, calculationMemory);
        }

        public void Execute(ExpressionContext context, CalculationMemory calculationMemory)
        {
            // Execute inequation and call action block
            if (Inequation.Execute(context))
                TrueActionBlock.Execute(context, calculationMemory);
            else
                FalseActionBlock.Execute(context, calculationMemory);
        }

    }
}
