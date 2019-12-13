using System;
using System.Collections.Generic;
using System.Text;


namespace Portal.Domain.Values
{
    public class Money
    {
        public Money(int value)
        {
            Value = value;
        }
        public int Value { get; set; }



    }
}
