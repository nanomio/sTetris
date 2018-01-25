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
    public IShapeView shapes { get; set; }

    [Inject]
    public TrayHitSignal hitSignal { get; set; }

    public void Init()
    {
        int spawnShapesCounter = 0;

        GameObject[] initedTrays = GameObject.FindGameObjectsWithTag("Tray");

        if (initedTrays == null)
        {
            Debug.LogError("Inited..................................................... 0 trays");
            return;
        }

        Debug.Log("Inited..................................................... " + initedTrays.Length + " trays");

        mTrays.trays = new GameObject[initedTrays.Length];
        foreach (GameObject tray in initedTrays)
        {
            mTrays.trays[TrayNumber(tray.name) - 1] = tray;
            if (shapes.Spawn(tray) != null)
                spawnShapesCounter++;
        }

        Debug.Log("Spawned.............................................. " + spawnShapesCounter + " shapes");

        mTrays.shapesLeft = spawnShapesCounter;
    }

    public void CheckClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo = new RaycastHit();
        Physics.Raycast(ray, out hitInfo, Mathf.Infinity);

        if (hitInfo.collider != null)
        {
            hitSignal.Dispatch(hitInfo.collider.gameObject);
        }
        else
            Debug.Log("No hit");
    }

    public void SpawnAll()
    {
        int spawnShapesCounter = 0;

        foreach (GameObject tray in mTrays.trays)
        {
            if (shapes.Spawn(tray) != null)
                spawnShapesCounter++;
        }

        Debug.Log("Spawned.......................................... " + spawnShapesCounter + " new shapes");

        mTrays.shapesLeft = spawnShapesCounter;

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
