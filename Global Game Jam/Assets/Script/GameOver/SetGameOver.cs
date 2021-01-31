using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGameOver : MonoBehaviour
{
    public Inventory inventory;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        if (inventory.nbDolls == 7)
        {
            text.text = "Congratulation You Collected All The Dolls.\nThe Spirits are now free...";
        }
        else
        {
            text.text = "YOU DIED !";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
