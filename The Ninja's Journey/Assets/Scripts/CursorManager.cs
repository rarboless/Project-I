using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        hotSpot = new Vector2(cursorTexture.width, cursorTexture.height);
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}
