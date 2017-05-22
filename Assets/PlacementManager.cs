using System;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class PlacementManager : MonoBehaviour, IInputClickHandler {

    [Tooltip("Prefab for notes objects.")]
    public GameObject NotePrefab;

    public GameObject NoteInputCanvas;

    private int _spatialMappingLayerID;
    private GameObject _newNote;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (GazeManager.Instance.IsGazingAtObject)
        {
            if (GazeManager.Instance.HitObject.layer == _spatialMappingLayerID)
            {
                var newNotePosition = GazeManager.Instance.HitInfo.point;

                _newNote = Instantiate(NotePrefab, newNotePosition, Quaternion.identity);

                NoteInputCanvas.SetActive(true);
            }
        }
    }

    public void OnConfirmPlacement()
    {
        
    }

    public void OnCancelPlacement()
    {
        Destroy(_newNote);

        _newNote = null;

        NoteInputCanvas.SetActive(false);
    }

    private void Awake()
    {
        _spatialMappingLayerID = LayerMask.NameToLayer("SpatialMapping");
    }

    private void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }


}
