using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assisstant
{
    public enum AssisstantType { Near, Fat }
    public class AssisstantDrag : MonoBehaviour
    {
        public int Index;
        public AssisstantType Type;

        private Collider _collider;
        private Rigidbody _rigidbody;
        private NavMeshAgent _agent;

        public AssisstantSlot Slot { get; set; }
        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _rigidbody = GetComponent<Rigidbody>();
            _agent = GetComponent<NavMeshAgent>();
        }
        public void Select()
        {
            if (Slot)
                Slot.Assisstant = null;
        }

        public void Drag(Vector3 movePos)
        {
            Vector3 targetPos = movePos;
            targetPos.y = transform.position.y;
            transform.position = Vector3.Lerp(transform.position, targetPos, 10 * Time.deltaTime);
        }

        public void Relese()
        {
            if (Slot)
                Slot.Drop(this);
        }

        public void SetActiveCollider(bool value)
        {
            _collider.enabled = value;
            _rigidbody.isKinematic = !value;

            if (_agent) 
            {
                _agent.enabled = value;
            }
        }
    }
}
