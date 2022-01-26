using Assets.Scripts.Utility;
using Assets.Scripts.ViewModel;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class ButtonsPanel<T> : MonoSingleton<ButtonsPanel<T>>
    {
        [SerializeField] private UnityEvent<T> _onPressed;

        public void RegisterOnPanel(ButtonModel<T> button)
        {
            button.Subscribe(value => _onPressed.Invoke(value));
        }
    }
}