using UnityEngine;
using UnityEngine.UI;

public class SliderPositionSaver : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        float savedValue = PlayerPrefs.GetFloat(gameObject.name, slider.value);
        slider.value = savedValue;
        slider.onValueChanged.AddListener(SaveSliderPosition);
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveListener(SaveSliderPosition);
    }

    private void SaveSliderPosition(float value)
    {
        PlayerPrefs.SetFloat(gameObject.name, value);
    }
}
