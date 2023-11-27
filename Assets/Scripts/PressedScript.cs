using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressedButton()
    {
        Debug.Log($"You pressed {gameObject.name}!");
    }
}
