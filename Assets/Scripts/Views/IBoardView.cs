using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoardView
{
    void Init();

    void CheckPlace();
    void CheckLine();
    void CheckMoves();

    void Place();
}
