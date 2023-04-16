using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class UIController : MonoBehaviour
    {
        public static UIController Instance { get; private set; }

        [SerializeField] private PanelHolder[] panelHolders;
        [SerializeField] private Button startButton;
        [SerializeField] private Button[] resetButtons;

        private Dictionary<string, GameObject> panelDic;

        private void Awake()
        {
            Instance = this;

            panelDic = new Dictionary<string, GameObject>();
            for (int i = 0; i < panelHolders.Length; i++)
            {
                panelDic.Add(panelHolders[i].panelName, panelHolders[i].panel);
            }
        }

        private void Start()
        {
            ActivePanel("Start");

            LevelManager.Instance.OnLevelStart += OnLevelStart;
            LevelManager.Instance.OnLevelFail += OnLevelFail;
            LevelManager.Instance.OnLevelCompelet += OnLevelCompelet;

            startButton.onClick.AddListener(() =>
            {
                LevelManager.Instance.LevelStart();
            });
            for (int i = 0; i < resetButtons.Length; i++)
            {
                resetButtons[i].onClick.AddListener(LevelManager.Instance.ResetLevel);
            }
        }

        public void ActivePanel(string panelName)
        {
            for (int i = 0; i < panelDic.Count; i++)
            {
                panelHolders[i].panel.SetActive(false);
            }
            panelDic[panelName].SetActive(true);
        }

        private void OnLevelStart()
        {
            ActivePanel("GamePlay");
        }
        private void OnLevelCompelet()
        {
            ActivePanel("Win");
        }
        private void OnLevelFail()
        {
            ActivePanel("Lose");
        }

        [System.Serializable]
        private class PanelHolder 
        {
            public string panelName;
            public GameObject panel;
        }
    }
}
