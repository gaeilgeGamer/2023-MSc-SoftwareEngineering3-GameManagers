using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Enemy
{
    

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.R))
      {
        Attack();
      } 
      if(Input.GetKeyDown(KeyCode.T)){
        TakeDamage(10f);
      }
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage * .75f);
        Debug.Log("Robot's armour reduced damage");
    }

    public override void Attack()
    {
        base.Attack();
        Debug.Log("Robot fires a laser!");
    }
}
