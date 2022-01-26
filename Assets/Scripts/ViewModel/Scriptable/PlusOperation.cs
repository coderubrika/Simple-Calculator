using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ViewModel.Scriptable
{
    [CreateAssetMenu(fileName = "PlusOperation", menuName = "ScriptableObjects/Operations/Binary/Float/Plus", order = 1)]
    public class PlusOperation : BinaryFloatOperation
    {
        public override float Operator(float left, float right)
        {
            return left + right;
        }

    }
}