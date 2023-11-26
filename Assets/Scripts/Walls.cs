using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{

    public float centerx, centery, left, top, right, bottom;
    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        /* centerx = transform.position.x + boxCollider.bounds.extents.x;
        centery = transform.position.y - boxCollider.bounds.extents.y;  
        left = transform.position.x;
        top = transform.position.y;
        right = transform.position.x + boxCollider.bounds.size.x;
        bottom = transform.position.y - boxCollider.bounds.size.y;
    */

        centerx = transform.position.x;
        centery = transform.position.y;
        left = transform.position.x - boxCollider.bounds.extents.x;
        top = transform.position.y + boxCollider.bounds.extents.y;
        right = transform.position.x + boxCollider.bounds.extents.x;
        bottom = transform.position.y - boxCollider.bounds.extents.y;
    }
}
