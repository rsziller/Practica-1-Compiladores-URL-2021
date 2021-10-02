using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01
{
    public enum TokenType
    {
        Plus = '+',
        Minus = '-',
        Multiply = '*',
        Divide = '/',
        LParen = '(',
        RParen = ')',
        EOF = (char)0,
        Empty = (char)1,
        Null = (char)2,
        Symbol = (char)3,
        Number = (char)4

    }
}
