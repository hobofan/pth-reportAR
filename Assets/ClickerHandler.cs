using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ClickerHandler : MonoBehaviour, IInputClickHandler, IInputHandler
{
    public HoloToolkit.Unity.InputModule.Cursor cursor;

    private void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(!eventData.used)
        {
            eventData.Use();
            Debug.Log("Clicked");
            AnchorHandler.Instance.addAnchor(cursor.Position);
        }
    }
    public void OnInputDown(InputEventData eventData)
    {

    }
    public void OnInputUp(InputEventData eventData)

    {
    }
}
