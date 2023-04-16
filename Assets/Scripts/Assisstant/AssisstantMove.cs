using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assisstant
{
    public class AssisstantMove : MonoBehaviour
    {
        [SerializeField] private string targetTag;

        private bool _canMove;
        private NavMeshAgent _agent;
        public Transform target { get; private set; }

        private void Awake()
        {
            _canMove = false;
            _agent = GetComponent<NavMeshAgent>();
        }
        private void Start()
        {
            LevelManager.Instance.OnLevelStart += OnLevelStart;
            LevelManager.Instance.OnLevelCompelet += OnLevelCompelet;
            LevelManager.Instance.OnLevelFail += OnLevelFail;
        }
        private void Update()
        {
            //Animator.SetFloat("Move", _agent.velocity.magnitude);
            if (!_canMove) return;
            target = GetTarget();
            if (!target) return;
            _agent.SetDestination(target.position);
        }
        private void OnDestroy()
        {
            LevelManager.Instance.OnLevelStart -= OnLevelStart;
            LevelManager.Instance.OnLevelCompelet -= OnLevelCompelet;
            LevelManager.Instance.OnLevelFail -= OnLevelFail;
        }
        private void Move()
        {
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

        private void OnLevelStart()
        {
            _canMove = true;
        }
        private void OnLevelCompelet()
        {
            _canMove = false;
            _agent.enabled = false;
        }
        private void OnLevelFail()
        {
            _canMove = false;
            _agent.enabled = false;
        }
    }
}
