using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assisstant;

namespace Controller
{
    public class DragController : MonoBehaviour
    {
        private AssisstantDrag _assisstant;
        private void Update()
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                Selected();
            }
            else if (Input.GetMouseButton(0))
            {
                Drag();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Relese();
            }
        }

        private void Selected() 
        {
            var hit = GetRayCast();
            if (hit.collider.TryGetComponent(out AssisstantDrag assisstant))
            {
                assisstant.Select();
                _assisstant = assisstant;
                var assisstants = FindObjectsOfType<AssisstantDrag>();
                for (int i = 0; i < assisstants.Length; i++)
                {
                    assisstants[i].SetActiveCollider(false);
                }
            }
        }
        private void Drag()
        {
            if(!_assisstant) return;
            var hit = GetRayCast();
            _assisstant.Drag(hit.point);
        }
        private void Relese()
        {
            if(!_assisstant) return;
            var hit = GetRayCast();

            if (hit.collider.TryGetComponent(out AssisstantSlot slot))
            {
                slot.Drop(_assisstant);
            }
            else
            {
                _assisstant.Relese();
            }

            var assisstants = FindObjectsOfType<AssisstantDrag>();
            for (int i = 0; i < assisstants.Length; i++)
            {
                assisstants[i].SetActiveCollider(true);
            }
            _assisstant = null;
        }

        private RaycastHit GetRayCast()
        {
            Vector3 mousePosFar = Input.mousePosition + Vector3.forward * Camera.main.farClipPlane;
            Vector3 mousePosNear = Input.mousePosition + Vector3.forward * Camera.main.nearClipPlane;

            Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
            Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

            RaycastHit hit = new RaycastHit();
            Ray ray = new Ray(mousePosN, mousePosF - mousePosN);
            Physics.Raycast(ray, out hit);
            return hit;
        }
    }
}
