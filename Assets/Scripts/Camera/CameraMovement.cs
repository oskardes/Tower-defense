using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float panSpeed = 30f;
    private float scrollSpeed = 5f;
    private float minYScroll = 10f;
    private float maxYScroll = 80f;

    void Update()
    { 
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.right * panSpeed * Time.deltaTime, Space.World);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 posi = transform.position;
        
        posi.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        posi.y = Mathf.Clamp(posi.y, minYScroll, maxYScroll);   
        transform.position = posi;
    }
}
