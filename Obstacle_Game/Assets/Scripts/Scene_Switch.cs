using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Name: Janice Xiong
 * 4/18/22
 * Switching Scene
 * 
 */

public class Scene_Switch : MonoBehaviour
{
    //inializing
    public GameObject player;
    public GameObject mainCamera;
    public GameObject Canvas;

    public static Scene_Switch instance;


    // Start is called before the first frame update
    void Start()
    {
        // keep the player, camera, this script, and the canvas
        instance = this;
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(mainCamera);
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(Canvas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchScene(int sceneNumber)
    {
        // load the scene according to the number on the build settings
        SceneManager.LoadScene(sceneNumber);
    }
}
