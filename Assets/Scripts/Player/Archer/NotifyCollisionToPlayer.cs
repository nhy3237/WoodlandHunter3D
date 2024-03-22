using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyCollisionToPlayer : MonoBehaviour
{
    public delegate void CollisionEventHandler(Collider other);
    public event CollisionEventHandler OnCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            Debug.Log("collision");
            OnCollision?.Invoke(other);
        }
    }
    
}
