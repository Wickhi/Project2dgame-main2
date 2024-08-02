using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class Richtexteditor : MonoBehaviour
{
    //public TextMeshProUGUI gt;
    public TMP_InputField tMP_Input;
    public string ogtext;
    public TMP_Text textfield;
    public string newtext;
    public string inputText;
    public string selectedText;
    public bool _highlighted = false;
    public string selectedTextChange;
    public string lasttext;
    public string colortag = "red";
    public string starttag = "<color=";
    public string endtag = "</color>";
    public int starttagpoint;
    public int endtagpositiontemp;
    public int endtagpoint;
    public string selectedTextUncensored;
    public int endpositionadjusted;
    public int adjustedstart;



    // Start is called before the first frame update
    void Start()
    {
        //https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/manual/RichText.html
        //https://www.youtube.com/watch?v=marGMXTe1Qs&list=PLg0yr4zozmZX0dJZ-XNa4v0i_kAVx2sfY&index=21
        //https://docs.unity3d.com/Packages/com.unity.textmeshpro@1.3/api/TMPro.TMP_InputField.TextSelectionEvent.html
        //https://www.c-sharpcorner.com/article/c-sharp-regex-examples/
        //https://forum.unity.com/threads/how-to-get-highlighted-text-and-the-highlighted-word-position-from-inputfield.1313541/
        //https://stackoverflow.com/questions/15582441/how-to-get-index-of-word-inside-a-string





        //Ha majd akarom atirom normalisra





    
        starttag = starttag + colortag + ">";
        
    }

    // Update is called once per frame
    public void Awake()
    {


        tMP_Input.onTextSelection.AddListener(GetSelectedText);

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {



            //lasttext = selectedText2;
            selectedTextChange = starttag + selectedTextUncensored + endtag;
            _highlighted = true;
            ChangeText();
            // ezen kell változtatni ha akarok
            //endpositionadjusted = starttagpoint + selectedTextChange.Length;
            //tMP_Input.selectionFocusPosition = tMP_Input.text.IndexOf(selectedTextChange) + selectedTextChange.Length;
            //endpositionadjusted = tMP_Input.selectionFocusPosition;


        }
        if (Input.GetMouseButtonDown(4))
        {

            selectedTextChange = starttag + selectedTextUncensored + endtag;
            ResetText();
            ChangeText();
            // ezen kell változtatni ha akarok
            //endpositionadjusted = starttagpoint + selectedTextChange.Length;
            //tMP_Input.selectionFocusPosition = tMP_Input.text.IndexOf(selectedTextChange) + selectedTextChange.Length;
            //endpositionadjusted = tMP_Input.selectionFocusPosition;


        }
    }


    public void GetSelectedText(string str, int start, int end)
    {
        selectedText = str.Substring(Mathf.Min(start, end), Mathf.Abs(end - start));
        selectedTextUncensored = selectedText;
        selectedText = selectedText.Replace(endtag, "");
        selectedText = selectedText.Replace(starttag, "");
        adjustedstart = tMP_Input.text.IndexOf(selectedText);
        starttagpoint = start;
        endtagpositiontemp = end;
        Debug.Log("start= " + start +  " end= " + end);
        

    }
    public void GetSelectedText2(string str, int start, int end)
    {
        selectedText = str.Substring(Mathf.Min(tMP_Input.selectionAnchorPosition, tMP_Input.selectionFocusPosition), Mathf.Abs(tMP_Input.selectionFocusPosition - tMP_Input.selectionAnchorPosition));
        //selectedText2 = starttag + selectedText + endtag;
        inputText = inputText.Replace(selectedText, selectedTextChange);
        Debug.Log("start= " + tMP_Input.selectionAnchorPosition + " end= " + tMP_Input.selectionFocusPosition);
        //Debug.Log(newstr);
    }
    public void Getendtagposition()
    {
        while(tMP_Input.text.Substring(Mathf.Min(starttagpoint, endtagpoint), Mathf.Abs(endtagpoint - starttagpoint)) != endtag)
        {

        }
    }
    public void ChangeText()
    {
        int startposoftext = tMP_Input.text.IndexOf(selectedTextUncensored);
        //selectedTextChange = starttag + selectedTextUncensored + endtag;
        tMP_Input.text = tMP_Input.text.Remove(Mathf.Min(starttagpoint, endtagpositiontemp), selectedTextUncensored.Length);
        tMP_Input.text = tMP_Input.text.Insert(Mathf.Min(starttagpoint, endtagpositiontemp), selectedTextChange);
        tMP_Input.selectionFocusPosition = 0;
        tMP_Input.selectionAnchorPosition = 0;
        selectedText = null;
        selectedTextChange = null;
        selectedTextUncensored = null;
        starttagpoint = 0;
        endtagpositiontemp = 0;
        //tMP_Input.text = tMP_Input.text.Insert(Mathf.Min(starttagpoint, tMP_Input.selectionFocusPosition), starttag);
        //tMP_Input.text = tMP_Input.text.Insert(Mathf.Max(starttagpoint + selectedTextUncensored.Length, tMP_Input.selectionFocusPosition), endtag);

    }
    public void ResetText()
    {
        selectedTextChange = selectedTextChange.Replace(endtag, "");
        selectedTextChange = selectedTextChange.Replace(starttag, "");


    }


}
