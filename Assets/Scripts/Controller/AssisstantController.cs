using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class AssisstantController : MonoBehaviour
    {
        public static AssisstantController Instance { get; private set; }

        [SerializeField] private int defaultNumberAssisstant;
        [SerializeField] private AssisstantSlot[] slots;
        public AssisstantDrag[] assisstantPrefabs;
        [SerializeField] private Button buyAssisstantButton;

        private void Awake()
        {
            Instance = this;

            buyAssisstantButton.onClick.AddListener(BuyAssisstant);
        }

        private void Start()
        {
            for (int i = 0; i < defaultNumberAssisstant; i++)
            {
                SpawnAssisstant(assisstantPrefabs[0], slots[i]);
            }
        }

        public void SpawnAssisstant(AssisstantDrag assisstant, AssisstantSlot slot)
        {
            var assisst = Instantiate(assisstant);
            slot.Drop(assisst);
        }

        public void Merge(AssisstantDrag assisstantA, AssisstantDrag assisstantB, AssisstantSlot slot)
        {
            int indexNewAssisstant = assisstantA.Index + 1;
            Destroy(assisstantA.gameObject);
            Destroy(assisstantB.gameObject);
            slot.Assisstant = null;
            SpawnAssisstant(assisstantPrefabs[indexNewAssisstant], slot);
        }
        public void BuyAssisstant() 
        {
            var slot = GetSlot();
            if(!slot) return;
            SpawnAssisstant(assisstantPrefabs[0], slot);
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
