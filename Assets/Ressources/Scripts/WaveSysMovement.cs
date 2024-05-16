using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSys : MonoBehaviour
{
    public GameObject character;
    private float cameraWidth;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        float cameraHeight = mainCamera.orthographicSize * 2;
        cameraWidth = cameraHeight * mainCamera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(character.transform.position.x + cameraWidth + cameraWidth / 6, -7.734324f, -10);
    }
}
