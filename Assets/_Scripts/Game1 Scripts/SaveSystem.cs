using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    

    public void SetScorePlayerPrefs(int check)
    {
        int temp = PlayerPrefs.GetInt("PlayerGold", 0);
        check += temp;
        PlayerPrefs.SetInt("PlayerGold", check);
    }

    public int GetScorePlayerPrefs()
    {
        return PlayerPrefs.GetInt("PlayerGold", 0);
    }
}
