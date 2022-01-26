

using Assets.Scripts.ViewModel.Scriptable;
using System;

namespace Assets.Scripts.Utility
{
    public enum OperatorEnum
    {
        Plus, Minus, Multiply, Divide, Equal, None
    }

    public enum NumberEnum
    {
        Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine
    }

    [Serializable]
    public struct NumberChar
    {
        public char Char;
        public NumberEnum Number;
    }

    [Serializable]
    public struct BinaryFloatOperator
    {
        public char Char;
        public OperatorEnum OperatorEnum;
        public BinaryFloatOperation Operation;
    }

    [Serializable]
    public struct ActionOperator
    {
        public char Char;
        public OperatorEnum OperatorEnum;
    }
}
