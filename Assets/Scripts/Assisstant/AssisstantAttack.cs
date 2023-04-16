using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assisstant
{
    public class AssisstantAttack : MonoBehaviour
    {
        [SerializeField] protected float attackDelay;

        protected float currentAttackTime;
        protected bool _canAttack;
        // Start is called before the first frame update
        protected virtual void Start()
        {
            LevelManager.Instance.OnLevelStart += OnLevelStart;
            LevelManager.Instance.OnLevelCompelet += OnLevelCompelet;
            LevelManager.Instance.OnLevelFail += OnLevelFail;
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (!_canAttack) return;
            currentAttackTime -= Time.deltaTime;

            if (currentAttackTime <= 0)
            {
                //Play Attack Animation
                Attack();
                currentAttackTime = attackDelay;
            }
        }
        protected virtual void OnDestroy()
        {
            LevelManager.Instance.OnLevelStart -= OnLevelStart;
            LevelManager.Instance.OnLevelCompelet -= OnLevelCompelet;
            LevelManager.Instance.OnLevelFail -= OnLevelFail;
        }

        public virtual void Attack()
        {

        }

        protected virtual void OnLevelStart()
        {
            _canAttack = true;
        }
        protected virtual void OnLevelCompelet()
        {
            _canAttack = false;
        }
        protected virtual void OnLevelFail()
        {
            _canAttack = false;
        }
    }
}
