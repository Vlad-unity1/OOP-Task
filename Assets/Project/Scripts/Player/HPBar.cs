using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;

    public void Initialize(int maxHP)
    {
        hpSlider.maxValue = maxHP;
        hpSlider.value = maxHP;
    }

    public void UpdateHP(int currentHP)
    {
        hpSlider.value = currentHP;
    }
}