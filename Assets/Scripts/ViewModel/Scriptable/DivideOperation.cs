using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ViewModel.Scriptable
{
    [CreateAssetMenu(fileName = "DivideOperation", menuName = "ScriptableObjects/Operations/Binary/Float/Divide", order = 4)]
    public class DivideOperation : BinaryFloatOperation
    {
        public override float Operator(float left, float right)
        {
            return left / right;
        }

    }
}