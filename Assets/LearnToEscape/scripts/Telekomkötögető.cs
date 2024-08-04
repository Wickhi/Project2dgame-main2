using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Telekomkötögető : MonoBehaviour
{
    // http://digitalnativestudios.com/textmeshpro/docs/ScriptReference/TextMeshPro-alignment.html
    public List<string> Question;
    public List<string> Answer;
    public List<int> sorszam;
    public List<string> Answer2;
    public List<string> Question2;
    public Sprite sprite;
    public SpriteRenderer spriteRenderer;
    public bool good = true;
    public int CellSize;
    public Dictionary<Vector2, GameObject> backgroundszar;
    public Dictionary<GameObject, Vector2> backgroundszar2;
    public int coordinate;
    public int answercountoriginal;
    public GameObject prefab;
    public GameObject prefab2;
    public GameObject Turnoff;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGame();
    }


    // Dictionary for later use
    public GameObject Getileatpostition(Vector2 pos)
    {
        if (backgroundszar.TryGetValue(pos, out var point))
        {
            return point;
        }
        return null;
    }






    private void GenerateGame()
    {
        //check if question has an aswer
        if (Question.Count != Answer.Count)
        {
            Debug.Log("Valamelyik kérdésre nincs megfejtés");
            good = false;
        }



        // if program is good to run
        if (good == true)
        {
            backgroundszar = new Dictionary<Vector2, GameObject>();
            backgroundszar2 = new Dictionary<GameObject, Vector2>();

            Vector3 gridOffset = transform.position - new Vector3(2 * CellSize / 2f, Answer.Count * CellSize / 2f, 0f);
            answercountoriginal = Answer.Count;
            for (int ő = 0; ő < Question.Count; ő++)
            {
                Answer2.Add(Answer[ő]);
                Question2.Add(Question[ő]);
            }

            //answer randomisation
            int l = Answer.Count;
            while (l > 1)
            {
                l--;
                int k = Random.Range(0, l + 1);
                var value = Answer2[k];
                Answer2[k] = Answer2[l];
                Answer2[l] = value;
            }


            //question randomisation
            int p = Question.Count;
            while (p > 1)
            {
                p--;
                int e = Random.Range(0, p + 1);
                var value = Question2[e];
                Question2[e] = Question2[p];
                Question2[p] = value;
            }


            // Grid generation algorith
            for (int x = 0; x < 2; x++)
            {

                for (int y = 0; y < Question.Count; y++)
                {
                    // Graphicsgeneration
                    Vector2Int position = new Vector2Int(x, y);
                    GameObject cellObject = Instantiate(prefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
                    cellObject.name = ("Cellobject (" + x + ", " + y + ")");
                    GameObject cellText = Instantiate(prefab2, new Vector3(position.x, position.y, 0), Quaternion.identity);
                    cellText.name = ("Textobject (" + x + ", " + y + ")");
                    cellObject.transform.SetParent(transform);
                    cellText.transform.SetParent(cellObject.transform);
                    spriteRenderer = cellObject.GetComponent<SpriteRenderer>();
                    var textMesh = cellText.GetComponent<TextMeshPro>();
                    var rectTransform = cellText.GetComponent<RectTransform>();
                    var collider = cellObject.GetComponent<BoxCollider2D>();

                    cellObject.transform.position = gridOffset + new Vector3(x * CellSize, y * CellSize, 10f);
                    backgroundszar.Add(position, cellObject);
                    backgroundszar2.Add(cellObject, position);

                    //backgroundszar[new Vector2(x, y)] = cellObject;
                    //backgroundszar2[cellObject] = new Vector2(x, y);


                    // Card text printing
                    for (int m = 0; m < Answer.Count; m++)
                    {

                        if (x % 2 == 0)
                        {
                            textMesh.text = Question2[y];

                        }
                        if (x % 2 != 0)
                        {
                            textMesh.text = Answer2[y];
                        }
                    }



                }
            }




        }


    }
    public void Enablecard()
    {
        for (int x = 0; x < 2; x++)
        {

            for (int y = 0; y < Question.Count; y++)
            {
                Vector2Int position = new Vector2Int(x, y);
                Turnoff = backgroundszar[position];
                Debug.Log(Turnoff.name);
                if (Turnoff.activeSelf == true)
                {
                    Turnoff.SetActive(false);
                }
                else
                {
                    Turnoff.SetActive(true);

                }

            }
        }
    }
}

