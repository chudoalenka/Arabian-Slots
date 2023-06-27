using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovingMini : MonoBehaviour
{
    public int r;
    public bool IsStopped;
    public float lastpos,endpos,gap,minigap;
    void Start()
    {
        IsStopped = false;
    }
    private void Update()
    {
    }
    public void Rotating()
    {
        IsStopped = false;
        Time.timeScale = 0.95f;
        StartCoroutine(Rotate());
        transform.position = new Vector3(transform.position.x, lastpos, 0);
    }

IEnumerator Rotate()
{
    r = Random.Range(ZombieMiniManager.RandomValue, ZombieMiniManager.RandomValue + 1);

    for (int i = 0; i < r; i++)
    {
        if (transform.position.y < endpos)
        { transform.position = new Vector3(transform.position.x, lastpos, 0); }

        transform.position = new Vector3(transform.position.x, transform.position.y - gap, 0);
            int k = 0;
            if (i == r - 2)
            {
                for (int j = 0; j < 33; j++)
                {
                    Debug.Log(k++);
                    transform.position = new Vector3(transform.position.x, transform.position.y - minigap, 0);
                    if (transform.position.y < endpos)
                    { transform.position = new Vector3(transform.position.x, lastpos, 0); }

                   
                    yield return new WaitForSeconds(0f);
                }
                break;
            }
            yield return new WaitForSeconds(0f);
    }
        IsStopped = true;
}    
}