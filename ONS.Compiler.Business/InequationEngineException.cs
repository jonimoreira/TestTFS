using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ONS.Compiler.Business
{
    [Serializable]
    public sealed class InequationEngineException: Exception
    {
        private ExceptionType _exceptionType = ExceptionType.Undefined;
        public ExceptionType ExceptionType
        { get { return _exceptionType; } }
        
        public InequationEngineException() : base() { }

        public InequationEngineException(string message) : base(message) { }
    
        public InequationEngineException(string format, params object[] args) : base(string.Format(format, args)) { }

        public InequationEngineException(ExceptionType exceptionType, params object[] args) : base(string.Format(ExceptionTypeEnum.GetString(exceptionType), args)) 
        {
            _exceptionType = exceptionType;
        }
    
        public InequationEngineException(string message, Exception innerException) : base(message, innerException) { }
    
        public InequationEngineException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }

        protected InequationEngineException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }

    public enum ExceptionType
    { 
        ExistingVariableInCalcMemory=1,
        NumberOfAssigmentTokens=2,
        VariableNotFoundInCalcMemory=3,
        Undefined = 666,
    }

    public static class ExceptionTypeEnum
    {
        public static string GetString(ExceptionType exceptionType)
        {
          string lValue = string.Empty;
          
          switch(exceptionType)
          {
               case ExceptionType.ExistingVariableInCalcMemory:
                    lValue = "Variável '{0}' duplicada na memória de cálculo";
                    break;
               case ExceptionType.NumberOfAssigmentTokens:
                    lValue = "Número de símbolos de atribuição (=) inconsistente na expressão '{0}'";
                    break;
               case ExceptionType.VariableNotFoundInCalcMemory:
                    lValue = "Variável '{0}' não encontrada na memória de cálculo";
                    break;
              default:
                  lValue = "Exceção não definida";
                  break;
          }
          
          return lValue;
        }
    }

}
