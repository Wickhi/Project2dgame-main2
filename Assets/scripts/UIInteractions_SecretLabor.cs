using UnityEngine;

public class UIInteractions_SecretLabor : MonoBehaviour
{
    public RectTransform phone;
    bool activated;
    public bool buttonpressed;
    public Camera mapcam;
    public int camerastage = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Putphoneaway()
    {
        buttonpressed = true;

        if (buttonpressed == true)
        {
            if (phone.anchoredPosition.x == 80)
            {
                phone.anchoredPosition = new Vector2(-70, phone.anchoredPosition.y);
                buttonpressed = false;
            }
            if (buttonpressed == true)
            {
                if (phone.anchoredPosition.x == -70)
                {
                    phone.anchoredPosition = new Vector2(80, phone.anchoredPosition.y);
                    buttonpressed = false;

                }
            }

        }



    }
    public void Changemapsize()
    {
        camerastage++;
        if (camerastage == 1)
        {
            mapcam.orthographicSize = 10;
        }
        if (camerastage == 2)
        {
            mapcam.orthographicSize = 15;
        }
        if (camerastage == 3)
        {
            mapcam.orthographicSize = 30;
        }
        if (camerastage == 4)
        {
            mapcam.orthographicSize = 45;

        }
        if (camerastage == 5)
        {
            mapcam.orthographicSize = 55;
            camerastage = 0;
        }

    }
}