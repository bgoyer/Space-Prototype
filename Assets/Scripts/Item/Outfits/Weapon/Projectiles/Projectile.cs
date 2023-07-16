using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Projectile(int speed, int damage)
    {
        Speed = speed; 
        Damage = damage;
    }

    public int Speed { get; }
    public int Damage { get; }


    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Rigidbody2D>().velocity = transform.up * Speed;
        Destroy(gameObject, 5);
    }

    
}
