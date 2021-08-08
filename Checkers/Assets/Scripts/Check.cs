using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    [HideInInspector] public static bool stepHolderWhite = true;
    [HideInInspector] public static bool onClicked = false;
    [HideInInspector] public bool _onClicked;
    [SerializeField] private GameObject step;
    [SerializeField] public Sprite check_black, check_white;
    private LayerMask stepLayer;
    private LayerMask whiteCheckLayer;
    private LayerMask blackCheckLayer;

    public void Move(Vector3 new_pos)
    {
        transform.Translate(new_pos - transform.position);
    }

    protected void Awake()
    {
         stepLayer = LayerMask.GetMask("Step");
         whiteCheckLayer = LayerMask.GetMask("WhiteCheck");
         blackCheckLayer = LayerMask.GetMask("BlackCheck");
    }

    private void OnMouseDown()
    {
        if (Check.onClicked == false)
        {
            Check.onClicked = true;
            _onClicked = !_onClicked;
        }
        else
        {
            for (int i = Spawner.checks_storage.Count, z = 0; z < i; z++)
            {
                Spawner.checks_storage[z].GetComponent<Check>()._onClicked = false;
            }
            _onClicked = !_onClicked;
        }
        
    }

    void Update()
    {
        if (_onClicked)
        {
            if (stepHolderWhite)
            {

                if (GetComponent<SpriteRenderer>().sprite == check_white)
                {
                    //обработка левой части ходов
                    RaycastHit2D hitLU_W = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0.5f, 0), new Vector2(-1, 1), 1f, whiteCheckLayer);
                    RaycastHit2D hitLU_B = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0.5f, 0), new Vector2(-1, 1), 1f, blackCheckLayer);
                    RaycastHit2D hitLD_B = Physics2D.Raycast(transform.position + new Vector3(-0.5f, -0.5f, 0), new Vector2(-1, -1), 1f, blackCheckLayer);
                    if (hitLU_W)
                    { }
                    else if (hitLU_B)
                    {
                        RaycastHit2D hitLUx2_W = Physics2D.Raycast(transform.position + new Vector3(-1.5f, 1.5f, 0), new Vector2(-1, 1), 1f, whiteCheckLayer);
                        RaycastHit2D hitLUx2_B = Physics2D.Raycast(transform.position + new Vector3(-1.5f, 1.5f, 0), new Vector2(-1, 1), 1f, blackCheckLayer);
                        if (hitLUx2_W)
                        { }
                        else if (hitLUx2_B)
                        { }
                        else
                        {
                            GameObject stepLUx2 = GameObject.Instantiate(step, transform.position + new Vector3(-2, 2, 0), Quaternion.identity);
                            step.GetComponent<Step>()._check = GetComponent<Check>();
                            step.GetComponent<Step>().preyCollider = hitLU_B.collider;
                            step.GetComponent<Step>().preySprite = hitLU_B.collider.gameObject.GetComponent<SpriteRenderer>();
                        }
                    }
                    else
                    {
                        GameObject stepLU = GameObject.Instantiate(step, transform.position + new Vector3(-1, 1, 0), Quaternion.identity);
                        step.GetComponent<Step>()._check = GetComponent<Check>();
                    }
                    if (hitLD_B)
                    {
                        RaycastHit2D hitLDx2_W = Physics2D.Raycast(transform.position + new Vector3(-1.5f, -1.5f, 0), new Vector2(-1, -1), 1f, whiteCheckLayer);
                        RaycastHit2D hitLDx2_B = Physics2D.Raycast(transform.position + new Vector3(-1.5f, -1.5f, 0), new Vector2(-1, -1), 1f, blackCheckLayer);
                        if (hitLDx2_W)
                        { }
                        else if (hitLDx2_B)
                        { }
                        else
                        {
                            GameObject stepLDx2 = GameObject.Instantiate(step, transform.position + new Vector3(-2, -2, 0), Quaternion.identity);
                            step.GetComponent<Step>()._check = GetComponent<Check>();
                        }
                    }
                    else
                    { }
                    //обработка правой части ходов
                    RaycastHit2D hitRU_W = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0.5f, 0), new Vector2(1, 1), 1f, whiteCheckLayer);
                    RaycastHit2D hitRU_B = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0.5f, 0), new Vector2(1, 1), 1f, blackCheckLayer);
                    RaycastHit2D hitRD_B = Physics2D.Raycast(transform.position + new Vector3(0.5f, -0.5f, 0), new Vector2(1, -1), 1f, blackCheckLayer);
                    if (hitRU_W)
                    { }
                    else if (hitRU_B)
                    {
                        RaycastHit2D hitRUx2_W = Physics2D.Raycast(transform.position + new Vector3(1.5f, 1.5f, 0), new Vector2(1, 1), 1f, whiteCheckLayer);
                        RaycastHit2D hitRUx2_B = Physics2D.Raycast(transform.position + new Vector3(1.5f, 1.5f, 0), new Vector2(1, 1), 1f, blackCheckLayer);
                        if (hitRUx2_W)
                        { }
                        else if (hitRUx2_B)
                        { }
                        else
                        {
                            GameObject stepRUx2 = GameObject.Instantiate(step, transform.position + new Vector3(2, 2, 0), Quaternion.identity);
                            step.GetComponent<Step>()._check = GetComponent<Check>();
                            step.GetComponent<Step>().preyCollider = hitRU_B.collider;
                            step.GetComponent<Step>().preySprite = hitRU_B.collider.gameObject.GetComponent<SpriteRenderer>();
                        }
                    }
                    else
                    {
                        GameObject stepRU = GameObject.Instantiate(step, transform.position + new Vector3(1, 1, 0), Quaternion.identity);
                        step.GetComponent<Step>()._check = GetComponent<Check>();
                    }
                    if (hitRD_B)
                    {
                        RaycastHit2D hitRDx2_W = Physics2D.Raycast(transform.position + new Vector3(1.5f, -1.5f, 0), new Vector2(1, -1), 1f, whiteCheckLayer);
                        RaycastHit2D hitRDx2_B = Physics2D.Raycast(transform.position + new Vector3(1.5f, -1.5f, 0), new Vector2(1, -1), 1f, blackCheckLayer);
                        if (hitRDx2_W)
                        { }
                        else if (hitRDx2_B)
                        { }
                        else
                        {
                            GameObject stepRDx2 = GameObject.Instantiate(step, transform.position + new Vector3(2, -2, 0), Quaternion.identity);
                            step.GetComponent<Step>()._check = GetComponent<Check>();
                        }
                    }
                    else
                    { }
                }
            }
            else
            {
                if(GetComponent<SpriteRenderer>().sprite == check_black)
                {
                    //обработка левой части ходов
                    RaycastHit2D hitLU_W = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0.5f, 0), new Vector2(-1, 1), 1f, whiteCheckLayer);
                    RaycastHit2D hitLU_B = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0.5f, 0), new Vector2(-1, 1), 1f, blackCheckLayer);
                    RaycastHit2D hitLD_W = Physics2D.Raycast(transform.position + new Vector3(-0.5f, -0.5f, 0), new Vector2(-1, -1), 1f, whiteCheckLayer);
                    RaycastHit2D hitLD_B = Physics2D.Raycast(transform.position + new Vector3(-0.5f, -0.5f, 0), new Vector2(-1, -1), 1f, blackCheckLayer);
                    if (hitLU_W)
                    {
                        RaycastHit2D hitLUx2_W = Physics2D.Raycast(transform.position + new Vector3(-1.5f, 1.5f, 0), new Vector2(-1, 1), 1f, whiteCheckLayer);
                        RaycastHit2D hitLUx2_B = Physics2D.Raycast(transform.position + new Vector3(-1.5f, 1.5f, 0), new Vector2(-1, 1), 1f, blackCheckLayer);
                        if (hitLUx2_W)
                        { }
                        else if (hitLUx2_B)
                        { }
                        else
                        {
                            GameObject stepLUx2 = GameObject.Instantiate(step, transform.position + new Vector3(-2, 2, 0), Quaternion.identity);
                            step.GetComponent<Step>()._check = GetComponent<Check>();
                            step.GetComponent<Step>().preyCollider = hitLU_W.collider;
                            step.GetComponent<Step>().preySprite = hitLU_W.collider.gameObject.GetComponent<SpriteRenderer>();
                        }
                    }
                    else if (hitLU_B)
                    { }
                    else
                    { }
                    if (hitLD_W)
                    {
                        RaycastHit2D hitLDx2_W = Physics2D.Raycast(transform.position + new Vector3(-1.5f, -1.5f, 0), new Vector2(-1, -1), 1f, whiteCheckLayer);
                        RaycastHit2D hitLDx2_B = Physics2D.Raycast(transform.position + new Vector3(-1.5f, -1.5f, 0), new Vector2(-1, -1), 1f, blackCheckLayer);
                        if (hitLDx2_W)
                        { }
                        else if (hitLDx2_B)
                        { }
                        else
                        {
                            GameObject stepLDx2 = GameObject.Instantiate(step, transform.position + new Vector3(-2, -2, 0), Quaternion.identity);
                            step.GetComponent<Step>()._check = GetComponent<Check>();
                            step.GetComponent<Step>().preyCollider = hitLD_W.collider;
                            step.GetComponent<Step>().preySprite = hitLD_W.collider.gameObject.GetComponent<SpriteRenderer>();
                        }
                    }
                    else if (hitLD_B)
                    { }
                    else
                    {
                        GameObject stepLD = GameObject.Instantiate(step, transform.position + new Vector3(-1, -1, 0), Quaternion.identity);
                        step.GetComponent<Step>()._check = GetComponent<Check>();
                    }
                    //обработка правой части ходов
                    RaycastHit2D hitRU_W = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0.5f, 0), new Vector2(1, 1), 1f, whiteCheckLayer);
                    RaycastHit2D hitRU_B = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0.5f, 0), new Vector2(1, 1), 1f, blackCheckLayer);
                    RaycastHit2D hitRD_W = Physics2D.Raycast(transform.position + new Vector3(0.5f, -0.5f, 0), new Vector2(1, -1), 1f, whiteCheckLayer);
                    RaycastHit2D hitRD_B = Physics2D.Raycast(transform.position + new Vector3(0.5f, -0.5f, 0), new Vector2(1, -1), 1f, blackCheckLayer);
                    if (hitRU_W)
                    {
                        RaycastHit2D hitRUx2_W = Physics2D.Raycast(transform.position + new Vector3(1.5f, 1.5f, 0), new Vector2(1, 1), 1f, whiteCheckLayer);
                        RaycastHit2D hitRUx2_B = Physics2D.Raycast(transform.position + new Vector3(1.5f, 1.5f, 0), new Vector2(1, 1), 1f, blackCheckLayer);
                        if (hitRUx2_W)
                        { }
                        else if (hitRUx2_B)
                        { }
                        else
                        {
                            GameObject stepRUx2 = GameObject.Instantiate(step, transform.position + new Vector3(2, 2, 0), Quaternion.identity);
                            step.GetComponent<Step>()._check = GetComponent<Check>();
                            step.GetComponent<Step>().preyCollider = hitRU_W.collider;
                            step.GetComponent<Step>().preySprite = hitRU_W.collider.gameObject.GetComponent<SpriteRenderer>();
                        }
                    }
                    else if (hitRU_B)
                    {

                    }
                    else // marker
                    { }
                    if (hitRD_B)
                    { }
                    else if (hitRD_W)
                    {
                        RaycastHit2D hitRDx2_W = Physics2D.Raycast(transform.position + new Vector3(1.5f, -1.5f, 0), new Vector2(1, -1), 1f, whiteCheckLayer);
                        RaycastHit2D hitRDx2_B = Physics2D.Raycast(transform.position + new Vector3(1.5f, -1.5f, 0), new Vector2(1, -1), 1f, blackCheckLayer);
                        if (hitRDx2_W)
                        { }
                        else if (hitRDx2_B)
                        { }
                        else
                        {
                            GameObject stepRDx2 = GameObject.Instantiate(step, transform.position + new Vector3(2, -2, 0), Quaternion.identity);
                            step.GetComponent<Step>()._check = GetComponent<Check>();
                            step.GetComponent<Step>().preyCollider = hitRD_W.collider;
                            step.GetComponent<Step>().preySprite = hitRD_W.collider.gameObject.GetComponent<SpriteRenderer>();
                        }
                    }
                    else
                    {
                        GameObject stepRD = GameObject.Instantiate(step, transform.position + new Vector3(1, -1, 0), Quaternion.identity);
                        step.GetComponent<Step>()._check = GetComponent<Check>();
                    }
                }

            } 
        }
    }
}
