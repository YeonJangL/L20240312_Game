class Program
{
    static void Main(string[] args)
    {
        Engine engine = new Engine();
        engine.Init();
        engine.Run();
        engine.Term();
    }
}