using System.Collections;
using System.Collections.Generic;
using Framework;
using TMPro;
using UnityEngine;

namespace FrameWork
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        public int TotalScore { get; private set; }
        
        [SerializeField] private TextMeshProUGUI scoreText;

        /// <summary>
        /// Function to increase the score
        /// </summary>
        /// <param name="scoreIncrease"> The score given by the NPC for completing their order </param>
        public void IncreaseScore(int scoreIncrease)
        {
            TotalScore += scoreIncrease;
            scoreText.text = "Score: " + TotalScore;
        }
    }
}