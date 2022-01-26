using Assets.Scripts.Model;
using Assets.Scripts.Utility;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ViewModel
{
    public sealed class  ButtonNumber : ButtonModel<NumberChar>
    {
        
        private void Awake()
        {
            Dial.Instance.RegisterOnPanel(this);
        }
    }
}