using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NoteBehaviour : MonoBehaviour, IFocusable, IHoldHandler {

    [HideInInspector]
    public string NoteText;
    public Material FocusedMaterial;
    public GameObject NoteDetails;

    private Material _originalMaterial;
    private GameObject _noteDetails;

    private void Awake()
    {
        _originalMaterial = GetComponent<Renderer>().material;
    }

    public void OnFocusEnter()
    {
        GetComponent<Renderer>().material = FocusedMaterial;

        _noteDetails = Instantiate(NoteDetails, gameObject.transform.position, Quaternion.identity);

        var textMesh = _noteDetails.GetComponent<TextMesh>();

        textMesh.text = NoteText;
    }

    public void OnFocusExit()
    {
        GetComponent<Renderer>().material = _originalMaterial;
        Destroy(_noteDetails);
    }

    public void OnHoldStarted(HoldEventData eventData)
    {
        
    }

    public void OnHoldCompleted(HoldEventData eventData)
    {
        Destroy(gameObject);
    }

    public void OnHoldCanceled(HoldEventData eventData)
    {
        
    }

    private void OnDestroy()
    {
        Destroy(_noteDetails);
        Destroy(_originalMaterial);
    }
}
