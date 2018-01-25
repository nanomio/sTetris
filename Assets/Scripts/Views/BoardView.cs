using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardView : IBoardView
{

    [Inject]
    public BoardModel mBoard { get; private set; }

    [Inject]
    public GameShapeModel GameShape { get; private set; }

    [Inject]
    public ShapeDropSignal DropSignal { get; private set; }
    [Inject]
    public ShapePlaceSignal PlaceSignal { get; private set; }

    public void Init()
    {
        GameObject blockPrefab = GameObject.Find("BoardBlock");
        if (blockPrefab == null)
        {
            Debug.LogError("Error.......................no board block prefab found!");
            return;
        }
        Debug.Log("Block prefab..........................................grabbed");
        Vector3 startPosition = blockPrefab.transform.position;
        blockPrefab.SetActive(false);

        GameObject gameBoard = GameObject.Find("GameBoard");
        if (gameBoard == null)
        {
            Debug.LogError("Error................GameBoard object can't be found!");
            return;
        }
        Debug.Log("GameBoard object.................................grabbed");

        GameObject checkerHorizontal = GameObject.Find("Checker Horizontal");
        GameObject checkerVertical = GameObject.Find("Checker Vertical");

        if (checkerHorizontal == null || checkerVertical == null)
        {
            Debug.LogError("Error................Checker objects can not be found!");
            return;
        }
        Debug.Log("Checker objects.....................................grabbed");

        mBoard.checkerHorizontal = checkerHorizontal;   mBoard.checkerHorizontal.SetActive(false);
        mBoard.checkerVertical = checkerVertical;       mBoard.checkerVertical.SetActive(false);

        mBoard.gameBoard = gameBoard;
        mBoard.bounds = new Quaternion(startPosition.x - BoardModel.gridStep * .5f, startPosition.y - BoardModel.gridStep * .5f, startPosition.x + 9 * BoardModel.gridStep + BoardModel.gridStep * .5f, startPosition.y + 9 * BoardModel.gridStep + BoardModel.gridStep * .5f);

    }

    public void CheckPlace()
    {
        Rigidbody2D rb2d = GameShape.shape.GetComponentInChildren<Rigidbody2D>();
        RaycastHit2D[] colisions = new RaycastHit2D[9];

        if (rb2d.IsTouchingLayers(LayerMask.GetMask(new string[] { "Default" })))
        {
            Debug.Log("Found colisions!");
            DropSignal.Dispatch();
        }
        else
        {
            Debug.Log("Yey! No collisions.");
            PlaceSignal.Dispatch();
        }
    }

    public void CheckLine()
    {
        int colisionsCounter;

        mBoard.checkerHorizontal.SetActive(true);
        mBoard.checkerVertical.SetActive(true);

        RaycastHit2D[] colisions = new RaycastHit2D[15];
        Rigidbody2D r2d1 = mBoard.checkerHorizontal.GetComponent<Rigidbody2D>(),
                    r2d2 = mBoard.checkerVertical.GetComponent<Rigidbody2D>();

        Vector3 sPositionHorizontal = mBoard.checkerHorizontal.transform.position,
                sPositionVertical = mBoard.checkerVertical.transform.position;

        for (int i = 0; i < 1; i++)
        {
            Vector3 newPosition = new Vector3(sPositionHorizontal.x, sPositionHorizontal.y + i * BoardModel.gridStep);
            r2d1.transform.position = newPosition;

            newPosition = new Vector3(sPositionVertical.x + i * BoardModel.gridStep, sPositionVertical.y);
            r2d2.transform.position = newPosition;

            if ((colisionsCounter = r2d1.Cast(Vector2.right, colisions)) == 10)
            {
                Debug.Log("Omg! The Line!! And its horizontal, btw.");

                for (int j = 0; j < colisionsCounter; j++)
                    Object.Destroy(colisions[j].collider.gameObject);
            }
            else Debug.Log("Horizontal hit..................................." + colisionsCounter);

            if ((colisionsCounter = r2d2.Cast(Vector2.up, colisions)) == 10)
            {
                Debug.Log("Omg! The Line!! And its vertical.");

                for (int j = 0; j < colisionsCounter; j++)
                    Object.Destroy(colisions[j].collider.gameObject);
            }
            else Debug.Log("Vertical hit....................................." + colisionsCounter);

        }

        mBoard.checkerHorizontal.SetActive(false);
        mBoard.checkerVertical.SetActive(false);

        mBoard.checkerHorizontal.transform.position = sPositionHorizontal;
        mBoard.checkerVertical.transform.position = sPositionVertical;

    }

    public void CheckMoves()
    {

    }

    public void Place()
    {

        int childCount = GameShape.shape.transform.childCount;
        GameObject[] tmpArray = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
            if (GameShape.shape.transform.GetChild(i).tag == "Block")
                tmpArray[i] = GameShape.shape.transform.GetChild(i).gameObject;

        for (int i = 0; i < childCount - 1; i++)
            tmpArray[i].transform.parent = mBoard.gameBoard.transform;

        Object.Destroy(GameShape.shape);
        
    }

}
