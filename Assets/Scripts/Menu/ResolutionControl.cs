using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionControl : MonoBehaviour
{
    public TextMeshProUGUI resolutionText;
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullScreenToggle;

    private Resolution[] resolutions;

    void Start()
    {
        // Get unique resolutions
        List<Resolution> uniqueResolutions = new List<Resolution>();
        foreach (Resolution resolution in Screen.resolutions)
        {
            if (!uniqueResolutions.Contains(resolution))
            {
                uniqueResolutions.Add(resolution);
            }
        }
        resolutions = uniqueResolutions.ToArray();

        // Populate the dropdown with the available resolutions
        resolutionDropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $"{resolutions[i].width} x {resolutions[i].height}";
            options.Add(new TMP_Dropdown.OptionData(option));

            // Set the currently selected resolution as the default option
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.SetValueWithoutNotify(currentResolutionIndex);

        // Set the toggle to the current full screen mode
        fullScreenToggle.isOn = Screen.fullScreen;
    }


    public void ApplyChanges()
    {
        // Apply the selected resolution and full screen mode
        Resolution selectedResolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, fullScreenToggle.isOn);

        // Save the player's settings
        PlayerPrefs.SetInt("ScreenWidth", selectedResolution.width);
        PlayerPrefs.SetInt("ScreenHeight", selectedResolution.height);
        PlayerPrefs.SetInt("FullScreen", fullScreenToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();

        // Update the resolution text
        resolutionText.text = $"{selectedResolution.width} x {selectedResolution.height}";
    }
}
