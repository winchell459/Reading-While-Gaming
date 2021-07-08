using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public ControlsButton up, down, right, left, UpRight, UpLeft, DownRight, DownLeft;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(up.down)
        {
            horizontal = 0;
            vertical = 1;
        }

        if(down.down)
        {
            horizontal = 0;
            vertical = -1;
        }

        if (right.down)
        {
            horizontal = 1;
            vertical = 0;
        }

        if (left.down)
        {
            horizontal = -1;
            vertical = 0;
        }

        if (UpRight.down)
        {
            horizontal = 1;
            vertical = 1;
        }

        if (UpLeft.down)
        {
            horizontal = -1;
            vertical = 1;
        }

        if (DownRight.down)
        {
            horizontal = 1;
            vertical = -1;
        }

        if (DownLeft.down)
        {
            horizontal = -1;
            vertical = -1;
        }
    }
}