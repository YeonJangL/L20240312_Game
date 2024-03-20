


class Goal : GameObject
{
    public Goal()
    {
        shape = 'G';
        renderOrder = 100;
    }

    public Goal(int newX, int newY)
    {
        shape = 'G';

        x = newX;
        y = newY;
        renderOrder = 100;
    }

    ~Goal()
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
