using UnityEngine;

public class cell3 : MonoBehaviour
{
    public Vector2 position;
    public int fCost = int.MaxValue;
    public int gCost = int.MaxValue;
    public int hCost = int.MaxValue;
    public Vector2 connection;
    public bool isWall;

    public bool tiletoavoid;
    public bool spawnpoint;
    public overlord overlord;
    void Start()
    {
        if (spawnpoint == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            overlord.Spawnpoints.Add(gameObject);
        }
    }
}
