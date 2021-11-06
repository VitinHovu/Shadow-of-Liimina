using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovemet : MonoBehaviour
{

    public Transform target;
    public float smoothing;
    public Vector2 maxPoisiton;
    public Vector2 minPoistion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if(transform.position != target.position)
        {
            //move towards the target
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPoistion.x, maxPoisiton.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPoistion.y, maxPoisiton.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
