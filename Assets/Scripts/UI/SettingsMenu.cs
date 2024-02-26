using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

namespace UI
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private TMP_Dropdown graphicsDropdown;
        [SerializeField] private TMP_Dropdown resolutionsDropdown;

        private Resolution[] _resolution;


        private void Awake()
        {
            SetHighestQuality();
            PopulateResolutions();
        }

        private void SetHighestQuality()
        {
            int highestQuality = QualitySettings.GetQualityLevel();
            QualitySettings.SetQualityLevel(highestQuality);
            graphicsDropdown.value = highestQuality;
        }

        /// <summary>
        /// Sets the volume of the game at a certain volume.
        /// </summary>
        /// <param name="volume">This is the volume's level.</param>
        public void SetVolume(float volume) => audioMixer.SetFloat("volume", volume);

        public void SetQuality(int qualityIndex) => QualitySettings.SetQualityLevel(qualityIndex);
        
        public void SetFullscreen(bool isFullscreen) => Screen.fullScreen = isFullscreen;

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = _resolution[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public void PopulateResolutions()
        {
            _resolution = Screen.resolutions;
            resolutionsDropdown.ClearOptions();

            List<string> options = new List<string>();
            int currentResolution = 0;
            int screenWidth = Screen.currentResolution.width;
            int screenHeight = Screen.currentResolution.height;
            
            for (int i = 0; i < _resolution.Length; i++)
            {
                string option = $"{_resolution[i].width}x{_resolution[i].height}";
                options.Add(option);

                if (_resolution[i].width == screenWidth && _resolution[i].height == screenHeight)
                {
                    currentResolution = i;
                }
            }
            resolutionsDropdown.AddOptions(options);
            resolutionsDropdown.value = currentResolution;
            resolutionsDropdown.RefreshShownValue();
        }
    }
}
