class GameManager : Component
{
    public bool isGameOver;
    public bool isNextStage;

    public GameManager()
    {
        isGameOver = false;
        isNextStage = false;
    }

    public override void Update()
    {
        if (isGameOver)
        {
            Engine.GetInstance().Stop();
            Console.Clear();
            Console.WriteLine("GameOver");
        }

        if (isNextStage)
        {
            Console.Clear();
            Console.WriteLine("Cougraturation.");
            Console.ReadKey();
            Engine.GetInstance().NextLoadScene("level02.map");

            //Engine.GetInstance().Term();
            //Engine.GetInstance().LoadScene("level02.map");
        }
    }
}