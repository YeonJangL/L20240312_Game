class GameObject
{
    public int x;
    public int y;

    public GameObject() // 생성자 무조건 생성!
    {
        x = 0;
        y = 0;
    }
    ~GameObject() // 소멸자도!
    {

    }
    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Render()
    {

    }

    public char shape;                                                             
}