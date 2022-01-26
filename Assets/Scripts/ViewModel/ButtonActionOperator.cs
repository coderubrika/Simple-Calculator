using Assets.Scripts.Model;
using Assets.Scripts.Utility;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ViewModel
{
    public class ButtonActionOperator : ButtonModel<ActionOperator>
    {
        private void Awake()
        {
            ActionButtonsPanel.Instance.RegisterOnPanel(this);
        }
    }
}