using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    private static ScreenshotHandler instance;

    private Camera myCamera;
    private bool takeScreenshotOnNextFrame1, takeScreenshotOnNextFrame2;

    public GameObject pngBtn, jpgBtn;

    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
    }

    private void OnPostRender()
    {
        if (GameObject.FindGameObjectWithTag("png"))
        {
            if (takeScreenshotOnNextFrame1)
            {
                takeScreenshotOnNextFrame1 = false;
                RenderTexture renderTexture = myCamera.targetTexture;

                Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
                Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
                renderResult.ReadPixels(rect, 0, 0);

                byte[] byteArray = renderResult.EncodeToPNG();
                System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenshotPNG.png", byteArray);
                Debug.Log("png ss alındı");

                RenderTexture.ReleaseTemporary(renderTexture);
                myCamera.targetTexture = null;
            }
        }
        if (GameObject.FindGameObjectWithTag("jpg"))
        {
            if (takeScreenshotOnNextFrame2)
            {
                takeScreenshotOnNextFrame2 = false;
                RenderTexture renderTexture = myCamera.targetTexture;

                Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
                Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
                renderResult.ReadPixels(rect, 0, 0);

                byte[] byteArray = renderResult.EncodeToJPG();
                System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenshotJPG.jpg", byteArray);
                Debug.Log("jpg ss alındı");

                RenderTexture.ReleaseTemporary(renderTexture);
                myCamera.targetTexture = null;
            }
        }
    }

    private void TakeScreenshotPng(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshotOnNextFrame1 = true;
    }    

    private void TakeScreenshotJpg(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshotOnNextFrame2 = true;
    }

    public static void TakeScreenshot_Static_Png(int width, int height)
    {
        instance.TakeScreenshotPng(width, height);
    }

    public static void TakeScreenshot_Static_Jpg(int width, int height)
    {
        instance.TakeScreenshotJpg(width, height);
    }
}
