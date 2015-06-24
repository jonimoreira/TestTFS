using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciloci.Flee;

namespace ONS.Compiler.Business
{
    public class Inequation
    {
        private string _expression = string.Empty;
        private IDynamicExpression eDynamic;
        
        public string Expression
        {
            get { return _expression; }
        }

        public Inequation(string expression)
        {
            if (expression == string.Empty)
                _expression = "true";
            else
                _expression = expression;
        }

        public void Compile(ExpressionContext context)
        {
            eDynamic = context.CompileDynamic(Expression);
        }

        public bool Execute(ExpressionContext context)
        {
            if (eDynamic == null)
                this.Compile(context);
            
            bool result = (bool)eDynamic.Evaluate();
            return result;
        }

    }
}
