using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Textos_e_Traducao : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI VersionText;

    private void Start()
    {
        VersionText.text = Application.version.ToString();
    }
}
