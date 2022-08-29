using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class destructable : MonoBehaviour
{
    public Tilemap destructabletilemap;
    // Start is called before the first frame update
    void Start()
    {
        destructabletilemap = GetComponent<Tilemap>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Vector3 hitposition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitposition.x = hit.point.x - 0.001f * hit.normal.x;
                hitposition.y = hit.point.y - 0.001f * hit.normal.y;
                destructabletilemap.SetTile(destructabletilemap.WorldToCell(hitposition), null);
            }
        }
        else if(collision.gameObject.CompareTag("enemybullet"))
        {
            Vector3 hitposition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitposition.x = hit.point.x - 0.001f * hit.normal.x;
                hitposition.y = hit.point.y - 0.001f * hit.normal.y;
                destructabletilemap.SetTile(destructabletilemap.WorldToCell(hitposition), null);
            }
        }
    }
   
}