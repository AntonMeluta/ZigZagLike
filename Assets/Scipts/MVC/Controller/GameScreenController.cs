using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreenController
{
    private GameScreenModel gameScreenModel;

    public GameScreenController(GameScreenModel model)
    {
        gameScreenModel = model;
    }

    public void UserTap()
    {
        gameScreenModel.OnTapScreen();
    }
}
