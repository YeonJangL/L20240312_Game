class Component
{
    public Component()
    {
        //gameObject = new GameObject();
        //transform = new Transform();
    }

    ~Component()
    {

    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

    // 내가 어디 속해있는지 확인하는 용도
    public GameObject gameObject;

    // 내가 속해있는 게임오브젝트의 이동 처리하기 위한 용도
    public Transform transform;
}
