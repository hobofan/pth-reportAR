using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class GazeGrow : MonoBehaviour, IFocusable {
    public bool focused = false;
    public float scaleFactor = 1.25f;
    public Material focusMaterial;

    private Vector3 baseScale;
    private Material baseMaterial;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        baseScale = transform.localScale;
        baseMaterial = renderer.material;
    }

    private void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (ShouldGrow())
        {
            transform.localScale = baseScale * scaleFactor;
        }
        else
        {
            transform.localScale = baseScale;
        }

        if (focused)
        {
            renderer.material = focusMaterial;
        }
        else
        {
            renderer.material = baseMaterial;
        }

        SelectableObject selectable = gameObject.GetComponent<SelectableObject>();
        if (selectable != null)
        {
            Material selectionMaterial = selectable.GetSelectionMaterial();
            if (selectionMaterial != null)
            {
                renderer.material = selectionMaterial;
            }
        }

        if (ShouldDisplayChildren())
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            
        }
        if (ShouldDisplayTick())
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    private bool ShouldGrow()
    {
        if (focused)
        {
            return true;
        }

        SelectableObject selectable = gameObject.GetComponent<SelectableObject>();
        if (selectable != null && selectable.selected)
        {
            return true;
        }

        return false;
    }

    private bool ShouldDisplayTick()
    {

        SelectableObject selectable = gameObject.GetComponent<SelectableObject>();
        if (selectable != null && selectable.selected)
        {
            return true;
        }

        return false;
    }

    private bool ShouldDisplayChildren()
    {
        if (focused)
        {
            return true;
        }

        SelectableObject selectable = gameObject.GetComponent<SelectableObject>();
        if (selectable != null && selectable.selected)
        {
            return true;
        }

        return false;
    }

    public void OnFocusEnter()
    {
        focused = true;
    }

    public void OnFocusExit()
    {
        focused = false;
    }
}
