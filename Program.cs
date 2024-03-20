using System.Reflection;

class Program
{
    //객체 한개 존재
    /*class Singleton
    {
        private Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }

        private static Singleton? instance;

        public void Draw()
        {

        }
    }*/

    static void Main(string[] args)
    {
        /*int[] number = { 10, 7, 3, 4, 2, 5, 8, 6, 1, 9 };

        for (int i = 0; i < number.Length; i++)
        {
            for (int j = i + 1; j < number.Length; j++)
            {
                if (number[i] > number[j])
                {
                    int temp = number[i];
                    number[i] = number[j];
                    number[j] = temp;
                }
            }
        }

        foreach (int i in number)
        {
            Console.WriteLine(i);
        }*/

        Engine engine = Engine.GetInstance();

        engine.Init();
        engine.LoadScene("level01.map");
        engine.Run();
        engine.Term();
    }
}