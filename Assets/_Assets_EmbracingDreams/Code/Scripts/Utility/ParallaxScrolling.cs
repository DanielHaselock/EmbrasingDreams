using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public float backgroundSpeed = 0.1f;  // Adjust this to control the scrolling speed.
    public bool isHorizontal = true;     // Set to true for horizontal scrolling, false for vertical scrolling.
    public bool loopBackground = true;    // Set to true to create a seamless loop.

    private Material backgroundMaterial;
    private Vector2 materialOffset;
    private float initialOffset;
    private float textureSize;

    private void Start()
    {
        // Get the material of the Quad.
        backgroundMaterial = GetComponent<Renderer>().material;

        // Store the initial material offset.
        initialOffset = isHorizontal ? backgroundMaterial.mainTextureOffset.x : backgroundMaterial.mainTextureOffset.y;

        // Calculate the size of the texture.
        textureSize = isHorizontal ? backgroundMaterial.mainTexture.width : backgroundMaterial.mainTexture.height;

        // Adjust the initial material offset for non-looping backgrounds.
        if (!loopBackground)
        {
            initialOffset = isHorizontal ? initialOffset * transform.localScale.x : initialOffset * transform.localScale.y;
        }

        materialOffset = new Vector2(initialOffset, initialOffset);
    }

    private void Update()
    {
        // Calculate the new material offset based on camera movement.
        float offsetChange = backgroundSpeed * Time.deltaTime;

        if (isHorizontal)
        {
            materialOffset.x += offsetChange;
        }
        else
        {
            materialOffset.y += offsetChange;
        }

        // Apply the new material offset to the background material.
        backgroundMaterial.mainTextureOffset = materialOffset;

        // If looping is enabled, reset the offset when it exceeds the texture size.
        if (loopBackground)
        {
            if (Mathf.Abs(materialOffset.x - initialOffset) >= textureSize)
            {
                materialOffset.x = initialOffset;
            }

            if (Mathf.Abs(materialOffset.y - initialOffset) >= textureSize)
            {
                materialOffset.y = initialOffset;
            }
        }
    }
}
