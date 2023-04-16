using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;

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
            if (Assisstant.Index == assisstant.Index)
            {
                if (Assisstant.Index + 1 < AssisstantController.Instance.assisstantPrefabs.Length)
                    AssisstantController.Instance.Merge(Assisstant, assisstant, this);
                else
                    assisstant.Relese();
            }
            else
                assisstant.Relese();
        }
    }
}
