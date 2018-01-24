using System;
using System.Collections;
using UnityEngine;

public class Tray3DView : ITrayView
{
    [Inject]
    public IRoutineRunner routineRunner { get; set; }

    [Inject]
    public MainModel mModel { get; set; }

    [Inject]
    public TraysModel mTrays { get; set; }

    [Inject]
    public ShapesModel mShapes { get; set; }

    [Inject]
    public TrayHitSignal hitSignal { get; set; }

    private int spawnShapesCounter;

    public void Init()
    {
        spawnShapesCounter = 0;

        GameObject[] initedTrays = GameObject.FindGameObjectsWithTag("Tray");

        if (initedTrays == null)
        {
            Debug.Log("Inited..................................................... 0 trays");
            return;
        }

        Debug.Log("Inited..................................................... " + initedTrays.Length + " trays");

        mTrays.trays = new GameObject[initedTrays.Length];
        foreach (GameObject tray in initedTrays)
        {
            mTrays.trays[TrayNumber(tray.name) - 1] = tray;
            ShapeSpawn(tray);
        }

        Debug.Log("Spawned.............................................. " + spawnShapesCounter + " shapes");
    }

    public void ShapeSpawn(GameObject parent)
    {
        if (mShapes.shapes == null)
        {
            Debug.Log("No shapes loaded!");
            return;
        }
        int randomNumber = UnityEngine.Random.Range(0, mShapes.shapes.Length);

        GameObject tmp = GameObject.Instantiate(mShapes.shapes[randomNumber], parent.transform) as GameObject;

        if (tmp != null)
            spawnShapesCounter++;
    }

    public void ShapeMove(int number)
    {
        routineRunner.Execute(MoveRoutine(number));
    }

    public void ShapeDrop()
    {
    }

    public void CheckClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.Log("Mouse position: " + Input.mousePosition);

        RaycastHit hitInfo = new RaycastHit();
        Physics.Raycast(ray, out hitInfo, Mathf.Infinity);

        if (hitInfo.collider != null)
        {
            hitSignal.Dispatch(TrayNumber(hitInfo.collider.gameObject.name) - 1);
        }
        else
            Debug.Log("No hit");
    }

    protected IEnumerator MoveRoutine(int number)
    {
        GameObject movingShape = mTrays.trays[number].transform.GetChild(0).gameObject;

        while (mModel.MouseState)
        {
            movingShape.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));

            yield return null;
        }
    }

    protected int TrayNumber(string name)
    {
        string[] separators = { "_", "-", " " },
                 parts = name.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 0)
            return -1;
        else
            return Int32.Parse(parts[parts.Length - 1]);
    }

}
