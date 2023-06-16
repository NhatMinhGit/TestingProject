using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Transform HpBarData;
    public Slider slider;
    // Start is called before the first frame update
    private void Update()
    {
        UpdateHpBar();
    }

    private void UpdateHpBar()
    {
        if (this.slider == null) return;
        IhpBarInterface hpBarInterface = this.HpBarData.GetComponent<IhpBarInterface>();
        if (hpBarInterface == null) return;
        this.slider.value = hpBarInterface.HP();
    }


    
}
