
/// <summary>
/// Used for customizing what areas of the wave are blanked out by the blanking color
/// </summary>
public interface IWaveBlankerGenerator
{
	/// <summary>
	/// The priority of the blanker generator. The lower the value, the more likely this blanker generator will be run before others
	/// </summary>
	int Priority { get; }

	/// <summary>
	/// Determines the blanking color at a specific x position
	/// </summary>
	/// <param name="x">The world-x position on the wave</param>
	/// <param name="previousValue">The previous blanking color at that wave position</param>
	/// <returns>The new blanking color that should be set at that wave position</returns>
	float GetBlankingColorAtPos(float x, float previousValue);
}
