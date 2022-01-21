public class IngameDialogue {
    
    //Zone start and ends
    public const int LEVEL_1_START = 10;
    public const int LEVEL_1_END = 11;
    public const int LEVEL_2_START = 20;
    public const int LEVEL_2_END = 21;

    //Event dialogues
    public const int TUTORIAL_CURVE_FAIL = -1;
    public const int TUTORIAL_CURVE = -2;
    public const int TUTORIAL_FRAGMENT = -3;
    public const int TUTORIAL_HARD_CURVE = -4;
    public const int TUTORIAL_BOOST_BRAKE = -5;
    public const int TUTORIAL_SPLIT = -6;
    public const int TUTORIAL_PROTOCOL = -7;
    public const int TUTORIAL_END = -8;
    public const int TUTORIAL_BOOSTER_PAD = -9;
    public const int TUTORIAL_BRAKING_PAD = -10;

    public static int GetEndDialogue(int levelId) {
        return levelId * 10 + 1;
    }

    public static int GetStartDialogue(int levelId) {
        return levelId * 10;
    }

}
