using Ciloci.Flee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONS.Compiler.Business
{
    public class ActionBlock
    {
        private string _expression = string.Empty;
        // Maybe Dictionary<int, Assignment> because of ordering...
        private Dictionary<int, Assignment> _assignments = new Dictionary<int, Assignment>();
                
        public ActionBlock(string expression)
        {
            _expression = expression;
        }
        /*
        private void BuildExpression()
        {
            foreach (Assignment assignment in _assignments)
            {
                string stringDelim = "\"";
                if (assignment.Variable.VariableDataType != VariableDataType.String)
                    stringDelim = string.Empty;
                _expression += assignment.Variable.Mnemonic + " = " + stringDelim + assignment.AssignmentExpression + stringDelim + ";";
            }
        }
        */

        private void Parse(ExpressionContext context, CalculationMemory calculationMemory)
        {
            _assignments.Clear();
            // assignments seprator token
            string[] temp = _expression.Split(';');
            int idx = 0;

            //temp.OrderBy?
            foreach (string assignmentExpression in temp)
            {
                if (assignmentExpression != string.Empty)
                {
                    // assignment token
                    string[] temp2 = assignmentExpression.Split('=');
                    if (temp2.Length != 2)
                        throw new InequationEngineException(ExceptionType.NumberOfAssigmentTokens);

                    string variableName = temp2[0].ToLower().Trim();
                    Variable variable = calculationMemory[variableName];
                    if (variable == null)
                        throw new InequationEngineException(ExceptionType.VariableNotFoundInCalcMemory);

                    Assignment assignment = new Assignment(variable, temp2[1]);
                    _assignments.Add(idx, assignment);
                    idx++;
                }
            }

        }

        public void Compile(ExpressionContext context, CalculationMemory calculationMemory)
        {
            this.Parse(context, calculationMemory);

            //_assignments.OrderBy()
            foreach(Assignment assignment in _assignments.Values)
            {
                assignment.Compile(context);
            }
            
        }

        public void Execute(ExpressionContext context, CalculationMemory calculationMemory)
        {
            if (_assignments.Count == 0)
                this.Compile(context, calculationMemory);
            
            //_assignments.OrderBy()
            foreach (Assignment assignment in _assignments.Values)
            {
                assignment.Execute(context, calculationMemory);
            }
        }

    }
}
