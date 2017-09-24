using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class SelectableObject : MonoBehaviour, IInputClickHandler
{
    public bool selected = false;
    public Material selectionMaterial;

    // Use this for initialization
    private void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (!eventData.used)
        {
            eventData.Use();
            Debug.Log("Clicked Instance");
            foreach (SelectableObject others in GameObject.FindObjectsOfType<SelectableObject>())
            {
                others.selected = false;
            }
            selected = true;

            Anchor anchor = gameObject.GetComponent<Anchor>();
            if (anchor != null)
            {
                anchor.RecordLabel();
            }
        }
    }

    public Material GetSelectionMaterial()
    {
        if(selected)
        {
            return selectionMaterial;
        } else
        {
            return null;
        }
    }
}
