using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeView : IShapeView
{

    [Inject]
    public ShapesModel sModel { get; set; }

    public void Init()
    {
        object[] loadedShapes = Resources.LoadAll("Shapes");

        if (loadedShapes != null)
        {
            sModel.shapes = new GameObject[loadedShapes.Length];

            for (int i = 0; i < loadedShapes.Length; i++)
            {
                sModel.shapes[i] = loadedShapes[i] as GameObject;
            }
            Debug.Log("Loaded................................................." + loadedShapes.Length + " shapes");
        }
        else
            Debug.Log("Loaded..........................0 shapes");
    }
}
