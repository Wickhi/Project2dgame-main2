using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class roomcreator : MonoBehaviour
{
   // https://docs.unity3d.com/2022.3/Documentation/ScriptReference/UnityEngine.TilemapModule.html
    //https://www.youtube.com/watch?v=h50OMdqtbKE&t=261s

    //Important variables
    public Vector3Int position;
    public Vector3 worldPoint;

    //Prefabs
    public TileBase Tilebase;
    public TileBase Tilebasesaved;
    public TileBase Tilebaseremove;
    public Tilemap tilemap;
    public Tilemap previewmap;
    public Tilemap Tilepalette;
    public Grid grid;
    public Grid grid2;
    public SpriteRenderer spriteRenderer;

    //Logic variables
    public bool MousePressed;
    public bool PickedBlock;
    public bool GetTileMode = false;
    public bool LeftCrtlPressed;

    // Toolmode variables
    public bool ToolMode;
    public bool EPressed;
    public bool RPressed;
    public bool EraseMode2;
    public bool EraseMode;
    public bool RectangleEditMode;
    public string erasername = "erasericon2";
    public string rectangletoolname = "rectangleicon";

    //variables for Rectangletool
    public Vector3Int Startposition;
    public Vector3Int Curentposition;
    public BoundsInt Rectangleside;

    //Variables
    public int Yoffset;
    public int Xoffset;
    public Vector3 gridOffset;


    // Start is called before the first frame update
    void Start()
    {
        // to avoid bugs
        Tilebasesaved = Tilebase;

    }

    // Update is called once per frame
    void Update()
    {
     
        //Set block action code
        if (Input.GetMouseButtonDown(0))
        {
            MousePressed = true;

        }
        if (Input.GetMouseButtonUp(0))
        {
            MousePressed = false;

        }
        if (MousePressed == true)
        {

            CastRay();

            
        }



        // Enter tile palette mode
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!LeftCrtlPressed)
            {
                LeftCrtlPressed = true;
                EPressed = false;
                GetTileMode = true;
                EraseMode = false;
            }
            else
            {
                LeftCrtlPressed = false;
                GetTileMode = false;
            }
        }

        //Toolmode for tilemap editing 
        if (ToolMode == true)
        {
            //EraserTool
            if (EraseMode == true)
            {
                Tilebase = null;
            }
            if (EraseMode == false)
            {
                if (EraseMode2 == false)
                {
                    if (PickedBlock == true)
                    {
                        Tilebase = Tilebasesaved;
                    }
                }
                    
            }

            //RectangleTool
            if (RectangleEditMode == true && GetTileMode == false)
            {
                //Erasetool for RectangleTool
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!EPressed)
                    {

                        EPressed = true;
                        EraseMode2 = true;
                        


                    }
                    else
                    {
                        EPressed = false;
                        EraseMode2 = false;


                    }
                }

               //Rectangle Drawing Mode
                if (Input.GetMouseButtonDown(0))
                {

                    MousePressed = true;
                    Startposition = grid.WorldToCell(worldPoint);
                    Startposition.x = Startposition.x - Xoffset;
                    Startposition.y = Startposition.y - Yoffset;
                    Tilebase = null;

                }

                //Final Rectangle Drawing
                if (Input.GetMouseButtonUp(0))
                {

                    if (EraseMode2 == false)
                    {
                        Tilebase = Tilebasesaved;
                    }
                    MousePressed = false;
                    Rectangleside.xMin = Curentposition.x < Startposition.x ? Curentposition.x : Startposition.x;
                    Rectangleside.xMax = Curentposition.x > Startposition.x ? Curentposition.x : Startposition.x;
                    Rectangleside.yMin = Curentposition.y < Startposition.y ? Curentposition.y : Startposition.y;
                    Rectangleside.yMax= Curentposition.y > Startposition.y ? Curentposition.y : Startposition.y;
                    previewmap.ClearAllTiles();
                    for (int x = Rectangleside.xMin; x <= Rectangleside.xMax; x++)
                    {
                        for (int y = Rectangleside.yMin; y <= Rectangleside.yMax; y++)
                        {
                            tilemap.SetTile(new Vector3Int(x, y, 0), Tilebase);
                        }
                    }
                    EraseMode = false;

                }

                //Rectangle Drawing onto previewtilemap
                if (MousePressed == true)
                {
                    if (EraseMode2 == true)
                    {
                        Tilebase = null;
                    }
                    for (int x = Rectangleside.xMin; x <= Rectangleside.xMax; x++)
                    {
                        for (int y = Rectangleside.yMin; y <= Rectangleside.yMax; y++)
                        {
                            previewmap.SetTile(new Vector3Int(x, y, 0), null);
                        }
                    }
                    Curentposition = grid.WorldToCell(worldPoint);
                    Curentposition.x = Curentposition.x - Xoffset;
                    Curentposition.y = Curentposition.y - Yoffset;
                    Rectangleside.xMin = Curentposition.x < Startposition.x ? Curentposition.x : Startposition.x;
                    Rectangleside.xMax = Curentposition.x > Startposition.x ? Curentposition.x : Startposition.x;
                    Rectangleside.yMin = Curentposition.y < Startposition.y ? Curentposition.y : Startposition.y;
                    Rectangleside.yMax = Curentposition.y > Startposition.y ? Curentposition.y : Startposition.y;
                    if (EraseMode2 == false)
                    {
                        for (int x = Rectangleside.xMin; x <= Rectangleside.xMax; x++)
                        {
                            for (int y = Rectangleside.yMin; y <= Rectangleside.yMax; y++)
                            {
                                previewmap.SetTile(new Vector3Int(x, y, 0), Tilebasesaved);
                            }
                        }
                    }
                    if (EraseMode2 == true)
                    {
                        for (int x = Rectangleside.xMin; x <= Rectangleside.xMax; x++)
                        {
                            for (int y = Rectangleside.yMin; y <= Rectangleside.yMax; y++)
                            {
                                previewmap.SetTile(new Vector3Int(x, y, 0), Tilebaseremove);
                            }
                        }
                    }


                }

            }
        }


        //eraseraction actived by pressing E
        if (Input.GetKeyDown(KeyCode.E) && RectangleEditMode == false)
        {
            if (!EPressed)
            {

                EPressed = true;
                EraseMode = true;
                ToolMode = true;
                EraseMode2 = false;
                

            }
            else
            {
                EPressed = false;
                ToolMode = false;
                EraseMode = false;
                EraseMode2 = false;
                RectangleEditMode = false;
                EraseMode2 = false;
            }
        }
        //Calling of RectangleEditMode
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!RPressed)
            {
                RPressed = true;
                RectangleEditMode = true;
                ToolMode = true;
                EraseMode2 = false;
            }
            else
            {
                RPressed = false;
                ToolMode = false;
                RectangleEditMode = false;
                EraseMode2 = false;
                Tilebase = Tilebasesaved;

            }
        }

        //Call for GetTileMode
        if (GetTileMode == false)
        {
            Tilepalette.GetComponent<TilemapRenderer>().enabled = false;
        }
        if (GetTileMode == true)
        {
            Tilepalette.GetComponent<TilemapRenderer>().enabled = true;
        }
    }





    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        worldPoint = ray.GetPoint(0);
        if (GetTileMode == false)
        {
           
            position = grid.WorldToCell(worldPoint);
            position.x = position.x - Xoffset;
            position.y = position.y - Yoffset;
            if (RectangleEditMode == false)
            {
                tilemap.SetTile(position, Tilebase);
            }

        }
        if (GetTileMode == true)
        {
            position = grid2.WorldToCell(worldPoint);
            position.x = position.x - Xoffset;
            position.y = position.y - Yoffset;

            if (Tilebase != null || ToolMode == false)
            {
                //EraseMode = false;
                Tilebase = Tilepalette.GetTile(position);
                PickedBlock = true;
                Tilebasesaved = Tilebase;



            }
        }

    }
    
}
