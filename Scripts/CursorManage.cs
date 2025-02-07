using UnityEngine;

public class CursorManage : MonoBehaviour
{
    public Texture2D customCursor;

    

    public void OnMouseOver()
    {
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}