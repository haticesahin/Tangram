using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public GameObject ucgen1;
    Touch initTouch;
    bool swiped = false;
    bool boardTouch = false;

    void Update()
    {
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
            {
                initTouch = t;
            }
            else if (t.phase == TouchPhase.Moved && !swiped && GameObject.FindGameObjectWithTag("obje"))
            {
                float xMoved = initTouch.position.x - t.position.x;
                float yMoved = initTouch.position.y - t.position.y;
                float distance = Mathf.Sqrt((xMoved * xMoved) + (yMoved * yMoved));
                bool swipedLeft = Mathf.Abs(xMoved) > Mathf.Abs(yMoved);

                if (distance > 50f)
                {
                    if (swipedLeft && xMoved > 0 && boardTouch == false)
                    {
                        ucgen1.transform.Translate(-3, 0, 0);
                    }
                    else if (swipedLeft && xMoved < 0 && boardTouch == false)
                    {
                        ucgen1.transform.Translate(3, 0, 0);
                    }
                    else if (swipedLeft == false && yMoved > 0 && boardTouch == false)
                    {
                        ucgen1.transform.Translate(0, 0, 3);
                    }
                    else if (swipedLeft == false && yMoved < 0 && boardTouch == false)
                    {
                        ucgen1.transform.Translate(0, 0, -3);
                    }
                    swiped = true;
                }
            }
            else if (t.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
                swiped = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Duvar")
        {
            ucgen1.transform.Translate(-3, 0, 0);
        }
        else if( other.gameObject.tag == "Duvar2")
        {
            ucgen1.transform.Translate(+3, 0, 0);
        }
        else if( other.gameObject.tag == "Duvar3")
        {
            ucgen1.transform.Translate(0, 0, 3);
        }
        else if(other.gameObject.tag == "Duvar4")
        {
            ucgen1.transform.Translate(0, 0, -3);
        }
    }
}
