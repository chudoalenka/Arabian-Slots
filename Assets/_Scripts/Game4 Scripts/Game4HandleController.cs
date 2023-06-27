using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Game4HandleController : MonoBehaviour, IPointerClickHandler
{
    public static Game4HandleController instance;
    int number;
    public GameObject bttns;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CallLuckySpin();
        bttns.SetActive(false);
    }

    public void CallLuckySpin()
    {
        number = Convert.ToInt32(Game4Manager.instance.inputField.text);

        if (int.TryParse(Game4Manager.instance.inputField.text, out number))
        {
            Game4Spinner.instance.handleUp.SetActive(false);
            Game4Spinner.instance.handleDown.SetActive(true);
            Game4Spinner.instance.LuckySpinner();
        }
    }
}
