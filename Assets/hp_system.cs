using TMPro;
using UnityEngine;

public class hp_system : MonoBehaviour
{
    public int hp = 100;
    public TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = hp.ToString();
    }
}
