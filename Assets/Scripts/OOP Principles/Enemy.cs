using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float health = 100f;
    public virtual void TakeDamage(float damage){
        health -= damage; 
        Debug.Log(gameObject.name + " took damage. Current health: " + health);
        }
    public virtual void Attack(){
        Debug.Log(gameObject.name + "Attacks!");
    }
}
