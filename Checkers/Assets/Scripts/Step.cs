using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    [HideInInspector] public Check _check;
    [HideInInspector] public Collider2D preyCollider;
    [HideInInspector] public SpriteRenderer preySprite;

    private void OnMouseDown()
    {
        _check.Move(transform.position);
        if (preySprite == null)
        {
            Check.stepHolderWhite = !Check.stepHolderWhite;
        }
        else
        {
            Destroy(preyCollider);
            Destroy(preySprite);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject);
    }
}
