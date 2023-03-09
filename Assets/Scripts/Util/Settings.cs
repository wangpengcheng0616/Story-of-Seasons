using System;

public class Settings
{
    //Version
    public const string version = "1.0.0";

    // ItemFade
    public const float fadeInDuration = 0.4f;
    public const float fadeOutDuration = 0.4f;
    public const float fadeInAlpha = 0.4f;
    public const float fadeOutAlpha = 1f;

    // GameTime
    public const float secondThreshold = 0.01f;
    public const int secondHold = 59;
    public const int minuteHold = 59;
    public const int hourHold = 23;
    public const int dayHold = 30;
    public const int seasonHold = 3;
    public const int startGameYear = 2023;
    public const int startGameHour = 16;

    // Scene
    public const string uiScene = "UIScene";
    public const string fieldScene = "FieldScene";
    public const string housecene = "HouseScene";

    //Light TODO: According to Season
    public const float lightDuration = 240f;
    public static LightType startLightType = LightType.Morning;
    public static TimeSpan morningTime = new TimeSpan(4, 0, 0);
    public static TimeSpan nightTime = new TimeSpan(17, 0, 0);
}