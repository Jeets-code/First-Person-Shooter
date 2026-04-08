using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{

    private int nextSceneToLoad; // Stores the value of the next scene to load


    // Start is called before the first frame update
    void Start()
    {
        // Set the value of the next scene to load 
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        // If the scene doesn't exist set the next scene to load to the main menu
        if (nextSceneToLoad > 3)
            nextSceneToLoad = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Load the next scene 
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
