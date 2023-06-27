using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDetector : MonoBehaviour
{
    public static int D1Value, D2Value;
    public Game3Spinner g3s;
    Vector3 diceVelocity1,diceVelocity2;
    public DiceScript D1S, D2S;
    public static int onetime = 0;

    private void Start()
    {
        Invoke("Max", 2f);
    }
    void Update()
    {
        diceVelocity1 = D1S.diceVelocity;
        diceVelocity2 = D2S.diceVelocity;
        if (D1Value > 0 && D2Value > 0&&onetime==0)
        {
            Debug.Log("hoa");
            Invoke("Max",3f);
            onetime = 1;
            //if (diceVelocity1.y<0.1f&&diceVelocity1.y>-0.1f)
            //{
            //    Debug.Log("hoa2");
            //    g3s.IsPlayerWinOrNot();
            //    onetime = 1;
            //    D1S.newpos();D2S.newpos();
            //    CancelInvoke();
            //}
        }
    }  
    void Max()
    {
        Debug.Log("hoa2");
        g3s.IsPlayerWinOrNot();
      //  D1S.newpos(); D2S.newpos();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "D1") { D1Value = 1; }
        if (other.tag == "D2") { D1Value = 2; }
        if (other.tag == "D3") { D1Value = 3; }
        if (other.tag == "D4") { D1Value = 4; }
        if (other.tag == "D5") { D1Value = 5; }
        if (other.tag == "D6") { D1Value = 6; }

        if (other.tag == "DD1") { D2Value = 1; }
        if (other.tag == "DD2") { D2Value = 2; }
        if (other.tag == "DD3") { D2Value = 3; }
        if (other.tag == "DD4") { D2Value = 4; }
        if (other.tag == "DD5") { D2Value = 5; }
        if (other.tag == "DD6") { D2Value = 6; }
    }
   
}
