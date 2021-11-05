using System;

public class MenuScreenModel
{
    public Action transitionNextScreen;
    
    public void TransitionAction()
    {
        transitionNextScreen?.Invoke();
    }
}
