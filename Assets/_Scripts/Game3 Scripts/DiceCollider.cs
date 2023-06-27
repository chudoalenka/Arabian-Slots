using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCollider : MonoBehaviour
{
    public static DiceCollider instance;

    public GameObject Collider;

    

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (this.gameObject.name == "Collider1")
        {
            //Game3Spinner.instance.diceNumber[0] = Convert.ToInt32(col.gameObject.name);
        }
        else
        {
            //Game3Spinner.instance.diceNumber[1] = Convert.ToInt32(col.gameObject.name);
        }

    }
}
