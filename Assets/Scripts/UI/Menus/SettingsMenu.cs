using System.Collections.Generic;
using FrameWork;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using Slider = UnityEngine.UI.Slider;

namespace UI.Menus
{
    public sealed class SettingsMenu : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private TMP_Dropdown graphicsDropdown;
        [SerializeField] private TMP_Dropdown resolutionsDropdown;
        [SerializeField] private Slider slider;
        [SerializeField] private Slider progressSlider;
        [Header("Saving")]
        [SerializeField] private bool customSettings;
        [Header("Scene Switcher")]
        [SerializeField] private SceneSwitcher sceneSwitcher;

        private Resolution[] _resolution;

        private void Awake()
        {
            if (progressSlider != null) 
                progressSlider.value = sceneSwitcher.Progress;
            LoadSettings();
        }

        #region Loading
        /// <summary>
        /// This loads all the custom settings, if there are no custom settings it will run default settings.
        /// </summary>
        public void LoadSettings()
        {
            PopulateResolutions();
            customSettings = PlayerPrefs.GetInt("CustomSettings", customSettings ? 1 : 0) == 1;
            if (!customSettings)
            {
                SetHighestQuality();
                PlayerPrefs.DeleteAll();
            }
            float volume = PlayerPrefs.GetFloat("Volume");
            int quality = PlayerPrefs.GetInt("Quality", QualitySettings.GetQualityLevel());
            bool fullscreen = PlayerPrefs.GetInt("Fullscreen", Screen.fullScreen ? 1 : 0 ) == 1;
            int resolution = PlayerPrefs.GetInt("Resolution", GetDefaultResolution());
            
            SetVolume(volume);
            SetQuality(quality);
            SetFullscreen(fullscreen);
            SetResolution(resolution);
        }
        #endregion

        #region Settings
        
        /// <summary>
        /// Apply's all settings and makes sure these don't get reset
        /// </summary>
        public void ApplySettings()
        {
            customSettings = true;
            PlayerPrefs.SetInt("CustomSettings", customSettings ? 1 : 0);
        }

        /// <summary>
        /// Sets the volume of the game at a certain volume.
        /// </summary>
        /// <param name="volume">This is the volume's level.</param>
        public void SetVolume(float volume)
        {
            audioMixer.SetFloat("volume", volume);
            slider.value = volume;
            PlayerPrefs.SetFloat("Volume", volume);
        }

        /// <summary>
        /// Sets the quality of the game
        /// </summary>
        /// <param name="qualityIndex">This is the index of the quality found in project settings > Quality.</param>
        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
            graphicsDropdown.value = qualityIndex;
            PlayerPrefs.SetInt("Quality", qualityIndex);
        }

        /// <summary>
        /// This allows the user to switch between fullscreen or not.
        /// </summary>
        /// <param name="isFullscreen">This bool checks if fullscreen is set or not</param>
        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
            PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        }

        /// <summary>
        /// This sets the resolution of the game.
        /// </summary>
        /// <param name="resolutionIndex">This index checks which resolution from the list it'll pick.</param>
        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = _resolution[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            resolutionsDropdown.value = resolutionIndex;
            PlayerPrefs.SetInt("Resolution", resolutionIndex);
        }
        
        private void SetHighestQuality()
        {
            int highestQuality = QualitySettings.GetQualityLevel();
            QualitySettings.SetQualityLevel(highestQuality);
            graphicsDropdown.value = highestQuality;
        }

        private int GetDefaultResolution()
        {
            int length = _resolution.Length;
            for (int i = 0; i < length; i++)
            {
                if (_resolution[i].width == Screen.currentResolution.width && 
                    _resolution[i].height == Screen.currentResolution.height)
                {
                    return i;
                }
            }

            return 0;
        }
        
        private void PopulateResolutions()
        {
            _resolution = Screen.resolutions;
            resolutionsDropdown.ClearOptions();

            List<string> options = new List<string>();
            int currentResolution = 0;
            int length = _resolution.Length;
            
            for (int i = 0; i < length; i++)
            {
                string option = $"{_resolution[i].width}x{_resolution[i].height}";
                options.Add(option);
            }
            resolutionsDropdown.AddOptions(options);
            resolutionsDropdown.value = currentResolution;
            resolutionsDropdown.RefreshShownValue();
        }
        #endregion

    }
}
