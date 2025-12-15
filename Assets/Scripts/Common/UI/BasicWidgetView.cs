using TMPro;
using UnityEngine;

namespace Common.UI
{
    public sealed class BasicWidgetView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;
        
        public void UpdateText(string time)
        {
            _text.text = time;
        }
        
        /*public void SetAsFirstSibling()
        {
            transform.SetAsFirstSibling();
        }*/
    }
}