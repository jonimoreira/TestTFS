using Ciloci.Flee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONS.Compiler.Business
{
    public class CalculationMemory : IDictionary<string, Variable>
    {
        protected Dictionary<string, Variable> _calculationMemoryDictionary;
        private ExpressionContext _context;

        public CalculationMemory(ExpressionContext context)
        {
            this._calculationMemoryDictionary = new Dictionary<string, Variable>();
            _context = context;
        }

        public void Add(string key, Variable value)
        {
            if (_calculationMemoryDictionary.Keys.Contains(key))
                throw new InequationEngineException(ExceptionType.ExistingVariableInCalcMemory, value);

            _calculationMemoryDictionary.Add(key, value);
            _context.Variables.Add(key, value.Value);
        }

        public void Add(Variable variable)
        {
            if (_calculationMemoryDictionary.Keys.Contains(variable.Mnemonic))
                throw new InequationEngineException(ExceptionType.ExistingVariableInCalcMemory, variable.Mnemonic);

            _calculationMemoryDictionary.Add(variable.Mnemonic, variable);
            _context.Variables.Add(variable.Mnemonic, variable.Value);
        }

        public Variable this[string key]
        {
            get 
            {
                return _calculationMemoryDictionary[key];
            }
            set
            {
                _calculationMemoryDictionary[key] = value;
                _context.Variables[key] = value.Value;
            }
        }

        public void UpdateVariables(List<Variable> variablesList)
        {
            foreach (Variable var in variablesList)
            {
                _calculationMemoryDictionary[var.Mnemonic].Value = var.Value;
                _context.Variables[var.Mnemonic] = var.Value;
            }
        }

        public bool ContainsKey(string key)
        {
            return _calculationMemoryDictionary.ContainsKey(key);
        }

        public ICollection<string> Keys
        {
            get { return _calculationMemoryDictionary.Keys; }
        }

        public bool Remove(string key)
        {
            return _calculationMemoryDictionary.Remove(key);
        }

        public bool TryGetValue(string key, out Variable value)
        {
            return _calculationMemoryDictionary.TryGetValue(key, out value);
        }

        public ICollection<Variable> Values
        {
            get { return _calculationMemoryDictionary.Values; }
        }

        public void Add(KeyValuePair<string, Variable> item)
        {
            _calculationMemoryDictionary.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _calculationMemoryDictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, Variable> item)
        {
            return _calculationMemoryDictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, Variable>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return _calculationMemoryDictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(KeyValuePair<string, Variable> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, Variable>> GetEnumerator()
        {
            return _calculationMemoryDictionary.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
