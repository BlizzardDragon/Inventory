using System;

[Serializable]
public sealed class IntCharacterStats : Parameter<int, CharacterStatsTypes>
{
    public IntCharacterStats()
    {
    }

    public IntCharacterStats(CharacterStatsTypes name, int value) : base(name, value)
    {
    }
}

[Serializable]
public sealed class FloatCharacterStats : Parameter<float, CharacterStatsTypes>
{
    public FloatCharacterStats()
    {
    }

    public FloatCharacterStats(CharacterStatsTypes name, float value) : base(name, value)
    {
    }
}

[Serializable]
public sealed class StringCharacterStats : Parameter<string, CharacterStatsTypes>
{
    public StringCharacterStats()
    {
    }

    public StringCharacterStats(CharacterStatsTypes name, string value) : base(name, value)
    {
    }
}
