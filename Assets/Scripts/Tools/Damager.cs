using Assisstant;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private bool destroyAfterHit;
    public string targetTag { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out AssisstantHealth health))
        {
            if(other.gameObject.CompareTag(targetTag))
            {
                health.TakeDamage(damage);

                if(destroyAfterHit)
                    Destroy(gameObject);
            }
        }
    }
}
