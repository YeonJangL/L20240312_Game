class Player : GameObject
{
    public Player()
    {
        shape = 'P';
    }

    public Player(int newX, int newY)
    {
        shape = 'P';
        x = newX;
        y = newY;
    }

    ~Player()
    {

    }

    public override void Start()
    {

    }

    public override void Update()
    {        
        if(Input.GetButton("Up"))
        {
            y--;
        }
        if(Input.GetButton("Left"))
        {
            x--;
        }
        if (Input.GetButton("Down"))
        {
            y++;
        }
        if (Input.GetButton("Right"))
        {
            x++;
        }
        if(Input.GetButton("Quit"))
        {
            engine.Stop();
        }

        x = Math.Clamp(x, 0, 80);
        y = Math.Clamp(y, 0, 80);
    }

    /*public override void Render()
    {
        base.Render(); // base로 재정의 하면서 부모꺼 사용
        // 지금 같은 경우는 재정의 안쓰니까 사용 안하는게 더 빠름
    }*/

}