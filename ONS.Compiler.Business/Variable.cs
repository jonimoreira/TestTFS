using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONS.Compiler.Business
{
    public class Variable
    {
        private string _mnemonic;
        private VariableDataType _variableDataType;
        private object _variableValue;

        public VariableDataType VariableDataType
        {
            get { return _variableDataType; }
        }

        public string Mnemonic
        {
            get { return _mnemonic; }
        }

        public object Value
        { 
            get 
            {
                switch (_variableDataType)
                {
                    case Business.VariableDataType.Numeric:
                        var d = 0.0;
                        IConvertible convert = _variableValue as IConvertible;
                        if (convert != null)
                        {
                            d = convert.ToDouble(null);
                        }
                        return d;
                    case Business.VariableDataType.Boolean:
                        return Convert.ToBoolean(_variableValue);
                    //case Business.VariableDataType.Time:
                    //    return Convert.ToDateTime(_variableValue);
                    default:
                        return _variableValue;
                }
                 
            }
            set 
            { _variableValue = value; }
        }

        public Variable(string mnemonic, VariableDataType variableDataType)
        {

            _mnemonic = mnemonic.ToLower().Trim();
            _variableDataType = variableDataType;
            switch (variableDataType)
            { 
                case Business.VariableDataType.Numeric:
                    _variableValue = 0.0;
                    break;
                case Business.VariableDataType.Boolean:
                    _variableValue = true;
                    break;
                case Business.VariableDataType.String:
                    _variableValue = string.Empty;
                    break;
                default:
                    break;
            }
        }

        public Variable(string mnemonic, VariableDataType variableDataType, object value)
            : this(mnemonic, variableDataType)
        {
            _variableValue = value;
        }

    }

    public enum VariableDataType
    {
        Numeric = 1,
        String = 2,
        Boolean = 3,
        Time = 4,
    }

}
