using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public AudioSource bttnsound;
    public void LoadScene(int sceneno)
    {
        bttnsound.Play();
        ZombieMenu.slotstart = 0;
        StartCoroutine(Fade(sceneno));     
    }
    IEnumerator Fade(int s)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(s);
    }
}
