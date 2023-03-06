/// <summary>
/// EventCallBack
/// </summary>
public delegate void EventCallBack();
 
/// <summary>
/// EventCallBack<T>
/// </summary>
/// <typeparam name="T"></typeparam>
public delegate void EventCallBack<T>(T arg);
 
/// <summary>
/// EventCallBack<T1, T2>
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
public delegate void EventCallBack<T1, T2>(T1 arg1, T2 arg2);
 
/// <summary>
/// EventCallBack<T1, T2, T3>
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
public delegate void EventCallBack<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);
 
/// <summary>
/// EventCallBack<T1, T2, T3, T4>
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
public delegate void EventCallBack<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);