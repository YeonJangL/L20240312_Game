


class Monster : GameObject
{
    public Monster()
    {
        shape = 'M';

        renderOrder = 1000 + 1;
    }

    public Monster(int newX, int newY)
    {
        shape = 'M';

        x = newX;
        y = newY;

        renderOrder = 1000 + 1;
    }

    ~Monster()
    {

    }

    public override void Start()
    {

    }

    public override void Update()
    {

    }

    public override void Render()
    {
        base.Render();
    }
}
