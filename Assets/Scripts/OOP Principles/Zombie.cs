using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            Attack();
        }
        if(Input.GetKeyDown(KeyCode.X)){
            TakeDamage(10f);
        }
        
    }
}
