using Assets.Scripts.Model;
using Assets.Scripts.Utility;
using Assets.Scripts.ViewModel.Scriptable;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ViewModel
{
    public class ButtonBinaryFloatOperatorModel : ButtonModel<BinaryFloatOperator>
    {
        [SerializeField] protected BinaryFloatOperation operation;

        private void Awake()
        {
            OperatorsPanel.Instance.RegisterOnPanel(this);
            value.Operation = operation;
        }

    }
}