using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsButton : MonoBehaviour
{
    public bool down;
    public Color DownColor, UpColor;
    public SpriteRenderer Sprite;

    void Update()
    {
        if (down) Sprite.color = DownColor;
        else Sprite.color = UpColor;
    }

    private void OnMouseDown()
    {
        down = true;
    }

    private void OnMouseOver()
    {
        down = true;
    }

    private void OnMouseUp()
    {
        down = false;
    }

    private void OnMouseExit()
    {
        down = false;
    }
}