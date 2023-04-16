using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssisstantDrag : MonoBehaviour
{
    public int Index;

    private Collider _collider;
    private Rigidbody _rigidbody;

    public AssisstantSlot Slot { get; set; }
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
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
    }
}
