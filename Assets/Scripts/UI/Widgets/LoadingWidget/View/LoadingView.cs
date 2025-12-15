using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Widgets.LoadingWidget
{
    public sealed class LoadingView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _progressText;
        
        [SerializeField]
        private Slider _progressBar;

        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public void UpdateProgressText(string progressText)
        {
            _progressText.text = progressText;
        }

        public void UpdateProgressBar(float progress)
        {
            _progressBar.value = progress;
        }
    }
}