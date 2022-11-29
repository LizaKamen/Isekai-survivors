using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MesMan : MonoBehaviour
{
    [SerializeField] Image image;
    public void Close()
    {
        image.gameObject.SetActive(false);
    }
}
