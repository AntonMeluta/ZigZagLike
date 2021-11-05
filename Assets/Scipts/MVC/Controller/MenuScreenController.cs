
public class MenuScreenController
{
    private MenuScreenModel menuScreenModel;

    public MenuScreenController(MenuScreenModel model)
    {
        menuScreenModel = model;
    }

    public void UserPressed()
    {
        menuScreenModel.TransitionAction();
    }
}
