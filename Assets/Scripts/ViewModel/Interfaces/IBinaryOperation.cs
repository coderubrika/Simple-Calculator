using System;

namespace Assets.Scripts.ViewModel.Interfaces
{
    public interface IBinaryOperation<T>
    {
        public T Operator(T left, T right);
    }
}
