class Timer
{
    public ulong executeTime = 0;
    protected ulong elapsedTime = 0;

    public delegate void Callback();
    public event Callback callback;

    public Timer(ulong _executeTime, Callback _callback)
    {
        SetTimer(_executeTime, _callback);

        // MethodInfo[] methods = this.GetType().GetMethods();
        // foreach (MethodInfo method in methods)
        // {
        //      method.Nmae == ""
        // }
    }

    public void SetTimer(ulong _executeTime, Callback _callback)
    {
        executeTime = _executeTime;
        callback = _callback;
    }

    public void Update()
    {
        elapsedTime += Engine.GetInstance().deltaTime;
        if (elapsedTime >= executeTime)
        {
            // 실행
            // 함수를 등록해서 그 함수 실행 되게
            callback();
        }
        elapsedTime = 0;
    }
}