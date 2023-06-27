using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMoving : MonoBehaviour
{
    int RandomValue;
    public int Min,Max;
    public float gap,smallgap;
    Vector2 Pos;
    public ZombieGameManager Zm;
    public bool istopped;
    float zombielast,bdaylast;
    public float lastvalue;
    public float ylastpos;
    int onetime = 0;
    void Start()
    {
        zombielast = 45.4f;
        bdaylast = 40f;
        // lastvalue = bdaylast;
    }
    private void Update()
    {
        if (ZombieGameManager.autorotate == 1&&onetime==0)
        {
            Invoke("Rotating",2f);
           // Rotating();
            onetime++;
            
        }
    }
    public void Rotating()
    {
        Time.timeScale = 1f;
        Zm.coinseffect.SetActive(false);
        Zm.Lines.SetActive(false);
        StartCoroutine(Rotate());
        istopped = false;
        transform.position = new Vector3(transform.position.x, lastvalue, 0);
    }
    IEnumerator Rotate()
    {
        int r = Random.Range(Min, Max);
        for (int i = 0; i <r; i++)
        {
            if (transform.position.y < ylastpos)
            { transform.position = new Vector3(transform.position.x, lastvalue, 0); }

            transform.position = new Vector3(transform.position.x, transform.position.y - gap,0);

            if (i == r - 2)
            {
                for (int j = 0; j < 160; j++)
                {
                    if (transform.position.y < ylastpos)
                    { transform.position = new Vector3(transform.position.x, lastvalue, 0); }

                    transform.position = new Vector3(transform.position.x, transform.position.y - smallgap, 0);
                    yield return new WaitForSeconds(0f);
                }
                break;
            }
            yield return new WaitForSeconds(0f);
        }
        onetime = 0;
        ZombieGameManager.autorotate = 0;
        istopped = true;
    }    
}
