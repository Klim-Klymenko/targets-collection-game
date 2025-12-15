using TMPro;
using UnityEngine;

namespace Common.UI
{
    public sealed class ScoreView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreText;
        
        public void UpdateScoreText(string time)
        {
            _scoreText.text = time;
        }
    }
}