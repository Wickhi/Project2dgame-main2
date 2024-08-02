using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class passwordguesser : MonoBehaviour
{
    public string solution;
    public string[] words;
    public char[] characters;
    public char[] charactersinwords;
    public Dictionary<char[], string> wordsSplitup;
    public Dictionary<Vector2, GameObject> Objectlocation;
    public Dictionary<Vector2, GameObject> TextObjectlocation;
    public Dictionary<float, int> maxNumberInRow;
    public Dictionary<GameObject, Vector2> ObjectlocationReverse;
    public Dictionary<float, int> lastNumberInRow;
    public GameObject prefab;
    public GameObject prefab2;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    public float CellSize;
    public TextMeshPro gt;
    public string HitObjectName;
    public GameObject Object;
    public float i;
    public int currentnumber = 0;
    public int allowedNumbersInCard = 2;
    public bool cannotDeleteMoreWords;
    public int maxNumber;
    public GameObject Turnoff;
    public GameObject Turnoff2;
    // Start is called before the first frame update
    void Start()
    {
        solution = solution.ToUpper();
        characters = solution.ToCharArray();
        Vector3 gridOffset = transform.position - new Vector3(2 * CellSize / 2f, words.Length * CellSize / 2f, 0f);
        Objectlocation = new Dictionary<Vector2, GameObject>();
        TextObjectlocation = new Dictionary<Vector2, GameObject>();
        ObjectlocationReverse = new Dictionary<GameObject, Vector2>();
        lastNumberInRow = new Dictionary<float, int>();
        maxNumberInRow = new Dictionary<float, int>();
        for (int y = 0; y < words.Length; y++)
        {
            words[y] = words[y].ToUpper();
            string word = words[words.Length - y - 1];
            charactersinwords = word.ToCharArray();
            lastNumberInRow.Add(y, currentnumber);
            maxNumber = charactersinwords.Length + 1;
            maxNumberInRow.Add(y, maxNumber);

            for (int x = 0; x < charactersinwords.Length; x++)
            {
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
                //textMesh.text = charactersinwords[x].ToString();
                Objectlocation.Add(position, cellObject);
                ObjectlocationReverse.Add(cellObject, position);
                Objectlocation[new Vector2(x, y)] = cellObject;
                ObjectlocationReverse[cellObject] = new Vector2(x, y);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
            i = ObjectlocationReverse[Object].y;
            currentnumber = lastNumberInRow[i];
            if (Objectlocation.TryGetValue(new Vector2(currentnumber, i), out GameObject adcbd) == true)
            {
                gt = Objectlocation[new Vector2(currentnumber, ObjectlocationReverse[Object].y)].GetComponentInChildren<TextMeshPro>();
                Object = Objectlocation[new Vector2(currentnumber, i)];

            }
            if (Objectlocation.TryGetValue(new Vector2(currentnumber, i), out GameObject adcbdd) == false)
            {
                gt = Objectlocation[new Vector2(currentnumber - 1, ObjectlocationReverse[Object].y)].GetComponentInChildren<TextMeshPro>();
                Object = Objectlocation[new Vector2(currentnumber - 1, i)];

            }

            maxNumber = 0;
           
            //if (Objectlocation.TryGetValue(new Vector2(currentnumber - 1, i), out GameObject adc) == true)
            //{
                //currentnumber--;
            //}

        }
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed? 
            {
                if (currentnumber < 0)
                {
                    currentnumber = 0;
                    lastNumberInRow[i] = 0;

                }
                if (currentnumber != 0)
                {
                    currentnumber--;

                }
                lastNumberInRow[i] = currentnumber;
                Object = Objectlocation[new Vector2(currentnumber, i)];
                gt = Objectlocation[new Vector2(currentnumber, ObjectlocationReverse[Object].y)].GetComponentInChildren<TextMeshPro>();
                if (gt.text.Length == allowedNumbersInCard)
                {
                    gt.text = gt.text.Substring(0, gt.text.Length - 1);


                }





                
            }
            //else if ((c == '\n') || (c == '\r')) // enter/return
            //{
                //print("User entered their name: " + gt.text);
            //}
            else
            {
                if (Objectlocation.TryGetValue(new Vector2(currentnumber, i), out GameObject adcbd) == true)
                {
                    gt = Objectlocation[new Vector2(currentnumber, ObjectlocationReverse[Object].y)].GetComponentInChildren<TextMeshPro>();
                    Object = Objectlocation[new Vector2(currentnumber, i)];

                }
                
                currentnumber++;
                lastNumberInRow[i] = currentnumber;
                if (Objectlocation.TryGetValue(new Vector2(currentnumber + 1, i), out GameObject adcb) == false)
                {
                    maxNumber = currentnumber + 1;
                    lastNumberInRow[i] = currentnumber;

                }
                if (maxNumberInRow[i] == currentnumber)
                {
                    currentnumber--;
                    maxNumber = currentnumber;
                    lastNumberInRow[i] = currentnumber;
                }
                if (gt.text.Length != allowedNumbersInCard)
                {
                    gt.text += c;
                    gt.text = gt.text.ToUpperInvariant();

                }

            }
        }
    }
    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        // cardselector
        if (hit.collider != null)
        {
            //Lastgameobject = HitObjectName;
            HitObjectName = hit.collider.gameObject.name;
            Object = GameObject.Find(HitObjectName);
        }
    }
    public void Enablecard()
    {
        for (int y = 0; y < words.Length; y++)
        {
            string word = words[words.Length - y - 1];
            charactersinwords = word.ToCharArray();
            for (int x = 0; x < charactersinwords.Length; x++)
            {
                Vector2Int position = new Vector2Int(x, y);
                Turnoff = Objectlocation[position];
                //Turnoff2 = TextObjectlocation[position];
                if (Turnoff.activeSelf == true)
                {
                    Turnoff.SetActive(false);
                    //Turnoff2.SetActive(false);
                }
                else
                {
                    Turnoff.SetActive(true);
                    //Turnoff2.SetActive(true);

                }
            }
        }
        
    }
}

