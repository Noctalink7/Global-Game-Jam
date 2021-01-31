using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOn : MonoBehaviour
{
    public Inventory inventory;
    public GameOver gameOver;
    private int tmp = 0;
    public Text text;
    public GameObject WhiteFade;
    public string sceneToLoad;
    private bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        inventory.nbDolls = 0;
        gameOver.IsOver = false;
        text.text = "0/7 Dolls Found";
    }

    // Update is called once per frame
    void Update()
    {
        if (tmp != inventory.nbDolls)
        {
            text.text = inventory.nbDolls + "/7 Dolls Found";
            tmp = inventory.nbDolls;
        }
        if (inventory.nbDolls == 7 && stop == false)
        {
            gameOver.IsOver = true;
            stop = true;
        }
        if (gameOver.IsOver == true)
        {
            Debug.Log("End");
            StartCoroutine(FadeCo());
        }
    }

    public IEnumerator FadeCo()
    {
        gameOver.IsOver = false;
        if (WhiteFade != null)
        {
            Instantiate(WhiteFade, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
