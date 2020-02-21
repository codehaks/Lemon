using System;
using System.Collections.Generic;
using System.Text;


namespace Portal.Domain.Values
{
    public class Money
    {
        public Money(int value)
        {
            if (value >= 0)
            {
                Value = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("پول نمی تواند کمتر از 0 باشد!");
            }
        }
        public int Value { get; private set; }

    }
}
