class GameManager : Component
{
    public bool isGameOver;
    public bool isNextStage;

    protected Timer gameOverTimer;
    protected Timer CompleteTimer;

    public int Gold;

    public GameManager()
    {
        isGameOver = false;
        isNextStage = false;

        // 로딩 다 되면 모 해줘..?
        gameOverTimer = new Timer(3000, () =>
        {
            ProcessGameOver();
        });

        // gameOverTimer.callback = () => { };

        // gameOverTimer.callback += ProcessComplete;

        CompleteTimer = new Timer(2000, ProcessComplete);

        // gameOverTimer.callback = ProcessGameOver;
    }

    public void ProcessGameOver()
    {
        Engine.GetInstance().Stop();
        Console.Clear();
        Console.WriteLine("Gameover");
    }

    public void ProcessComplete()
    {
        Console.Clear();
        Console.WriteLine("Congraturation.");
        Engine.GetInstance().NextLoadScene("level02.map");
    }

    public override void Update()
    {
        if (isGameOver)
        {
            gameOverTimer.Update();
        }

        if (isNextStage)
        {
            

            //Engine.GetInstance().Term();
            //Engine.GetInstance().LoadScene("level02.map");
        }
    }
}