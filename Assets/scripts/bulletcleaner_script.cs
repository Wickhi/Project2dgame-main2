using UnityEngine;

public class bulletcleaner_script : MonoBehaviour

{
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Destroy(gameObject);
        }

    }
}
