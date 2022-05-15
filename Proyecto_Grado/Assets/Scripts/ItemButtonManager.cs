using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonManager : MonoBehaviour
{
    public string ItemName { get; set; }
    public string ItemDescription { get; set; }
    public Sprite ItemImage { get; set; }
    public GameObject Item3DModel { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text = ItemName;
        transform.GetChild(1).GetComponent<RawImage>().texture = ItemImage.texture;
        transform.GetChild(2).GetComponent<Text>().text = ItemDescription;

        var button = GetComponent<Button>();
        button.onClick.AddListener(GameManager.instance.ARPosition);
        button.onClick.AddListener(Create3DModel);
    }

    private void Create3DModel()
    {
        Instantiate(Item3DModel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
