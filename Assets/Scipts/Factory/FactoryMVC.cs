using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryMVC : IFactory
{
    private ModelMVC modelMVC;
    private ControllerMVC controllerMVC;

    private CrystallCounterView crystallCounterView;
    private GameScreenView gameScreenView;
    private MenuScreenView menuScreenView;

    public FactoryMVC(CrystallCounterView cv, GameScreenView gs, MenuScreenView ms)
    {
        crystallCounterView = cv;
        gameScreenView = gs;
        menuScreenView = ms;
    }

    public void InitializeFactory()
    {
        modelMVC = new ModelMVC();
        //подписка модели на событие рестарта игры для сброса числовых значений
        EventsBroker.OnRestartGame += modelMVC.ResetValues;

        controllerMVC = new ControllerMVC(modelMVC);

        //Прокидываем ссылку на Controller во Views
        crystallCounterView.SetController(controllerMVC);
        gameScreenView.SetController(controllerMVC);
        menuScreenView.SetController(controllerMVC);
    }
}
