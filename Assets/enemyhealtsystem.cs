using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class enemyhealtsystem : MonoBehaviour
{
    public Sprite leftDamaged;
    public Sprite rightDamaged;
    public Sprite main;
    public SpriteRenderer SpriteRenderer;
    public Collider2D rightCollider;
    public Collider2D leftCollider;
    public Collider2D mainCollider;
    public float allhealth;
    public float lefthealth;
    public float righthealth;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void determinecooliderhit(Collider2D collider, float damage)
    {
        if (collider == rightCollider)
        {
            righthealth -= damage;
            allhealth -= damage;
            if (righthealth <= 0)
            {
                rightCollider.enabled = false;
                if (leftCollider.enabled == true)
                {
                    SpriteRenderer.sprite = leftDamaged;

                }
                else
                {
                    SpriteRenderer.sprite = main;
                }
                Debug.Log("right collider disabled");
            }
        }
        if (collider == leftCollider)
        {
            lefthealth -= damage;
            allhealth -= damage;
            if (lefthealth <= 0)
            {
                leftCollider.enabled = false;
                if(rightCollider.enabled == true)
                {
                    SpriteRenderer.sprite = leftDamaged;

                }
                else
                {
                    SpriteRenderer.sprite = main;
                }
                Debug.Log("left collider disabled");

            }
        }
        if (collider == mainCollider)
        {
            allhealth -= damage;
            Debug.Log("main collider hit");
        }
        if (allhealth <= 0)
        {
            Destroy(parent);
        }
    }
}
