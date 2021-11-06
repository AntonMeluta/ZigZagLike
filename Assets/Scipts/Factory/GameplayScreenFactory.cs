using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayScreenFactory : IFactory
{
    private GameScreenModel gameScreenModel;
    private GameScreenView gameScreenView;
    private GameScreenController gameScreenController;

    public GameplayScreenFactory(GameScreenView view)
    {
        gameScreenView = view;
    }

    public void InitializeFactory()
    {
        gameScreenModel = new GameScreenModel();
        //Подписка представления на изменение модели
        gameScreenModel.TapOnScreen += gameScreenView.UpdateVelocityPlayer;
        gameScreenController = new GameScreenController(gameScreenModel);
        //Прокидываем ссылку на Controller во View
        gameScreenView.SetController(gameScreenController);
    }
}
