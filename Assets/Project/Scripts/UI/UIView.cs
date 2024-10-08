using CharacterInfo;
using UnityEngine;
using UnityEngine.UI;
using WinnerWindowUI;

public class UIView : MonoBehaviour
{
    [SerializeField] private WinnerCheckUI _winner;
    [SerializeField] private Character _health;
    [SerializeField] private Slider _healthSlider;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
      
    }

    private void UpdateHealthDisplay(int currentHealth)
    {
        Debug.Log("Work");
        
    }

    public void ToDefeat(CharacterType type)
    {
        _winner.ShowWinner(type);
    }
}
