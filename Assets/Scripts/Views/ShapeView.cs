using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeView : IShapeView
{
    private const float activeScale = 0.72f, basicScale = 0.6f;

    [Inject]
    public IRoutineRunner routineRunner { get; private set; }

    [Inject]
    public MainModel mMain { get; private set; }

    [Inject]
    public BoardModel mBoard { get; private set; }

    [Inject]
    public BasicShapesModel BasicShapes { get; private set; }

    [Inject]
    public GameShapeModel GameShape { get; private set; }

    [Inject]
    public IBoardView Board { get; private set; }

    //[Inject]
    //public ShapeDropSignal DropSignal { get; private set; }

    public void Init()
    {
        object[] loadedShapes = Resources.LoadAll("Shapes");

        if (loadedShapes != null)
        {
            BasicShapes.shapes = new GameObject[loadedShapes.Length];

            for (int i = 0; i < loadedShapes.Length; i++)
            {
                BasicShapes.shapes[i] = loadedShapes[i] as GameObject;
            }
            Debug.Log("Loaded................................................." + loadedShapes.Length + " shapes");
        }
        else
            Debug.Log("Loaded.................................................... 0 shapes");
    }

    public GameObject Spawn(GameObject parent)
    {
        if (BasicShapes.shapes == null)
        {
            Debug.Log("No shapes loaded!");
            return null;
        }
        int randomNumber = Random.Range(0, BasicShapes.shapes.Length);

        GameObject tmp = GameObject.Instantiate(BasicShapes.shapes[randomNumber], parent.transform) as GameObject;
        return tmp;
    }

    public void Move(object handle)
    {
        GameShape.shape = handle as GameObject;
        GameShape.startPosition = GameShape.shape.transform.position;

        routineRunner.Execute(MoveRoutine(GameShape.shape));
    }

    public void Drop()
    {
        if (GameShape.shape != null)
        {
            GameShape.shape.transform.localScale = new Vector3(basicScale, basicScale, 1f);
            GameShape.shape.transform.position = GameShape.startPosition;
        }
        else
            Debug.Log("No object to drop. Probably error..");
    }

    public void Snap()
    {
        if (GameShape.shape != null)
        {
            Vector3 newPosition = GameShape.shape.transform.position;
            newPosition = new Vector3(Mathf.Round(newPosition.x / BoardModel.gridStep) * BoardModel.gridStep - BoardModel.gridStep * .47f, Mathf.Round(newPosition.y / BoardModel.gridStep) * BoardModel.gridStep - BoardModel.gridStep * .47f);

            GameShape.shape.transform.position = newPosition;
            Debug.Log("Dropped shape position ---------> " + newPosition);

            foreach (Transform pivot in GameShape.shape.transform)
            {
                if (pivot.transform.position.x > mBoard.bounds.x && pivot.transform.position.y > mBoard.bounds.y &&
                    pivot.transform.position.x < mBoard.bounds.z && pivot.transform.position.y < mBoard.bounds.w)
                {
                    Debug.Log("Shape in board bounds...............................OK");
                }
                else
                {
                    Debug.Log("Shape in board bounds.............................FAIL");
                    Drop();
                    return;
                }
            }

            Board.CheckPlace();

        }
        else
            Debug.Log("No object to snap. Probably error..");

    }

    protected IEnumerator MoveRoutine(GameObject handle)
    {
 
        handle.transform.localScale = new Vector3(activeScale, activeScale, 1f);

        while (mMain.MouseState)
        {
            handle.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f));

            yield return null;
        }

    }

}
