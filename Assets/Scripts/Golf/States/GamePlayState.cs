using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Golf
{
    public class GamePLayState : GameState
    {
        public LevelController levelController;
        public PlayerController playerController;
        public GameState gameOverState;
        public TMP_Text scoreText;


        protected override void OnEnable()
        {
            base.OnEnable();

            levelController.enabled = true;
            playerController.enabled = true;

            GameEvents.onCollisionStone += OnGameOver;
            GameEvents.OnStickHit += OnStickHit;
        }

        private void OnStickHit()
        {
            scoreText.text = $"score : {levelController.highscore}";
        }

        private void OnGameOver()
        {
            Exit();
            gameOverState.Enter();

        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GameEvents.onCollisionStone -= OnGameOver;

            levelController.enabled = false;
            playerController.enabled = false;
        }
    }

}
