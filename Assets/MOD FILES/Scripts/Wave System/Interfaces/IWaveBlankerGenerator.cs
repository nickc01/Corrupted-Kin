
/// <summary>
/// Used for customizing what areas of the wave are blanked out by the blanking color
/// </summary>
public interface IWaveBlankerGenerator
{
	int Priority { get; }

	float GetBlankingColorAtPos(float x, float previousValue);
}
