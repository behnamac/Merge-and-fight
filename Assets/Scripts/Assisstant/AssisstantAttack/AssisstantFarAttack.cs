using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Assisstant
{
    public class AssisstantFarAttack : AssisstantAttack
    {
        [SerializeField] private string targetTag;
        [SerializeField] private Damager bulletPrefab;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private float bulletSpeed;

        private Transform target;

        public override void Attack()
        {
            target = GetTarget();
            if (target)
            {
                base.Attack();

                Vector3 targetLook = target.position;
                targetLook.y = transform.position.y;
                transform.DOLookAt(targetLook, 0.2f);

                Vector3 shootPointLook = target.position;
                shootPointLook.y = transform.position.y;
                shootPoint.LookAt(shootPointLook);

                var bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
                bullet.targetTag = targetTag;
                bullet.GetComponent<Rigidbody>().velocity = shootPoint.forward * bulletSpeed;
                Destroy(bullet.gameObject, 5);
            }
        }

        private Transform GetTarget()
        {
            var targets = GameObject.FindGameObjectsWithTag(targetTag);

            if (targets.Length < 1) return null;

            Transform target = null;
            float oldDistance = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (i == 0)
                {
                    target = targets[0].transform;
                    oldDistance = Vector3.Distance(transform.position, target.position);
                }
                else
                {
                    float distance = Vector3.Distance(transform.position, targets[i].transform.position);
                    if (distance < oldDistance)
                    {
                        target = targets[i].transform;
                        oldDistance = distance;
                    }
                }
            }
            return target;
        }
    }
}
