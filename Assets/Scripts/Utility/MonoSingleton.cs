using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance = null;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance != null) DontDestroyOnLoad(_instance);
                }

                return _instance;
            }
        }
    }
}