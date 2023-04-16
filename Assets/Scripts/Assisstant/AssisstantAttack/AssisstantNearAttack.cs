using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assisstant
{
    [RequireComponent(typeof(AssisstantMove))]
    public class AssisstantNearAttack : AssisstantAttack
    {
        [SerializeField] private Damager attackBox;
        [SerializeField] private string targetTag;

        private AssisstantMove move;
        protected override void Start()
        {
            base.Start();
            attackBox.targetTag = targetTag;
            move = GetComponent<AssisstantMove>();

            attackBox.gameObject.SetActive(false);
        }

        protected override void Update()
        {
            if (move.target)
            {
                float distance = Vector3.Distance(transform.position, move.target.position);
                if (distance <= 2.5f)
                {
                    _canAttack = true;
                }
                else
                {
                    _canAttack = false;
                }
            }
            else
                _canAttack = false;

            base.Update();
        }

        public override void Attack()
        {
            base.Attack();
            Vector3 targetLook = move.target.position;
            targetLook.y = transform.position.y;
            transform.DOLookAt(targetLook, 0.2f);
            attackBox.gameObject.SetActive(true);
            StartCoroutine(InactiveAttackBox());
        }

        private IEnumerator InactiveAttackBox() 
        {
            yield return new WaitForSeconds(0.5f);
            attackBox.gameObject.SetActive(false);
        }

        protected override void OnLevelStart()
        {
        }
    }
}
