using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject character;
    public float cameraWidth;

    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = GetComponent<Camera>();
        float cameraHeight = mainCamera.orthographicSize * 2;
        cameraWidth = cameraHeight * mainCamera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(character.transform.position.x + cameraWidth/2.8f, 0, -10);
    }
}
