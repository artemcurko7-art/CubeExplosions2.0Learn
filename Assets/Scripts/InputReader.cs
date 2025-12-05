using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action PressedButton;

    private int _numberButton = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_numberButton))
            PressedButton?.Invoke();
    }
}
