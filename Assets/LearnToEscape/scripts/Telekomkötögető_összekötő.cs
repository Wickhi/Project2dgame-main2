using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Telekomkötögető_összekötő : MonoBehaviour
{
    public GameObject test1;
    public GameObject test2;
    public GameObject testtext1;
    public GameObject testtext2;
    public string HitObjectName;
    public string Lastgameobject;
    public int selectedint = 0;
    public bool selected;
    public List<GameObject> testek;
    public LineRenderer lr;
    public GameObject Camera2;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
            Lastgameobject = HitObjectName;
            HitObjectName = hit.collider.gameObject.name;
            if (HitObjectName != Lastgameobject)
            {
                if (Camera2.GetComponent<Telekomkötögető>().backgroundszar2.TryGetValue(GameObject.Find(HitObjectName), out Vector2 value) == true)
                {
                    if (value.x == 0)
                    {
                        test1 = GameObject.Find(HitObjectName);
                        testtext1 = test1.transform.GetChild(0).gameObject;

                    }
                    if (value.x == 1)
                    {
                        test2 = GameObject.Find(HitObjectName);
                        testtext2 = test2.transform.GetChild(0).gameObject;
                    }
                }
            }
            if (HitObjectName == Lastgameobject)
            {
                if (Camera2.GetComponent<Telekomkötögető>().backgroundszar2.TryGetValue(GameObject.Find(HitObjectName), out Vector2 value) == true)
                {
                    if (value.x == 0)
                    {
                        test1 = null;
                    }
                    if (value.x == 1)
                    {
                        test2 = null;
                    }
                }
            }


            //linedrawer
            if (test1 != null && test2 != null)
            {

                lr = test1.GetComponent<LineRenderer>();
                if (Camera2.GetComponent<Telekomkötögető>().Question.IndexOf(testtext1.GetComponent<TextMeshPro>().text) == Camera2.GetComponent<Telekomkötögető>().Answer.IndexOf(testtext2.GetComponent<TextMeshPro>().text))
                {

                    lr.startColor = Color.blue;
                    lr.endColor = Color.blue;
                    selectedint++;

                }
                if (Camera2.GetComponent<Telekomkötögető>().Question.IndexOf(testtext1.GetComponent<TextMeshPro>().text) != Camera2.GetComponent<Telekomkötögető>().Answer.IndexOf(testtext2.GetComponent<TextMeshPro>().text))
                {

                    lr.startColor = Color.red;
                    lr.endColor = Color.red;
                    Debug.Log(Camera2.GetComponent<Telekomkötögető>().Question.IndexOf(testtext1.GetComponent<TextMeshPro>().text));
                    Debug.Log(Camera2.GetComponent<Telekomkötögető>().Question.IndexOf(testtext2.GetComponent<TextMeshPro>().text));
                    //selectedint--;
                }
                lr.SetPosition(0, test1.transform.position);
                lr.SetPosition(1, test2.transform.position);
                lr = null;
                test1 = null;
                test2 = null;
                testtext1 = null;
                testtext2 = null;
                Lastgameobject = null;
                HitObjectName = null;
                if (selectedint == Camera2.GetComponent<Telekomkötögető>().Answer.Count)
                {
                    Debug.Log("you won");
                }

            }
        }

    }
}
