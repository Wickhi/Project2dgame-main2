using UnityEngine;

public class buttonteszts : MonoBehaviour
{
    public GameObject n;
    // Start is called before the first frame update

    public void Dostuff()
    {
        Instantiate(n, transform.position, transform.rotation);
    }
}
