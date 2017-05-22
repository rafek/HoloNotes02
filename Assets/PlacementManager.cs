using System;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class PlacementManager : MonoBehaviour, IInputClickHandler {

    [Tooltip("Prefab for notes objects.")]
    public GameObject NotePrefab;

    private int _spatialMappingLayerID;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (GazeManager.Instance.IsGazingAtObject)
        {
            if (GazeManager.Instance.HitObject.layer == _spatialMappingLayerID)
            {
                var newNotePosition = GazeManager.Instance.HitInfo.point;

                var newNote = Instantiate(NotePrefab, newNotePosition, Quaternion.identity);
            }
        }
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
