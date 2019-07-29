using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSelectedScript : MonoBehaviour
{
    Dropdown roundAmountSelector;
    public int roundsSelected;
    void Start()
    {
        roundAmountSelector = GetComponent<Dropdown>();

        roundAmountSelector.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(roundAmountSelector);
        });
    }

    // Update is called once per frame

    void DropdownValueChanged(Dropdown mapSelector)
    {
        roundsSelected = roundAmountSelector.value;
    }
    void Update()
    {
        print(roundsSelected);
    }
}
