using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public VectorValue cameraMin;
    public VectorValue cameraMax;
    public Vector2 cameraNewMax;
    public Vector2 cameraNewMin;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStorage.initValue = playerPosition;
            //ResetCameraBounds();
            SceneManager.LoadScene(sceneToLoad);
            
        }
    }

    public void ResetCameraBounds()
    {
        cameraMax.initValue = cameraNewMax;
        cameraMin.initValue = cameraNewMin;
    }
}
