using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 10f;
    public int damage = 1;
    public bool destroyOnHit = true;

    void Update() => transform.position += transform.forward * moveSpeed * Time.deltaTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IDamageble>(out var damageObject))
        {
            damageObject.TakeDamage(damage);
            if (destroyOnHit) Destroy(gameObject);
        }
    }
}
