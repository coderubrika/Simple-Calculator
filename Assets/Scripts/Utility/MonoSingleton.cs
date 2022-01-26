using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance = null;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance != null) DontDestroyOnLoad(instance);
                }

                return instance;
            }
        }
    }
}