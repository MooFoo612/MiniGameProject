using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHealth : MonoBehaviour
{
    //declare variables
    public float charHealth;
    public float charHealthMax;
    //public float int charHealthMin;

    public GameObject lifePot;

    //initialize
    
    // Start is called before the first frame update
    void Start()
    {
        //initialize
        charHealth = 15f;
        Debug.Log("health: " + charHealth);
        charHealthMax = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {

        if (col.tag.Equals("Potions")) 
        {
            if(charHealth == charHealthMax)
            {
                Debug.Log("Max Health: " + charHealth);
            }
            else if (charHealth != charHealthMax)
            {
                 //collectableAudioPlayer.clip = lifePot.GetComponent<ItemAudio>().collectableAudio;
                //collectableAudioPlayer.Play();

                Destroy(lifePot);

                charHealth += 5f;
            }
        }
    }
}
