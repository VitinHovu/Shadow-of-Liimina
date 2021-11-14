using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovemet cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovemet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check the tag of other
        if (other.CompareTag("Player"))
        {
            cam.minPoistion += cameraChange;
            cam.maxPoisiton += cameraChange;
            other.transform.position += playerChange;
        }
    }
}
