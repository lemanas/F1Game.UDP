namespace F1Game.UDP.Events;

/// <summary>
/// Represents a start lights event in the F1 game.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct StartLightsEvent() : IByteParsable<StartLightsEvent>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 3;

	/// <summary>
	/// Number of lights showing
	/// </summary>
	public byte NumLights { get; init; }
	/// <summary>
	/// Driver reaction time at race start in milliseconds.
	/// </summary>
	public ushort DriverReactionTimeInMS { get; init; }

	static StartLightsEvent IByteParsable<StartLightsEvent>.Parse(ref BytesReader reader)
	{
		return new()
		{
			NumLights = reader.GetNextByte(),
			DriverReactionTimeInMS = reader.GetNextUShort(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(NumLights);
		writer.Write(DriverReactionTimeInMS);
	}
}
