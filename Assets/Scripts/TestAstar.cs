using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAstar : MonoBehaviour
{
    private Tile tile;


    private int[,] arrMap;
    private int tileWidth = 100;
    private int tileHeight = 100;
    public int col;
    public int row;

    public Transform tileParents;
    private List<Vector2> openList;

    public Vector2 obstacle1;
    public Vector2 obstacle2;
    public Vector2 obstacle3;
    public Vector2 startTile;
    public Vector2 endTile;

    private Tile tileGo;

    private int a;
    private int b;
    // Start is called before the first frame update
    void Start()
    {
        this.openList = new List<Vector2>();

        this.arrMap = new int[this.col, this.row];
        this.NearNode();
        this.CreateTile();
        this.CreateLine();

        //this.openList.Add()
       
    }

    void CreateTile()
    {
        for (int i = 0; i < this.col; i++)
        {
            for (int j = 0; j < this.row; j++)
            {

                var tilePrefab = Resources.Load<Tile>("bgTile");
                this.tileGo = Instantiate<Tile>(tilePrefab);
                tileGo.transform.SetParent(this.tileParents);
                var screenPos = new Vector2(j * this.tileWidth + 512 - 292, i * -this.tileHeight + this.tileHeight * 6);
                var worldPos = Camera.main.ScreenToWorldPoint(screenPos);
                worldPos.z = 0;
                tileGo.transform.position = worldPos;

                //var mesh = tileGo.GetComponentInChildren<TextMesh>();
                tileGo.mesh.GetComponent<TextMesh>().text = string.Format("({0},{1})", j, i);

                //mesh.text = string.Format("({0},{1})", j, i);



                if (j == this.startTile.x && i == this.startTile.y)
                {
                    tileGo.GetComponent<SpriteRenderer>().color = Color.green;
                }

                if (j == this.endTile.x && i == this.endTile.y)
                {
                    tileGo.GetComponent<SpriteRenderer>().color = Color.red;
                }

                //if (j == 3 && i == 1 || j == 3 && i == 2 || j == 3 && i == 3)
                //{
                //    tileGo.GetComponent<SpriteRenderer>().color = Color.blue;
                //}

                if (j == this.obstacle1.x && i == this.obstacle1.y)
                {
                    tileGo.GetComponent<SpriteRenderer>().color = Color.blue;
                }
                if (j == this.obstacle2.x && i == this.obstacle2.y)
                {
                    tileGo.GetComponent<SpriteRenderer>().color = Color.blue;
                }
                if (j == this.obstacle3.x && i == this.obstacle3.y)
                {
                    tileGo.GetComponent<SpriteRenderer>().color = Color.blue;
                }

                if(j == this.a ||i==this.b)
                {
                    tileGo.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
            }
        }
    }

    void CreateLine()
    {

        for (int i = 0; i < this.col; i++)
        {
            for (int j = 0; j < this.row; j++)
            {

                var linePrefab = Resources.Load<GameObject>("line");
                var lineGo = Instantiate<GameObject>(linePrefab);
                lineGo.transform.SetParent(this.tileParents);
                var screenPos = new Vector2(j * this.tileWidth + 512 - 292, i * -this.tileHeight + this.tileHeight * 6);
                var worldPos = Camera.main.ScreenToWorldPoint(screenPos);
                worldPos.z = 0;
                lineGo.transform.position = worldPos;
            }
        }

    }



    void NearNode()
    {
        Debug.Log(this.startTile);
        var nearNode = this.startTile - new Vector2(1, 1);
        for (this.a = (int)nearNode.x; a < 3; a++)
        {
            for (this.b = (int)nearNode.y; b < 4; b++)
            {
                this.openList.Add(new Vector2(a, b));
                Debug.LogFormat("{0},{1}", a, b);
                
            }
        }

    }

}
