using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public SpriteRenderer doorSR;
    public Sprite doorOpen;
    public Sprite doorClosed;
    public GameObject player;
    public GameObject door;
    public Collider2D colDoor;
    //public PlayerInventory inventory;
    static int playerCurrency;
    


    void Start() {
        doorSR.sprite = doorClosed;
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log("Scene: " + currentScene.name);
    }

    private void FixedUpdate() 
    {
        if (playerCurrency >= 10) {
            Open();
        }
    }


    public void Open() {
        door.SetActive(false);
        doorSR.sprite = doorOpen;
        Debug.Log("Successfully opened Door");
    }

    public void Close() {
        door.SetActive(true);
    }
}
