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
        [SerializeField] private UnityEvent<T> OnPressed;

        public void RegisterOnPanel(ButtonModel<T> button)
        {
            button.Subscribe(value => OnPressed.Invoke(value));
        }
    }
}