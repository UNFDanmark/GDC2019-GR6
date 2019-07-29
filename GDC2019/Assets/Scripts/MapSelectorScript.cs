using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectorScript : MonoBehaviour
{
    Dropdown mapSelector;
    public int mapSelected;
    void Start()
    {
        mapSelector = GetComponent<Dropdown>();

        mapSelector.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(mapSelector);
        });
    }

    // Update is called once per frame

    void DropdownValueChanged(Dropdown mapSelector)
    {
        mapSelected = mapSelector.value;
    }
    void Update()
    {
        print(mapSelected);
    }
}
