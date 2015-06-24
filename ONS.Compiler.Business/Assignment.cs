using Ciloci.Flee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONS.Compiler.Business
{
    public class Assignment
    {
        private Variable _variable;
        private string _assignmentExpression = string.Empty;
        private IDynamicExpression eDynamic;

        public Variable Variable
        { get { return _variable; } }

        public string AssignmentExpression
        { get { return _assignmentExpression; } }

        public Assignment(Variable variable, string assignmentExpression)
        {
            _variable = variable;
            _assignmentExpression = assignmentExpression;
        }

        public void Compile(ExpressionContext context)
        {
            // TODO: verify wheather the expression is a value (no need to compile)
            bool isValue = false;
            if (!isValue)
                eDynamic = context.CompileDynamic(AssignmentExpression);
        }

        public void Execute(ExpressionContext context, CalculationMemory calculationMemory)
        {
            if (eDynamic == null)
                this.Compile(context);

            _variable.Value = eDynamic.Evaluate();

            calculationMemory[_variable.Mnemonic] = _variable;
        }

    }
}
