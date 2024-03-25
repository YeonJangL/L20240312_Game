class AIController : Component
{
    protected ulong processTime;
    protected ulong ElaspedTime;
    public AIController()
    {
        processTime = 500;
        ElaspedTime = 0;
    }

    public override void Update()
    {
        ElaspedTime += Engine.GetInstance().deltaTime;
        if (ElaspedTime < processTime)
        {
            return;
        }

        ElaspedTime = 0;

        Random random = new Random();
        int oldx = transform.x;
        int oldy = transform.y;

        int NextDirection = random.Next(0, 4);
        if (NextDirection == 0)
        {
            transform.Translate(-1, 0);
        }
        if (NextDirection == 1)
        {
            transform.Translate(1, 0);
        }
        if (NextDirection == 2)
        {
            transform.Translate(0, -1);
        }
        if (NextDirection == 3)
        {
            transform.Translate(0, 1);
        }
        if (NextDirection == 4)
        {
            //singleton pattern
            Engine.GetInstance().Stop();
        }

        transform.x = Math.Clamp(transform.x, 0, 80);
        transform.y = Math.Clamp(transform.y, 0, 80);

        foreach (GameObject findGameObject in Engine.GetInstance().gameObjects)
        {
            if (findGameObject == gameObject)
            {
                continue; // 자신 오브젝트 비교 대상에서 제외하는 코드
            }

            Collider2D? findComponent = findGameObject.GetComponent<Collider2D>();
            if (findComponent != null)
            {
                if (findComponent.Check(gameObject) && findComponent.isTrigger == false)
                {
                    // 충돌
                    transform.x = oldx;
                    transform.y = oldy;
                    break;
                }
            }
        }
    }
}