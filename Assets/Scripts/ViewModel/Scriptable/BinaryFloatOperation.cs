using Assets.Scripts.ViewModel.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ViewModel.Scriptable
{
    public abstract class BinaryFloatOperation : ScriptableObject, IBinaryOperation<float>
    {
        public abstract float Operator(float left, float right);
    }
}