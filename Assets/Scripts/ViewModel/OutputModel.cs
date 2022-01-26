using System.Collections;
using UnityEngine;


namespace Assets.Scripts.ViewModel
{
    [RequireComponent(typeof(TMPro.TextMeshProUGUI))]
    public class OutputModel : MonoBehaviour
    {
        private void Awake()
        {
            text = GetComponent<TMPro.TextMeshProUGUI>();
        }

        private TMPro.TextMeshProUGUI text;
        public string Text
        {
            set { text.text = value; }
            get { return text.text; }
        }
    }
}