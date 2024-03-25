using SDL2;

public enum RenderOder
{
    None = 0,
    Floor = 100,
    Wall = 200,
    Goal = 300,
    Player = 400,
    Monster = 500,
}

class SpriteRenderer : Renderer
{
    public string textureName;

    public SDL.SDL_Color colorKey;

    public bool isMultiple = false;

    public int spriteCount = 0;

    protected int currentIndex = 0;

    public ulong currentTime = 0;

    public ulong executeTime = 250;

    public int currentIndexY = 0;

    /*IntPtr mySurface;
    IntPtr myTexture;*/

    public SpriteRenderer()
    {
        renderOrder = RenderOder.None;
        textureName = "";
        //colorKey = new SDL.SDL_Color();
        colorKey.r = 255;
        colorKey.g = 255;
        colorKey.b = 255;
        colorKey.a = 255;

        /*// LoadTexture
        string Dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        mySurface = SDL.SDL_LoadBMP(Dir + "/data/" + "floor.bmp");
        myTexture = SDL.SDL_CreateTextureFromSurface(Engine.GetInstance().myRenderer, mySurface);*/
    }

    public void Load(string _textureName)
    {
        textureName = _textureName;

        ResourceManager.Load(textureName, colorKey);
    }

    public char Shape;
    public RenderOder renderOrder;

    public override void Update()
    {
        if (isMultiple)
        {
            currentTime += Engine.GetInstance().deltaTime;
            if (currentTime >= executeTime)
            {
                currentIndex++;
                currentIndex %= spriteCount;
                currentTime = 0;
            }
        }
    }

    public override void Render()
    {
        if (transform != null)
        {
            /*Console.SetCursorPosition(transform.x, transform.y);
            Console.Write(Shape);*/

            Engine myEngine = Engine.GetInstance();

            SDL.SDL_Rect destRect = new SDL.SDL_Rect();
            destRect.x = transform.x * 30;
            destRect.y = transform.y * 30;
            destRect.w = 30;
            destRect.h = 30;

            /*if (renderOrder == RenderOder.Floor)
            {
                SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 0, 255, 0, 0);
            }

            else if (renderOrder == RenderOder.Wall)
            {
                SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 255, 255, 0, 0);
            }

            else if (renderOrder == RenderOder.Player)
            {
                SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 0, 0, 255, 0);
            }

            else if (renderOrder == RenderOder.Monster)
            {
                SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 255, 0, 255, 0);
            }

            else if (renderOrder == RenderOder.Goal)
            {
                SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 255, 255, 255, 0);
            }
            // SDL.SDL_RenderFillRect(myEngine.myRenderer, ref myRect);*/

            /*unsafe //C, C++
            {*/
            // SDL.SDL_Surface* surface = (SDL.SDL_Surface*)mySurface;

            SDL.SDL_Rect rect = new SDL.SDL_Rect();
            uint format = 0;
            int access = 0;
            SDL.SDL_QueryTexture(ResourceManager.Find(textureName),
                out format,
                out access,
                out rect.w,
                out rect.h);

            if (isMultiple)
            {
                // animation
                int spriteWidth = rect.w / spriteCount;
                int spriteHeight = rect.h / spriteCount;

                rect.x = spriteWidth * currentIndex;
                rect.y = spriteHeight * currentIndexY;
                rect.w = spriteWidth;
                rect.h = spriteHeight;
            }
            else
            {
                rect.x = 0;
                rect.y = 0;
            }

            /*SDL.SDL_Rect rect = new SDL.SDL_Rect();
            rect.x = 0;
            rect.y = 0;
            rect.w = surface->w;
            rect.h = surface->h;*/

            SDL.SDL_RenderCopy(myEngine.myRenderer, ResourceManager.Find(textureName),
                    ref rect,
                    ref destRect);
            /*}*/
        }
    }
}