using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ClickerHandlerApprove : MonoBehaviour, IInputClickHandler, IInputHandler
{
    // public HoloToolkit.Unity.InputModule.Cursor cursor;
    public Anchor target;
    public Material activeMaterial;

    private Material baseMaterial;
    

    private void Start()
    {
        // Renderer renderer = GetComponent<Renderer>();

        InputManager.Instance.PushFallbackInputHandler(gameObject);

        baseMaterial = transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (target.acknowledged)
        {
            transform.GetChild(0).gameObject.GetComponent<Renderer>().material = activeMaterial;
        }
        else
        {
            transform.GetChild(0).gameObject.GetComponent<Renderer>().material = baseMaterial;
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(!eventData.used)
        {
            eventData.Use();
            Debug.Log("Clicked Approve");
            target.acknowledged = true;
            // AnchorHandler.Instance.addAnchor(cursor.Position);
        }
    }
    public void OnInputDown(InputEventData eventData)
    {

    }
    public void OnInputUp(InputEventData eventData)

    {
    }
}
