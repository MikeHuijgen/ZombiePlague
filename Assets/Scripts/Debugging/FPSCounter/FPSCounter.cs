using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FPSCounter : MonoBehaviour
{
    private float _fps;
    [SerializeField] private TextMeshProUGUI fpsCounterText;
        
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(GetFps), 1, 1);
    }
    

    private void GetFps()
    {
        _fps = (int)(1f / Time.unscaledDeltaTime);
        fpsCounterText.text = $"FPS: {_fps}";
    }
}
