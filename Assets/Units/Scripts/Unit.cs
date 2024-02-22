using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//creating the IDamageable interface reduced coupling and allows for non-units to be damageable
public interface IDamageble
{
    public void TakeDamage(int damage);
}
//the Unit script can be used to represent buildings and characters on the battlefield
public class Unit : MonoBehaviour, IDamageble
{
    public IntWrapper health;

    public void TakeDamage(int damage)
    {
        health.Value -= damage;
        if (health.Value <= 0) Destroy(gameObject);
    }
}
