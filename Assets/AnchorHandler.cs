using System;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity;
using UnityEngine;
using UnityEngine.UI;

public class AnchorHandler : Singleton<AnchorHandler> {
    public GameObject anchor;

    private List<GameObject> anchors;

    private void Start()
    {
        anchors = new List<GameObject>();
    }

    private void Update()
    {
        setIssuesListText();
    }

    public void addAnchor(Vector3 pos)
    {
        GameObject newAnchor = Instantiate(anchor, pos, Quaternion.identity);
        newAnchor.transform.position = pos;
        String anchorLabel = "Issue #" + (anchors.Count + 1);
        newAnchor.GetComponent<Anchor>().Label = anchorLabel;
        // WorldAnchorManager.Instance.RemoveAnchor(anchors.Count.ToString());
        // WorldAnchorManager.Instance.AttachAnchor(newAnchor, anchors.Count.ToString());
        anchors.Add(newAnchor);

        setIssuesListText();
    }

    private void setIssuesListText()
    {
        String list = "";
        foreach (GameObject child in anchors)
        {
            Anchor anc = child.GetComponent<Anchor>();
            if (anc.acknowledged)
            {
                list += "<color=lime>";
            }
            list += "- ";
            list += anc.Label;
            if (anc.acknowledged)
            {
                list += "</color>";
            }
            list += "\n";
        }
        GameObject.Find("IssuesList").GetComponent<Text>().text = list;
    }
}
