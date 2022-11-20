using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int currency = 0;
    public AudioSource collectableAudioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Collectable") {

            GameObject collectable = collision.gameObject;

            int cValue = collectable.GetComponent<ItemValue>().itemValue;
            
            collectableAudioPlayer.clip = collectable.GetComponent<ItemAudio>().collectableAudio;
            collectableAudioPlayer.Play();

            Destroy(collectable);

            currency += cValue;

            Debug.Log("Collided with: " + collision.collider.name + "\nAdded " + cValue + " to Currency\nPlayer now has " + currency + " coins in their inventory.");
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {

        if (collision.collider.tag == "Collectable") {
            
            Debug.Log("Collision ended with: " + collision.collider.name);     
        }  
    }
}
