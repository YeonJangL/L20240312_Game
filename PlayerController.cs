using SDL2;

class PlayerController : Component
{
    public SpriteRenderer spriteRenderer;
    public override void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void Update()
    {
        /*if (transform == null)
        {
            return;
        }*/

        int oldx = transform.x;
        int oldy = transform.y;

        if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_a))
        {
            transform.Translate(-1, 0);
        }
        if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_d))
        {
            transform.Translate(1, 0);
        }
        if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_w))
        {
            transform.Translate(0, -1);
        }
        if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_s))
        {
            transform.Translate(0, 1);
        }
        if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_ESCAPE))
        {
            //singleton pattern
            Engine.GetInstance().Stop();
        }

        transform.x = Math.Clamp(transform.x, 0, 80);
        transform.y = Math.Clamp(transform.y, 0, 80);

        // find new x, new y 해당 게임오브젝트 탐색
        // 찾은 게임 오브젝트에서 Collider2D 그리고 충돌 체크

        // Collider2D 컴포넌트를 가진 모든 게임 오브젝트를 찾는다
        // 자기 자신은 제외
        // Player와 충돌 하는 체크
        foreach(GameObject findGameObject in Engine.GetInstance().gameObjects)
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
                if (findComponent.Check(gameObject) && findComponent.isTrigger == true)
                {
                    OnTrigger(findGameObject);
                }
            }
        }
    }

    public void OnTrigger(GameObject other)
    {
        // 겹쳤을때 처리할 로직
        if (other.name == "Monster")
        {
            Engine.GetInstance().Find("GameManager").GetComponent<GameManager>().isGameOver = true;
            // GameOver
        }
        else if (other.name == "Goal")
        {
            Engine.GetInstance().Find("GameManager").GetComponent<GameManager>().isNextStage = true;
            // 다음판
        }
    }
}