using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public int rows;
    public int columns;
    public float spacing;
    public GameObject brickPreFab;

    private List<GameObject> bricks = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        ResetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetLevel()
    {
        // Clear remain bricks
        foreach (GameObject brick in bricks)
        {
            Destroy(brick);
        }
        bricks.Clear();

        // Initialize
        for (int x = 0; x < rows; x ++)
        {
            for (int y = 0; y < columns; y ++)
            {
                // asign brick positions
                Vector3 spawnPos = (Vector3) transform.position +
                                    new Vector3 (x * (brickPreFab.transform.localScale.x + spacing),
                                                -y * (brickPreFab.transform.localScale.y + spacing),
                                                0);
                GameObject brick = Instantiate(brickPreFab, spawnPos, Quaternion.identity);
                // set color based on column
                Renderer brickRenderer = brick.GetComponent<Renderer>();
                brickRenderer.material.SetColor("_Color", RandomColor(y));
                // add brick to prefab List
                bricks.Add(brick);
            }
        }
    }

    // activate when brick collide with ball
    public void RemoveBrick(Brick brick)
    {
        // delete brick when collide with ball
        bricks.Remove(brick.gameObject);
        // reset when all bricks are destroyed
        if (bricks.Count == 0)
        {
            ResetLevel();
        }
    }

    // return color options
    private Color RandomColor(int caseNum)
    {
        Color colorCode;
        switch(caseNum) 
        {
            case 0:
                colorCode = Color.red;
                break;
            case 1:
                colorCode = Color.blue;
                break;
            case 2:
                colorCode = Color.green;
                break;
            case 3:
                colorCode =  Color.yellow;
                break;
            case 4:
                colorCode = Color.cyan;
                break;
            default:
                colorCode = Color.black;
                break;
        }
        return colorCode;
    }
}
