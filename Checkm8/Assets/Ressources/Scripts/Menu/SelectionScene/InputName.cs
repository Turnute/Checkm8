using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    [SerializeField] private InputField firstPlayer;

    void Start()
    {
        if(GetComponent<InputField>() == firstPlayer)
        {
            GetComponent<InputField>().text = "Player1";
        }
        else
        {
            GetComponent<InputField>().text = "Player2";
        }
    }
}
