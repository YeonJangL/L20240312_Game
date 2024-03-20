


class Player : GameObject
{
    public Player()
    {
        shape = 'P';
        renderOrder = 1000;
    }

    public Player(int newX, int newY)
    {
        shape = 'P';

        x = newX;
        y = newY;
        renderOrder = 1000;
    }

    ~Player()
    {

    }

    public override void Start()
    {

    }

    public override void Update()
    {
        if (Input.GetButton("Left"))
        {
            x--;
        }
        if (Input.GetButton("Right"))
        {
            x++;
        }
        if (Input.GetButton("Up"))
        {
            y--;
        }
        if (Input.GetButton("Down"))
        {
            y++;
        }
        if (Input.GetButton("Quit"))
        {
            //singleton pattern
            Engine.GetInstance().Stop();
        }

        x = Math.Clamp(x, 0, 80);
        y = Math.Clamp(y, 0, 80);
    }
}
