using DebuffEffectSystem;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObserverEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textDebuff;
    private DebuffEffect _debuffEffect;

    private void Start()
    {
        _textDebuff.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _debuffEffect.OnActionEffect += DebuffEffectVisual;
        _debuffEffect.OnEffectEnd += HideDebuffText;
    }

    private void OnDisable()
    {
        _debuffEffect.OnActionEffect -= DebuffEffectVisual;
        _debuffEffect.OnEffectEnd -= HideDebuffText;
    }

    private void DebuffEffectVisual()
    {
        Debug.Log("Вызов события");
    }

    private void HideDebuffText()
    {
        _textDebuff.gameObject.SetActive(false);
    }
}
