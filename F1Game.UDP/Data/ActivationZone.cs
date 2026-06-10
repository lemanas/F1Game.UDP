namespace F1Game.UDP.Data;

/// <summary>
/// Represents an activation zone around the circuit.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct ActivationZone() : IByteParsable<ActivationZone>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 9;

	/// <summary>
	/// Distance in metres around the lap where the zone starts.
	/// </summary>
	public float StartLapDistance { get; init; }
	/// <summary>
	/// Length of the zone in metres.
	/// </summary>
	public float Length { get; init; }
	/// <summary>
	/// Type of activation zone.
	/// </summary>
	public byte Type { get; init; }

	static ActivationZone IByteParsable<ActivationZone>.Parse(ref BytesReader reader)
	{
		return new()
		{
			StartLapDistance = reader.GetNextFloat(),
			Length = reader.GetNextFloat(),
			Type = reader.GetNextByte(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(StartLapDistance);
		writer.Write(Length);
		writer.Write(Type);
	}
}
