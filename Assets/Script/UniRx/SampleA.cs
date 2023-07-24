using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SampleA : MonoBehaviour
{

    private int _value = 0;


    public event Action<int> ChangedValue = delegate { };



    // Start is called before the first frame update
    void Start()
    {
        SetValue(20);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetValue(int value)
    {
        if (_value == value)
        {
            return;
        }

        _value += value;
        ChangedValue(_value);
    }
}
