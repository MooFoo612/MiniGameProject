using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DojoSceneController : MonoBehaviour
{

    private void LoadAScene(int sceneNumber) {
        Debug.Log("sceneName to load: " + sceneNumber);
        SceneManager.LoadScene(sceneNumber);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("Player")) {
            LoadAScene(1);
        }
    }
}
