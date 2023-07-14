using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textszar : MonoBehaviour
{
    public string MyText;
    public GameObject stuart;
    public TextMeshProUGUI text;
    public int szar;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        szar = stuart.GetComponent<shooting_script>().active.mag;


        text.text = szar.ToString(); 
    }
}
