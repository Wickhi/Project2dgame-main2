using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jelszó_kitalálós_sample : MonoBehaviour
{
    public Text passwordText;
    public List<string> question;
    public List<int> answer;
    public InputField inputField;
    public Text resultText;
    // logika: kérdéshez jelszó hozzárendelése
    // dictionary


    private string correctPassword = "unity123";

    void Start()
    {
        SetRandomPassword(); // Opcionális: véletlenszerű jelszó beállítása indításkor
    }
    void Update()
    {
        CheckPassword();
    }

    void SetRandomPassword()
    {
        correctPassword = "unity" + Random.Range(100, 999);
        passwordText.text = "Jelszó: " + correctPassword;
    }

    public void CheckPassword()
    {
        string userGuess = inputField.text;

        if (userGuess == correctPassword)
        {
            resultText.text = "Helyes jelszó! Gratulálok!";
        }
        else
        {
            resultText.text = "Helytelen jelszó. Próbáld újra!";
        }
    }



}

