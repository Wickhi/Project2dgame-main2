using UnityEngine;
[ExecuteInEditMode]
public class Uilinerende : MonoBehaviour
{
    //https://forum.unity.com/threads/linerenderer-gradient-not-working-properly.545289/
    public LineRenderer line;
    public GameObject startButton;
    public GameObject endButton;
    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.SetPosition(0, gameObject.transform.position);
        line.SetPosition(1, startButton.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, endButton.transform.position);
        line.SetPosition(1, startButton.transform.position);
    }
}
