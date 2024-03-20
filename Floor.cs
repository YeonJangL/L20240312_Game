


class Floor : GameObject
{
    public Floor()
    {
        shape = ' ';
        renderOrder = 10;
    }

    public Floor(int newX, int newY)
    {
        shape = ' ';

        x = newX;
        y = newY;
        renderOrder = 10;
    }

    ~Floor()
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
