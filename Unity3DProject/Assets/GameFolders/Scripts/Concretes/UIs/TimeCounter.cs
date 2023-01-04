using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    TMP_Text text;
    float currentTime;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        text.text = currentTime.ToString("0");
    }
}
