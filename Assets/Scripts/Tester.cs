using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    private void Update()
    {
        var screenpos = Camera.main.ScreenToWorldPoint(transform.position);
        print(screenpos);
    }
}
