using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    public bool startingState = false;

    private bool currentState;

    private void Awake()
    {
        currentState = startingState;
    }

    public void ToggleState()
    {
        gameObject.SetActive(!currentState);
    }
}
