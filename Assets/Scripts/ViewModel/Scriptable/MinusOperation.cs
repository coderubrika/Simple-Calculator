using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ViewModel.Scriptable
{
    [CreateAssetMenu(fileName = "MinusOperation", menuName = "ScriptableObjects/Operations/Binary/Float/Minus", order = 2)]
    public class MinusOperation : BinaryFloatOperation
    {
        public override float Operator(float left, float right)
        {
            return left - right;
        }

    }
}