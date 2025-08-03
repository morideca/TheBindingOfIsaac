public class PlayerHealthPresenter
{
    private PlayerHealthModel model;
    private PlayerHealthView view;

    public PlayerHealthPresenter(PlayerHealthModel model, PlayerHealthView view)
    {
        this.model = model;
        this.view = view;
        model.OnHealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int currentHealth, int maxHealth)
    {
        view.OnHealthChanged(currentHealth, maxHealth);
    }
}
