using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force : MonoBehaviour {
    public Rigidbody2D rb;
    public coinmoving cm;
    public CircleCollider2D cd;
    void Start () {
        rb.GetComponent<Rigidbody2D>();
        cm.GetComponent<coinmoving>();
        cd.GetComponent<Collider>();
        cm.enabled = false;
        Invoke("ActiveCoin", 0.2f);
    }
		void Update () {
        rb.AddForce(transform.forward * 20);
    }
    void ActiveCoin()
    {
        cm.enabled = true;
        cd.enabled = false;
    }
}
