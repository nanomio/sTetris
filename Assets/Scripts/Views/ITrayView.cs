using UnityEngine;

public interface ITrayView
{
    void Init();
    void ShapeSpawn(GameObject parent);
    void ShapeMove(int number);
    void ShapeDrop();
    void CheckClick();
}