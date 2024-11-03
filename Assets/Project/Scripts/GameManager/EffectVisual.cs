using System.Collections;
using TMPro;
using UnityEngine;

namespace EffectVisualization
{
    public class EffectVisual : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _effectsText;

        public void ShowEffect(string type, float duration)
        {
            _effectsText.text = type;
            StartCoroutine(HideEffectAfterDelay(duration));
        }

        private IEnumerator HideEffectAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            _effectsText.text = "";
        }
    }
}