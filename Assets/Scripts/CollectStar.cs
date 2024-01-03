using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectStar : MonoBehaviour
{
    public bool isWhite;

    private int blackLayer = 6;
    private int whiteLayer = 7;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.layer == whiteLayer && isWhite)
            {
                Destroy(gameObject);
            }
            else if (collision.gameObject.layer == blackLayer && !isWhite)
            {
                Destroy(gameObject);
            }
        }
    }
}
