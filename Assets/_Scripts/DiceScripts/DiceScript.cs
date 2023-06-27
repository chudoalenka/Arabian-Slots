using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour {

	Rigidbody rb;
    public GameObject detector;
    public  Vector3 diceVelocity;
    public float xpos;
    public Animator DiceCupAnim;
    void Start () {
		rb = GetComponent<Rigidbody> ();       
        Physics.gravity = new Vector3(0,-50,0);
        rb.useGravity = false;
    }
	void Update () {
        diceVelocity = rb.velocity;
    }
    public void SpingNew()
    {
        DiceDetector.D1Value = 0;
        DiceDetector.D2Value = 0;
        detector.SetActive(false);
        DiceDetector.onetime = 0;
        DiceCupAnim.enabled = true;
        Invoke("stopcup", Random.Range(3.2f,4.8f));
        this.GetComponent<Animator>().enabled = true;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        

    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Cube")
        {
            detector.SetActive(true);
        }
    }
    public void newpos()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.useGravity = false;
        transform.localPosition = new Vector3(xpos, 880, -40);
    }
    public void stopcup()
    {
        rb.constraints = RigidbodyConstraints.None;
        detector.SetActive(true);
        DiceCupAnim.enabled = false;
        this.GetComponent<Animator>().enabled = false;
        rb.useGravity = true;
        Invoke("newpos", 2f);
    }
}
