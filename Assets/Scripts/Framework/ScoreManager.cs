using Framework;
using TMPro;
using UnityEngine;

namespace FrameWork
{
    public sealed class ScoreManager : Singleton<ScoreManager>
    {
        private const string SCORE_TEXT = "Score: ";
        
        [SerializeField] private TextMeshProUGUI scoreText;
        
        public int TotalScore { get; private set; }

        /// <summary>
        /// Function to increase the score
        /// </summary>
        /// <param name="scoreIncrease"> The score given by the NPC for completing their order </param>
        public void IncreaseScore(int scoreIncrease)
        {
            TotalScore += scoreIncrease;
            scoreText.text = SCORE_TEXT + TotalScore;
        }
    }
}