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

    }

    /*public override void Render()
    {
        base.Render(); // base로 재정의 하면서 부모꺼 사용
        // 지금 같은 경우는 재정의 안쓰니까 사용 안하는게 더 빠름
    }*/

}