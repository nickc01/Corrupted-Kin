
/// <summary>
/// Used for customizing what areas of the wave are blanked out by the blanking color
/// </summary>

/// <summary>
/// Used for generating waves for the <see cref="WaveSystem"/>
/// </summary>
public interface IWaveGenerator
{
	/// <summary>
	/// The priority of the wave generator. The lower the value, the more likely this wave generator will be run before others
	/// </summary>
	int Priority { get; }

	/// <summary>
	/// Called when the <see cref="IWaveGenerator"/> gets added to an <see cref="WaveSystem"/>
	/// </summary>
	void OnWaveStart(WaveSystem source);

	/// <summary>
	/// Calculates the height value for a particular x value
	/// </summary>
	/// <param name="x">The x value to calculate</param>
	/// <param name="previousValue">The previous value that was at that x position</param>
	/// <returns>The new height value at that x position</returns>
	float Calculate(float x, float previousValue);

	/// <summary>
	/// Called when the <see cref="IWaveGenerator"/> gets removed from an <see cref="WaveSystem"/>
	/// </summary>
	void OnWaveEnd(WaveSystem source);
}
