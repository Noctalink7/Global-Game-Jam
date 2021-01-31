using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Globalization;
using UnityEngine.UI;

public class TakeDoll : MonoBehaviour
{
    public GameObject diagBox;
    public PlayerMovement player;
    public Text diagText;
    public string dialog;
    public bool inRange;
    public Inventory inventory;
    public GameObject doll;
    public GameObject Ghost;
    public Vector3 vector3;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inRange)
        {
            if (diagBox.activeInHierarchy)
            {
                diagBox.SetActive(false);
                player.currentState = PlayerState.idle;
                Instantiate(Ghost, vector3, Quaternion.identity);
                Destroy(this.gameObject);
                Destroy(doll.gameObject);
            }
            else
            {
                diagBox.SetActive(true);
                diagText.text = dialog;
                inventory.nbDolls += 1;
                player.currentState = PlayerState.interact;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            inRange = false;
            diagBox.SetActive(false);
        }
    }
}
