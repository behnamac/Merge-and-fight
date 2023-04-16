using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;

namespace Assisstant
{
    public class AssisstantSlot : MonoBehaviour
    {
        public AssisstantDrag Assisstant { get; set; }
        public void Drop(AssisstantDrag assisstant)
        {
            if (!Assisstant)
            {
                Assisstant = assisstant;
                Assisstant.transform.position = transform.position;
                Assisstant.Slot = this;
            }
            else
            {
                if (Assisstant.Index == assisstant.Index && Assisstant.Type == assisstant.Type)
                {
                    if (assisstant.Type == AssisstantType.Near)
                    {
                        if (Assisstant.Index + 1 < AssisstantController.Instance.assisstantNearPrefabs.Length)
                            AssisstantController.Instance.MergeNear(Assisstant, assisstant, this);
                        else
                            assisstant.Relese();
                    }
                    else 
                    {
                        if (Assisstant.Index + 1 < AssisstantController.Instance.assisstantFarPrefabs.Length)
                            AssisstantController.Instance.MergeFar(Assisstant, assisstant, this);
                        else
                            assisstant.Relese();
                    }
                }
                else
                    assisstant.Relese();
            }
        }
    }
}
