using SDL2;
using System.Data;

class Engine
{   
    protected Engine()
    {
        gameObjects = new List<GameObject>();
        isRunning = true;
    }

    ~Engine()
    {

    }

    public static Engine? instance;

    public static Engine GetInstance()
    {
        if (instance == null)
        {
            instance = new Engine();
        }
        return instance;
        // return instance ?? (instance = new Engine()); // 사망문 return instance == null ? (instance = new Engine()) : instance; 이거 줄인거
    }

    public List<GameObject> gameObjects;
    public bool isRunning;

    public bool isNextLoading = false;
    public string nextSceneName = string.Empty;

    public IntPtr myWindow;
    public IntPtr myRenderer;
    public SDL.SDL_Event myEvent;

    public ulong deltaTime;
    protected ulong lastTime;

    public void NextLoadScene(string _nextSceneName)
    {
        isNextLoading = true;
        nextSceneName = _nextSceneName;
    }


    public void Init()
    {
        if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
        {
            Console.WriteLine("Init fail.");
        }

        myWindow = SDL.SDL_CreateWindow("2D Engine", 100, 100, 640, 480, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

        myRenderer = SDL.SDL_CreateRenderer(myWindow, -1,
            SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
            SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC |
            SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE);

        Input.Init();
    }

    public void Stop()
    {
        isRunning = false;
    }

    public void LoadScene(string sceneName)
    {
#if DEBUG
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        string Dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        string[] map = File.ReadAllLines(Dir + "/data/" + sceneName);
#else
        string Dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        string[] map = File.ReadAllLines(Dir + "/data/" + sceneName);
#endif

        //string[] map = File.ReadAllLines("./data/"+sceneName);

        GameObject newGameObject;

        for (int y = 0; y < map.Length; ++y)
        {
            for (int x = 0; x < map[y].Length; ++x)
            {
                if (map[y][x] == '*')
                {
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Wall";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = '*';
                    renderer.Load("wall.bmp");
                    renderer.renderOrder = RenderOder.Wall;
                    newGameObject.AddComponent<Collider2D>();

                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = ' ';
                    renderer.Load("floor.bmp");
                    renderer.renderOrder = RenderOder.Floor;
                    //Instantiate(new Wall(x, y));
                    //Instantiate(new Floor(x, y));
                    //newGameObject.x = x;
                    //newGameObject.y = y;
                }
                else if (map[y][x] == ' ')
                {
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = ' ';
                    renderer.Load("floor.bmp");
                    renderer.renderOrder = RenderOder.Floor;
                    //Instantiate(new Floor(x, y));
                }
                else if (map[y][x] == 'P')
                {
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Player";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = 'P';
                    renderer.colorKey.g = 0;
                    renderer.Load("test.bmp");
                    renderer.isMultiple = true;
                    renderer.spriteCount = 5;

                    renderer.renderOrder = RenderOder.Player;
                    newGameObject.AddComponent<PlayerController>();
                    Collider2D collider2D = newGameObject.AddComponent<Collider2D>();
                    collider2D.isTrigger = true;

                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = ' ';
                    renderer.Load("floor.bmp");
                    renderer.renderOrder = RenderOder.Floor;

                    //Instantiate(new Player(x, y));
                    //Instantiate(new Floor(x, y));

                }
                else if (map[y][x] == 'G')
                {
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Goal";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = 'G';
                    renderer.Load("coin.bmp");
                    renderer.renderOrder = RenderOder.Goal;
                    Collider2D collider2D = newGameObject.AddComponent<Collider2D>();
                    collider2D.isTrigger = true;

                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = ' ';
                    renderer.Load("floor.bmp");
                    renderer.renderOrder = RenderOder.Floor;
                    //Instantiate(new Goal(x, y));
                    //Instantiate(new Floor(x, y));

                }
                else if (map[y][x] == 'M')
                {
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Monster";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.renderOrder = RenderOder.Monster;
                    renderer.Shape = 'M';
                    renderer.Load("slime.bmp");
                    Collider2D collider2D = newGameObject.AddComponent<Collider2D>();
                    collider2D.isTrigger = true;
                    newGameObject.AddComponent<AIController>();

                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = ' ';
                    renderer.Load("floor.bmp");
                    renderer.renderOrder = RenderOder.Floor;
                    //Instantiate(new Monster(x, y));
                    //Instantiate(new Floor(x, y));

                }
            }
        }

        //gameObjects.Sort();

        //int WallCount = 0;
        //foreach (GameObject go in gameObjects)
        //{
        //    //reflection
        //    if (go.GetType() == typeof(Player))
        //    {
        //        WallCount++;
        //    }
        //}
        //Console.WriteLine(WallCount);

        newGameObject = Instantiate<GameObject>();
        newGameObject.name = "GameManager";
        newGameObject.AddComponent<GameManager>();

        RenderSort();
    }

    public void RenderSort()
    {
        // gameObjects
        
        // int[] number = { 10, 7, 3, 4, 2, 5, 8, 6, 1, 9 };

        for (int i = 0; i < gameObjects.Count; i++)
        {
            for (int j = i + 1; j < gameObjects.Count; j++)
            {
                SpriteRenderer? prevRender = gameObjects[i].GetComponent<SpriteRenderer>();
                SpriteRenderer? nextRender = gameObjects[j].GetComponent<SpriteRenderer>();

                if (prevRender != null && nextRender != null)
                {
                    if ((int)prevRender.renderOrder > (int)nextRender.renderOrder)
                    {
                        GameObject temp = gameObjects[i];
                        gameObjects[i] = gameObjects[j];
                        gameObjects[j] = temp;
                    }
                }
            }
        }
    }

    public void Run()
    {
        bool isFirst = true;
        while (isRunning)
        {
            if (isFirst)
            {
                StartInAllComponents();
                isFirst = false;
            }
            ProcessInput();
            Update();
            Render();
            if (isNextLoading)
            {
                gameObjects.Clear();
                LoadScene(nextSceneName);
                isNextLoading = false;
                nextSceneName = string.Empty;
            }
        } //frame
    }

    protected void StartInAllComponents()
    {
        foreach(GameObject gameObject in gameObjects)
        {
            foreach(Component component in gameObject.components)
            {
                component.Start();
            }
        }
    }

    public void Term()
    {
        gameObjects.Clear();

        SDL.SDL_DestroyRenderer(myRenderer);
        SDL.SDL_DestroyWindow(myWindow);
        SDL.SDL_Quit();
    }

    public T Instantiate<T>() where T : GameObject, new()
    {
        T newObject = new T();
        gameObjects.Add( newObject );

        return newObject;
    }

    /*public GameObject Instantiate(GameObject newGameObject)
    {
        gameObjects.Add(newGameObject);

        return newGameObject;
    }*/

    protected void ProcessInput()
    {
        SDL.SDL_PollEvent(out myEvent);
        // Input.keyInfo = Console.ReadKey();
    }

    protected void Update()
    {
        deltaTime = SDL.SDL_GetTicks64() - lastTime;
        // Console.WriteLine(deltaTime);
        foreach (GameObject gameObject in gameObjects)
        {
            foreach (Component component in gameObject.components)
            {
                component.Update();
            }
        }
        lastTime = SDL.SDL_GetTicks64();

        /*foreach (GameObject gameObject in gameObjects)
        {
            gameObject.Update();
        }*/
    }

    protected void Render()
    {
        //for(int i = 0; i < gameObjects.Count; i++)
        //{
        //    gameObjects[i].Render();
        //}
        // Console.Clear();
        foreach (GameObject gameObject in gameObjects)
        {
            Renderer? renderer = gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.Render();
            }
        }

        SDL.SDL_RenderPresent(Engine.GetInstance().myRenderer);
    }

    public GameObject? Find(string name)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.name == name)
            {
                return gameObject;
            }
        }

        return null;
    }
}