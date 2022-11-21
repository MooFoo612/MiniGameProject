using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public static int currency = 0;//
    public static int pHealth;
    public AudioSource collectableAudioPlayer;
    public GameObject player;
    private int playerHealth;

    [SerializeField]
    private int playerMaxHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = PlayerController.health;
        playerMaxHealth = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag.Equals("Potions")) {

            if (maxHealth(playerHealth, playerMaxHealth) == true) {

                GameObject lifePot = other.gameObject;

                int pHealth = lifePot.GetComponent<ItemValue>().itemValue;

                PlayerController.health += pHealth;

                collectableAudioPlayer.clip = lifePot.GetComponent<ItemAudio>().collectableAudio;
                collectableAudioPlayer.Play();

                Destroy(lifePot);

                Debug.Log("Collided with: " + other.name + "\nAdded " + pHealth + " to Health\nPlayer now has " + PlayerController.health + " health.");

            } else {

                PlayerController.health = 20;

                Debug.Log("Max Health Reached! Couldn't add health!\nPlayer now has " + PlayerController.health + " health.");

            }


        
        } else if (other.tag.Equals("Coins")) {

                GameObject collectable = other.gameObject;

                int cValue = collectable.GetComponent<ItemValue>().itemValue;

                collectableAudioPlayer.clip = collectable.GetComponent<ItemAudio>().collectableAudio;
                collectableAudioPlayer.Play();

                Destroy(collectable);

                currency += cValue;

                Debug.Log("Collided with: " + other.name + "\nAdded " + cValue + " to Currency\nPlayer now has " + currency + " coins in their inventory.");
            
        } else if (other.tag.Equals("LevelSwitch")) {

            if (currency >= 100) {

                Scene currentScene = SceneManager.GetActiveScene();

                if (currentScene.name.Equals("1_Level_One_Village")) {

                    LoadAScene(2);

                } else if (currentScene.name.Equals("2_Level_Two_Dojo")) {

                    LoadAScene(1);

                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {

        if (collision.collider.tag == "Collectable") {
            
            Debug.Log("Collision ended with: " + collision.collider.name);     
        }  
    }

    private void LoadAScene(int sceneNumber)
    {
        Debug.Log("sceneName to load: " + sceneNumber);
        SceneManager.LoadScene(sceneNumber);
    }

    private bool maxHealth(int playerHealth, int playerMaxHealth) {

        if (playerHealth <= playerMaxHealth) {
            return true;
        } else {
            return false;
        }
    }
}
