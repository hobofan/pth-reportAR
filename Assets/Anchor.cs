using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour {
    public string Label = "";
    public string firstRecorded = "Today";
    public bool acknowledged = false;

    public TextMesh labelDisplay;
    public TextMesh recordedAt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = Label;
        recordedAt.text = firstRecorded;

        UpdateLabelRecording();
    }

    void UpdateLabelRecording()
    {
        Listener listener = gameObject.GetComponent<Listener>();
        if (listener != null)
        {
            if (listener.listening || listener.finished)
            {
                Label = listener.result;
                if (listener.finished)
                {
                    Debug.Log("Resetting");
                    listener.Reset();
                }
            }
        }
    }

    public void RecordLabel()
    {
        Debug.Log("Start rec");
        Listener listener = gameObject.GetComponent<Listener>();
        if (listener != null)
        {
            listener.listening = true;
        }
        DictationInputManager.StartRecording(autoSilenceTimeout: 5f, recordingTime: 10);
    }
}
