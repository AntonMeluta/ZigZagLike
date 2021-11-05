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
        //�������� ������������� �� ��������� ������
        crystallCounterModel.EventUpdate += crystallCounterView.UpdateValueOnScreen;
        //������� ��������� ����� ���� �� "�������" �����
        EventsBroker.OnRestartGame += crystallCounterModel.SkipValue;
        crystallCounterController = new CrystallCounterController(crystallCounterModel);
        //����������� ������ �� Controller �� View
        crystallCounterView.SetController(crystallCounterController);
    }
}
