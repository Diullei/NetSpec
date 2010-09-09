using System;

namespace NetSpec.CodeHelper.TestProject
{
    public class Par
    {
        private readonly DynamicSpec _dynamicSpec;

        public string Value 
        {
            get
            {
                return _dynamicSpec.ToString().Substring(Start, Length);
            }
        }

        public Type ParameterType { get; private set; }
        public int Start { get; private set; }
        public int Length { get; private set; }

        public Par(int start, int length, Type parameterType, DynamicSpec dynamicSpec)
        {
            Start = start;
            Length = length;
            ParameterType = parameterType;
            _dynamicSpec = dynamicSpec;
        }

        public void Move(int steps)
        {
            this.Start += steps;
        }

        public void AddTam(int tam)
        {
            this.Length += tam;
        }
    }
}