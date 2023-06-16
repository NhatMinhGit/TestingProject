using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Có chức năng cho phép lập trình phần UI

public class Sound_Manager : MonoBehaviour
{
    [SerializeField] Slider slider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = slider.value; //Giá trị của AudioListener (aka Volumn của game) == Giá trị hiển thị trên slider
        Save();
    }

    public void Load()
    {
        slider.value = PlayerPrefs.GetFloat("musicVolume");//đẩy
    }

    public void Save()// Có chức năng lưu lại giá trị âm thanh mà người chơi đã chỉnh
    {
        PlayerPrefs.SetFloat("musicVolume", slider.value);//lưu
    }

}
