using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    [SerializeField]
    private GameObject playerGO;
    private Vector3 camOffset = new Vector3(0, 0, -10);
    private void Start()
    {
        Time.timeScale = 1;
    }
    void LateUpdate()
    {
        if (playerGO != null)
            transform.position = playerGO.transform.position + camOffset;
    }
}
