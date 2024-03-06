using System.Collections.Generic;
using FrameWork;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using Slider = UnityEngine.UI.Slider;

namespace UI.Menus
{
    public sealed class SettingsMenu : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private TMP_Dropdown graphicsDropdown;
        [SerializeField] private TMP_Dropdown resolutionsDropdown;
        [SerializeField] private TMP_Dropdown ratiosDropdown;
        [SerializeField] private GameObject fullScreen;
        [SerializeField] private Slider volumeSlider;
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
            bool isMobile = Application.platform == RuntimePlatform.Android
                            || Application.platform == RuntimePlatform.IPhonePlayer;
            
            if (isMobile)
                LoadMobileSettings();
            
            PopulateResolutions();
            customSettings = PlayerPrefs.GetInt("CustomSettings", customSettings ? 1 : 0) == 1;
            
            if (!customSettings)
            {
                SetHighestQuality();
                PlayerPrefs.DeleteAll();
            }
            
            float volume = PlayerPrefs.GetFloat("Volume");
            bool fullscreen = PlayerPrefs.GetInt("Fullscreen", Screen.fullScreen ? 1 : 0 ) == 1;
            int quality = PlayerPrefs.GetInt("Quality", QualitySettings.GetQualityLevel());
            int resolution = PlayerPrefs.GetInt("Resolution", GetDefaultResolution());
            int ratio = PlayerPrefs.GetInt("Ratio");
            
            SetVolume(volume);
            SetQuality(quality);
            SetFullscreen(fullscreen);
            
            if (isMobile)
                SetRatio(ratio);
            else
                SetResolution(resolution);
        }

        /// <summary>
        /// Set the aspect ratio for the application, used by Unity events.
        /// </summary>
        public void SetRatio() => SetRatio(ratiosDropdown.value);
        
        private void SetRatio(int ratio)
        {
            const int HEIGHT = 1080;
    
            switch (ratio)
            {
                case 0:
                    Screen.SetResolution(1920, HEIGHT, Screen.fullScreen);
                    break;
                case 1:
                    Screen.SetResolution(2560, HEIGHT, Screen.fullScreen);
                    break;
                case 2:
                    Screen.SetResolution(2400, HEIGHT, Screen.fullScreen);
                    break;
                case 3:
                    Screen.SetResolution(1440, HEIGHT, Screen.fullScreen);
                    break;
                case 4:
                    Screen.SetResolution(1552, HEIGHT, Screen.fullScreen);
                    break;
                case 5:
                    Screen.SetResolution(2340, HEIGHT, Screen.fullScreen);
                    break;
                default:
                    Screen.SetResolution(1920, HEIGHT, Screen.fullScreen);
                    Debug.LogWarning("Unsupported aspect ratio.");
                    ratio = 0;
                    return;
            }
            
            PlayerPrefs.SetInt("Ratio", ratio);
        }
        
        private void LoadMobileSettings()
        {
            SetHighestQuality();
            PlayerPrefs.DeleteAll();
            resolutionsDropdown.gameObject.SetActive(false);
            fullScreen.SetActive(false);
        }
        
        #endregion

        #region Settings
        
        /// <summary>
        /// Applies all settings and makes sure these don't get reset
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
            volumeSlider.value = volume;
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
                    return i;
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
