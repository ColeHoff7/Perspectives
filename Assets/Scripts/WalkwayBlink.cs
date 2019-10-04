using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkwayBlink : MonoBehaviour {

    public bool levelComplete;
    private Material mat;
    private Color blinkColor = Color.red;
	

    void Update()
    {
        if (!levelComplete)
        {
            Renderer renderer = GetComponent<Renderer>();
            Material mat = renderer.material;

            float floor = 0.0f;
            float ceiling = 1.0f;
            float emission = floor + Mathf.PingPong(Time.time * .75f, ceiling - floor);
            Color baseColor = blinkColor; //Replace this with whatever you want for your base color at emission level '1'

            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

            mat.SetColor("_EmissionColor", finalColor);
        }
    }

}
