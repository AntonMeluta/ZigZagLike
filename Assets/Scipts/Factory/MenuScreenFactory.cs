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
        //�������� ������������� �� ��������� ������
        menuScreenModel.transitionNextScreen += menuScreenView.ToSwithcScreen;
        menuScreenController = new MenuScreenController(menuScreenModel);
        //����������� ������ �� Controller �� View
        menuScreenView.SetController(menuScreenController);
    }
}
