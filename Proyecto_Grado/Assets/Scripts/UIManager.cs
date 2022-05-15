using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject Main_Menu_Canvas;
    [SerializeField] private GameObject Items_Menu_Canvas;
    [SerializeField] private GameObject AR_Position_Canvas;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.OnMainMenu += ActivateMainMenu;
        GameManager.instance.OnItemsMenu += ActivateItemsMenu;
        GameManager.instance.OnARPosition += ActivateARPosition;
    }
    private void ActivateMainMenu()
    {
        Main_Menu_Canvas.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.0f);

        Items_Menu_Canvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Items_Menu_Canvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Items_Menu_Canvas.transform.GetChild(1).transform.DOMoveY(180, 0.3f);

        AR_Position_Canvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        AR_Position_Canvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
    }
    private void ActivateItemsMenu()
    {
        Main_Menu_Canvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);

        Items_Menu_Canvas.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.0f);
        Items_Menu_Canvas.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        Items_Menu_Canvas.transform.GetChild(1).transform.DOMoveY(300, 0.3f);
    }

    private void ActivateARPosition()
    {
        Main_Menu_Canvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);

        Items_Menu_Canvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        Items_Menu_Canvas.transform.GetChild(1).transform.DOMoveY(180, 0.3f);

        AR_Position_Canvas.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        AR_Position_Canvas.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
    }

}