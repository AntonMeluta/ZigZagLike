using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalCounterFactory : IFactory
{
    private CrystallCounterModel crystallCounterModel;
    private CrystallCounterView crystallCounterView;
    private CrystallCounterController crystallCounterController;

    public CrystalCounterFactory(CrystallCounterView view)
    {
        crystallCounterView = view;
    }

    public void InitializeFactory()
    {
        crystallCounterModel = new CrystallCounterModel();
        //Подписка представления на изменение модели
        crystallCounterModel.EventUpdate += crystallCounterView.UpdateValueOnScreen;
        //Подписа обнуления счета игры на "рестарт" сцены
        EventsBroker.OnRestartGame += crystallCounterModel.SkipValue;
        crystallCounterController = new CrystallCounterController(crystallCounterModel);
        //Прокидываем ссылку на Controller во View
        crystallCounterView.SetController(crystallCounterController);
    }
}
