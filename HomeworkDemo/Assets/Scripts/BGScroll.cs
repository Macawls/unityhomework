using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField] private float scrollingSpeed = 1.0f;
    private float _offset;
    private Material _material;
        
    // Start is called before the first frame update

    private void Awake()
    {
        _material = gameObject.GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // scrolls the texture 
        _offset += (Time.deltaTime * scrollingSpeed) / 10f;
        _material.SetTextureOffset("_MainTex", new Vector2(_offset, 0));
    }
}
