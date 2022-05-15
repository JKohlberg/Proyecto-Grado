using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARInteractionManager : MonoBehaviour
{
    [SerializeField] private Camera ARCamera;
    private ARRaycastManager ARRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject ARPointer;
    private bool InitialPostition;
    private bool OverUI;
    public GameObject Item3DModel
    {
        get
        {
            return Item3DModel;
        }
        set
        {
            Item3DModel = value;
            Item3DModel.transform.position = ARPointer.transform.position;
            Item3DModel.transform.parent = ARPointer.transform;
            InitialPostition = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ARPointer = transform.GetChild(0).gameObject;
        ARRaycastManager = FindObjectOfType<ARRaycastManager>();
        GameManager.instance.OnMainMenu += SetItemPosition;
    }

    private void SetItemPosition()
    {
        if (Item3DModel != null)
        {
            Item3DModel.transform.parent = null;
            ARPointer.SetActive(false);
            Item3DModel = null;
        }
    }

    public void DeleteItem()
    {
        Destroy(Item3DModel);
        ARPointer.SetActive(false);
        GameManager.instance.MainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (InitialPostition)
        {
            Vector2 middlePointScreen = new Vector2(Screen.width / 2, Screen.height / 2);
            ARRaycastManager.Raycast(middlePointScreen, hits, TrackableType.Planes);
            if (hits.Count > 0)
            {
                transform.position = hits[0].pose.position;
                transform.rotation = hits[0].pose.rotation;
                ARPointer.SetActive(true);
                InitialPostition = false;
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touchOne = Input.GetTouch(0);
            if (touchOne.phase == TouchPhase.Began)
            {
                var touchPosition = touchOne.position;
                OverUI = isTapOverUI(touchPosition);
            }

            if (touchOne.phase == TouchPhase.Moved)
            {
                if (ARRaycastManager .Raycast(touchOne.position, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;
                    if (!OverUI)
                    {
                        transform.position = hitPose.position;
                    }
                }
            }
        }
    }

    private bool isTapOverUI(Vector2 touchPosition)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touchPosition.x, touchPosition.y);

        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, result);

        return result.Count > 0;
    }
}
