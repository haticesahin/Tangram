using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeceneklerController : MonoBehaviour
{
    public GameObject SeceneklerPnl;

    private void Start()
    {
        SeceneklerPnl.SetActive(false);
    }

    public void OpenPanel()
    {
        if (GameObject.FindGameObjectWithTag("Button"))
        {
            if (SeceneklerPnl != null)
            {
                bool isActive = SeceneklerPnl.activeSelf;
                SeceneklerPnl.SetActive(!isActive);
            }
        }
    }

    public void OnIzleme()
    {
        SceneManager.LoadScene("ARScene");
    }

}
