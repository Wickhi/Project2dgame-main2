using UnityEngine;

public class buuletra : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 start;
    public Vector3 end;
    public float progress;
    public float speed;
    void Start()
    {
        start = new Vector3(transform.position.x, transform.position.y, 10);
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(start, end, progress);

    }
    public void settargerpos(Vector3 targepos)
    {
        end = targepos;
    }
}
