using UnityEngine;

public class destroyer : MonoBehaviour
{
    public GameObject test1;
    public string HitObjectName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CastRay();
        }
    }
    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        // cardselector
        if (hit.collider != null)
        {
            HitObjectName = hit.collider.gameObject.name;
            if (HitObjectName == gameObject.name)
            {
                test1 = GameObject.Find(HitObjectName);
                Destroy(test1);
            }


        }
    }
}
