using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LABA
{
    class Model
    {
        private int _A;
        private int _B;
        private int _C;

        public int A
        {
            get
            {
                return _A;
            }
            set
            {
                _A = value;
                if (_A > _B)
                {
                    _B = _A;
                }
                if (_A > _C)
                {
                    _C = _A;
                }
                calculated?.Invoke(this, null);
            }
        }
        public int B
        {
            get
            {
                return _B;
            }
            set
            {
                if (value >= _A && value <= _C)
                {
                    _B = value;
                }

                calculated?.Invoke(this, null);
            }
        }
        public int C
        {
            get
            {
                return _C;
            }
            set
            {
                _C = value;
                if (_C < _B)
                {
                    _B = _C;
                }
                if (_C < _A)
                {
                    _A = _C;
                }
                calculated?.Invoke(this, null);
            }
        }
        public EventHandler calculated;
    }
}
