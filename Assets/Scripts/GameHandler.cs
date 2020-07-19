using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    //

    public void PngButtonControl()
    {
        if (GameObject.FindGameObjectWithTag("png"))
        {
            //
            ScreenshotHandler.TakeScreenshot_Static_Png(390, 703);
        }
    }

    public void JpgButtonControl()
    {
        if (GameObject.FindGameObjectWithTag("jpg"))
        {
            //SeceneklerPnl.SetActive(false);
            ScreenshotHandler.TakeScreenshot_Static_Jpg(390, 703);
        }
    }
}
