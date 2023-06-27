using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    public GameObject loadingScrn,Game3Panel;
    public Slider slider;
    public Text progressTxt;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //public Image FantasyImg, WestImg;

    public void LoadLevel(int sceneIndex)
    {
        Game3Panel.SetActive(false);
        StartCoroutine(LoadAsyncronously(sceneIndex));
    }

    IEnumerator LoadAsyncronously(int sceneIndex)
    {
        

        AsyncOperation operation =  SceneManager.LoadSceneAsync(sceneIndex);

        loadingScrn.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            progressTxt.text = progress * 100f + "%";

            yield return null;
        }
    }

    public void EnableShopScrn()
    {
        LoadLevel(0);
        StartCoroutine(EnableShop());
    }

    IEnumerator EnableShop()
    {
        yield return new WaitForSeconds(2f);
     //   MenuManager.instance.shopScrn.SetActive(true);
    }

}
