namespace F1Game.UDP.Data;

/// <summary>
/// Represents additional telemetry data for a car.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CarTelemetry2Data() : IByteParsable<CarTelemetry2Data>, IByteWritable, ISizeable
{
	static int ISizeable.Size => 4;

	/// <summary>
	/// Active aero mode.
	/// </summary>
	public byte ActiveAeroMode { get; init; }
	/// <summary>
	/// Front active aero status.
	/// </summary>
	public bool FrontActiveAeroEnabled { get; init; }
	/// <summary>
	/// Rear active aero status.
	/// </summary>
	public bool RearActiveAeroEnabled { get; init; }
	/// <summary>
	/// Whether the car is driving the wrong way.
	/// </summary>
	public bool IsDrivingWrongWay { get; init; }

	static CarTelemetry2Data IByteParsable<CarTelemetry2Data>.Parse(ref BytesReader reader)
	{
		return new()
		{
			ActiveAeroMode = reader.GetNextByte(),
			FrontActiveAeroEnabled = reader.GetNextBoolean(),
			RearActiveAeroEnabled = reader.GetNextBoolean(),
			IsDrivingWrongWay = reader.GetNextBoolean(),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(ActiveAeroMode);
		writer.Write(FrontActiveAeroEnabled);
		writer.Write(RearActiveAeroEnabled);
		writer.Write(IsDrivingWrongWay);
	}
}
