using UnityEngine;

public class teszt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("attack");
        //if(other.gameObject.CompareTag("Player"))
        //{
        //if (attackable == true)
        //{
        //StartCoroutine(attack());
        //}
        //}

    }

}
