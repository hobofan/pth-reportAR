using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Listener : MonoBehaviour, IDictationHandler {
    public bool listening = false;
    public bool finished = false;
    public AudioClip resultClip = null;
    public string result = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDictationHypothesis(DictationEventData eventData)
    {
        if (!listening)
        {
            return;
        }
        result = eventData.DictationResult;
        resultClip = eventData.DictationAudioClip;
    }
    public void OnDictationResult(DictationEventData eventData)
    {
        if (!listening)
        {
            return;
        }
        result = eventData.DictationResult;
        resultClip = eventData.DictationAudioClip;
    }
    public void OnDictationComplete(DictationEventData eventData)
    {
        if (!listening)
        {
            return;
        }
        result = eventData.DictationResult;
        resultClip = eventData.DictationAudioClip;

        listening = false;
        finished = true;
    }
    public void OnDictationError(DictationEventData eventData)
    {
        if (!listening)
        {
            return;
        }
        listening = false;
        finished = true;
    }

    public void Reset()
    {
        listening = false;
        finished = false;
        resultClip = null;
        result = null;
    }
}
