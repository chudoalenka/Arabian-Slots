using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinmoving : MonoBehaviour {

    Transform coin;
    //public float distance;
    Rigidbody2D move;
    // Use this for initialization
    void Start()
    {
        move = GetComponent<Rigidbody2D>();
        coin= GameObject.FindGameObjectWithTag("coinobj").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

            //float dis = Vector3.Distance(player.position, transform.position);
            //if (dis < 160)
            //{
            //    float speed = 120 - dis;
            //    speed = speed * Time.deltaTime * 2f;
                transform.position = Vector3.MoveTowards(transform.position, coin.position, 50 * Time.deltaTime );
          //  }       
    }
}
