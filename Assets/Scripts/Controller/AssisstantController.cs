using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assisstant;

namespace Controller
{
    public class AssisstantController : MonoBehaviour
    {
        public static AssisstantController Instance { get; private set; }

        [SerializeField] private int defaultNumberAssisstantNear;
        [SerializeField] private int defaultNumberAssisstantFar;
        [SerializeField] private AssisstantSlot[] slots;
        public AssisstantDrag[] assisstantNearPrefabs;
        public AssisstantDrag[] assisstantFarPrefabs;
        [SerializeField] private Button buyAssisstantNearButton;
        [SerializeField] private Button buyAssisstantFarButton;

        private void Awake()
        {
            Instance = this;

            buyAssisstantNearButton.onClick.AddListener(BuyAssisstantNear);
            buyAssisstantFarButton.onClick.AddListener(BuyAssisstantFar);
        }

        private void Start()
        {
            for (int i = 0; i < defaultNumberAssisstantNear; i++)
            {
                SpawnAssisstant(assisstantNearPrefabs[0], GetSlot());
            }

            for (int i = 0; i < defaultNumberAssisstantFar; i++)
            {
                SpawnAssisstant(assisstantFarPrefabs[0], GetSlot());
            }
        }

        public void SpawnAssisstant(AssisstantDrag assisstant, AssisstantSlot slot)
        {
            var assisst = Instantiate(assisstant);
            slot.Drop(assisst);
        }

        public void MergeNear(AssisstantDrag assisstantA, AssisstantDrag assisstantB, AssisstantSlot slot)
        {
            int indexNewAssisstant = assisstantA.Index + 1;
            Destroy(assisstantA.gameObject);
            Destroy(assisstantB.gameObject);
            slot.Assisstant = null;
            SpawnAssisstant(assisstantNearPrefabs[indexNewAssisstant], slot);
        }
        public void MergeFar(AssisstantDrag assisstantA, AssisstantDrag assisstantB, AssisstantSlot slot)
        {
            int indexNewAssisstant = assisstantA.Index + 1;
            Destroy(assisstantA.gameObject);
            Destroy(assisstantB.gameObject);
            slot.Assisstant = null;
            SpawnAssisstant(assisstantFarPrefabs[indexNewAssisstant], slot);
        }
        public void BuyAssisstantNear() 
        {
            var slot = GetSlot();
            if(!slot) return;
            SpawnAssisstant(assisstantNearPrefabs[0], slot);
        }
        public void BuyAssisstantFar()
        {
            var slot = GetSlot();
            if (!slot) return;
            SpawnAssisstant(assisstantFarPrefabs[0], slot);
        }
        public void CheckAssisstants() 
        {
            var enemys = GameObject.FindGameObjectsWithTag("Enemy");
            var players = GameObject.FindGameObjectsWithTag("Player");

            if (enemys.Length <= 0)
            {
                LevelManager.Instance.LevelCompelet();
            }
            else if(players.Length <= 0)
            {
                LevelManager.Instance.LevelFail();
            }
        }

        private AssisstantSlot GetSlot() 
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (!slots[i].Assisstant)
                {
                    return slots[i];
                }
            }
            return null;
        }
    }
}
