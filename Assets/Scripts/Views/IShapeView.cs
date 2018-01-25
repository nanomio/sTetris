using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShapeView
{
    void Init();

    GameObject Spawn(GameObject parent);

    void Move(object handle);
    void Drop();
    void Snap();
}
