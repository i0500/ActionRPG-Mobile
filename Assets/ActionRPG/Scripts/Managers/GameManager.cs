using UnityEngine;
using System.Collections.Generic;

namespace ActionRPG.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Game Settings")]
        public bool debugMode = true;
        public float gameSpeed = 1f;
        
        [Header("Player Settings")]
        public GameObject playerPrefab;
        public Transform playerSpawnPoint;
        
        [Header("Level Settings")]
        public int currentLevel = 1;
        public int maxLevel = 100;
        
        // Singleton pattern
        public static GameManager Instance { get; private set; }
        
        // Game state
        public bool IsGamePaused { get; private set; }
        public bool IsGameOver { get; private set; }
        public float GameTime { get; private set; }
        
        // Events
        public System.Action<int> OnLevelChanged;
        public System.Action OnGameStart;
        public System.Action OnGamePause;
        public System.Action OnGameResume;
        public System.Action OnGameOver;
        
        private void Awake()
        {
            // Singleton setup
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitializeGame();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void Update()
        {
            if (!IsGamePaused && !IsGameOver)
            {
                GameTime += Time.deltaTime;
            }
        }
        
        private void InitializeGame()
        {
            // Initialize all game systems
            Time.timeScale = gameSpeed;
            Application.targetFrameRate = 60;
            
            if (debugMode)
                Debug.Log("[GameManager] Game Initialized");
        }
        
        public void StartGame()
        {
            IsGameOver = false;
            IsGamePaused = false;
            OnGameStart?.Invoke();
            
            if (debugMode)
                Debug.Log("[GameManager] Game Started");
        }
        
        public void PauseGame()
        {
            IsGamePaused = true;
            Time.timeScale = 0f;
            OnGamePause?.Invoke();
            
            if (debugMode)
                Debug.Log("[GameManager] Game Paused");
        }
        
        public void ResumeGame()
        {
            IsGamePaused = false;
            Time.timeScale = gameSpeed;
            OnGameResume?.Invoke();
            
            if (debugMode)
                Debug.Log("[GameManager] Game Resumed");
        }
        
        public void GameOver()
        {
            IsGameOver = true;
            Time.timeScale = 0f;
            OnGameOver?.Invoke();
            
            if (debugMode)
                Debug.Log("[GameManager] Game Over");
        }
        
        public void RestartGame()
        {
            Time.timeScale = 1f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        
        public void ChangeLevel(int newLevel)
        {
            if (newLevel >= 1 && newLevel <= maxLevel)
            {
                currentLevel = newLevel;
                OnLevelChanged?.Invoke(currentLevel);
                
                if (debugMode)
                    Debug.Log($"[GameManager] Level changed to {currentLevel}");
            }
        }
    }
}