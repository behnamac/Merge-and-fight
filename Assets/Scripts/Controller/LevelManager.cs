using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Controller
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }

        public UnityAction OnLevelStart;
        public UnityAction OnLevelCompelet;
        public UnityAction OnLevelFail;

        private void Awake()
        {
            Instance = this;
        }

        public void LevelStart() 
        {
            OnLevelStart?.Invoke();
        }

        public void LevelCompelet() 
        {
            OnLevelCompelet?.Invoke();
        }

        public void LevelFail() 
        {
            OnLevelFail?.Invoke();
        }

        public void ResetLevel() 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
