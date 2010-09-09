using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetSpec.CodeHelper.TestProject
{
    public class DynamicSpec
    {
        public DynamicSpec()
        {
            _text = new StringBuilder(string.Empty);
            Parameters = new List<Par>();
        }

        private StringBuilder _text;
        public string Text
        {
            get { return _text.ToString(); }
        }

        public IList<Par> Parameters { get; private set; }

        public void Insert(int index, string value)
        {
            _text.Insert(index, value);
            Parameters.ToList().ForEach(p =>
                                            {
                                                if(index <= p.Start)
                                                    p.Move(value.Length);
                                                else if (index > p.Start & index <= p.Start + p.Length)
                                                    p.AddTam(value.Length);
                                            }

                );
        }

        public void DefParameter(int start, int length, Type parameterType)
        {
            this.Parameters.Add(new Par(start, length, parameterType, this));
        }
    }
}