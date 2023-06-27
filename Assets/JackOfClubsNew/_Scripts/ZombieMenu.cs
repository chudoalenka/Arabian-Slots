using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ZombieMenu : MonoBehaviour
{
   public GameObject MenuCanvas,GamePlay;
   public AudioSource bttnsound;
   public int thisSceneNo;
    public static int slotstart = 0;

    private void Start()
    {
        if (slotstart == 0)
        {
            slotstart++;
            MenuCanvas.SetActive(true);
            GamePlay.SetActive(false);
        }
        else
        {
            MenuCanvas.SetActive(false);
            GamePlay.SetActive(true);

        }
        //if (PlayerPrefs.GetInt("sound") == 0)
        //{
        //    Sounds.SetActive(false);
        //}
    }
    public void MenuCanvasOnOF(bool value)
    {
        bttnsound.Play();
        MenuCanvas.SetActive(value);
        GamePlay.SetActive(!value);
    }
    public void newscene(int sceneno)
    {
        NewMenuManager.fromslot = 1;
        bttnsound.Play();
        PlayerPrefs.SetInt("LastScene", thisSceneNo);
        SceneManager.LoadScene(sceneno);
    }
}
