using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreenFactory : IFactory
{
    private MenuScreenModel menuScreenModel;
    private MenuScreenView menuScreenView;
    private MenuScreenController menuScreenController;

    public MenuScreenFactory(MenuScreenView view)
    {
        menuScreenView = view;
    }

    public void InitializeFactory()
    {
        menuScreenModel = new MenuScreenModel();
        //Подписка представления на изменение модели
        menuScreenModel.transitionNextScreen += menuScreenView.ToSwithcScreen;
        menuScreenController = new MenuScreenController(menuScreenModel);
        //Прокидываем ссылку на Controller во View
        menuScreenView.SetController(menuScreenController);
    }
}
