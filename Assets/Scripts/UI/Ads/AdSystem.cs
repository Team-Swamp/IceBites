using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI.Ads
{
    public sealed class AdSystem : MonoBehaviour
    {
        [SerializeField] private Sprite[] ads;
        [SerializeField] private Image displayAd;

        private void Awake() => displayAd.enabled = false;

        /// <summary>
        /// Toggle the visibility of the ad, also sets a new ad.
        /// </summary>
        public void ToggleAdVisibility()
        {
            displayAd.sprite = SetRandomAd();
            displayAd.enabled = !displayAd.enabled;
        }
 
        private Sprite SetRandomAd()
        {
            int randomNumber = Random.Range(0, ads.Length);
            Sprite target = ads[randomNumber];
            return target;
        }
    }
}