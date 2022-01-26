using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ViewModel
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonModel<T> : MonoBehaviour
    {
        [SerializeField] protected T value;
        private event Action<T> _onPressed;

        private bool _initialized = false;

        public void Subscribe(Action<T> action)
        {
            if (!_initialized)
            {
                _initialized = true;
                Button button = GetComponent<Button>();
                button.onClick.AddListener(() => {
                    Press(value);
                });
            }

            _onPressed += action;
        }

        private void Press(T value)
        {
            if (_onPressed != null) _onPressed.Invoke(value);
        }
    }
}

