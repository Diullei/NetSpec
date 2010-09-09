using System;

namespace NetSpec.Core
{
    public class SpecificationBreakLineNormalize : ISpecificationNormalize
    {
        private int _index = -1;
        private Specification _specification;

        public void DoNormalize(Specification specification)
        {
            _specification = specification;

            while (GetNext() != null)
            {
                var current = GetCurrent();

                if (current.GetLineType() == LineType.Executable | current.GetLineType() == LineType.BreakLine)
                {
                    if (PrevewNext() != null)
                    {
                        if (PrevewNext().GetLineType() == LineType.BreakLine)
                        {
                            current.PrepareJoinNext();
                        }
                        else if (current.GetLineType() == LineType.BreakLine)
                        {
                            current.JoinLine();
                        }
                    }
                    else if (current.GetLineType() == LineType.BreakLine)
                    {
                        current.JoinLine();
                    }
                }
            }
        }

        public void ResetCursor()
        {
            _index = -1;
        }

        public LineSpec GetNext()
        {
            _index++;

            if (_index < _specification.LineSpecCollection.Count)
            {
                return _specification.LineSpecCollection[_index];
            }
            
            return null;
        }

        public LineSpec PrevewNext()
        {
            return (_index + 1) < _specification.LineSpecCollection.Count 
                       ? _specification.LineSpecCollection[_index + 1] 
                       : null;
        }

        public LineSpec GetCurrent()
        {
            return _index < _specification.LineSpecCollection.Count
                       ? _specification.LineSpecCollection[_index]
                       : null;
        }
    }
}