class Engine
{
    public Engine()
    {
        gameObjects = new List<GameObject>();
        isRunning = true;
    }
    ~Engine()
    {

    }

    public List<GameObject> gameObjects;
    public bool isRunning;

    public void Init()
    {        
        Input.Init();
        // Load();
    }

    public void LoadScene(string sceneName)
    {
        /*string[] map = new string[10];
        // flie로 읽어온다   
        map[0] = "**********";
        map[1] = "*P       *";
        map[2] = "*        *";
        map[3] = "*        *";
        map[4] = "*   M    *";
        map[5] = "*        *";
        map[6] = "*        *";
        map[7] = "*        *";
        map[8] = "*       G*";
        map[9] = "**********";*/

#if DEBUG
        string Dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        string[] map = File.ReadAllLines(Dir + "/data/" + sceneName);
#else
        string Dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        string[] map = File.ReadAllLines(Dir + "/data/" + sceneName);
#endif


        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == '*')
                {
                    Instantiate(new Wall(x, y));
                    Instantiate(new Floor(x, y));
                    /*newGameObject.x = x;
                    newGameObject.y = y;*/
                }
                else if (map[y][x] == ' ')
                {
                    Instantiate(new Floor(x, y));
                }
                else if (map[y][x] == 'P')
                {
                    Instantiate(new Player(x, y));
                    Instantiate(new Floor(x, y));
                }
                else if (map[y][x] == 'G')
                {
                    Instantiate(new Goal(x, y));
                    Instantiate(new Floor(x, y));
                }
                else if (map[y][x] == 'M')
                {
                    Instantiate(new Monster(x, y));
                    Instantiate(new Floor(x, y));
                }
            }
        }

        // gameObjects.Sort()
    }

    public void Run()
    {
        while (isRunning)
        {
            ProcessInput();
            Update();
            Render();
        } // frame
    }

    public void Term()
    {
        gameObjects.Clear();
    }

    /*public GameObject Instanticate<T>() where T : GameObject
    {
        return new T();
    }*/

    public GameObject Instantiate(GameObject newGameObject)
    {
        gameObjects.Add(newGameObject);

        return newGameObject;
    }

    protected void ProcessInput() // private는 상속을 못받음
    {
        Input.keyInfo = Console.ReadKey();
    }

    protected void Update()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.Update();
        }
    }

    protected void Render()
    {
        /*for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].Render();
        }*/

        Console.Clear();
        foreach(GameObject gameObject in gameObjects)
        {
            gameObject.Render();
        }
    }
}