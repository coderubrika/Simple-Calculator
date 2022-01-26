using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ViewModel.Scriptable
{
    [CreateAssetMenu(fileName = "MultiplyOperation", menuName = "ScriptableObjects/Operations/Binary/Float/Multiply", order = 3)]
    public class MultiplyOperation : BinaryFloatOperation
    {
        public override float Operator(float left, float right)
        {
            return left * right;
        }

    }
}