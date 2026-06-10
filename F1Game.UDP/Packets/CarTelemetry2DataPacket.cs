using F1Game.UDP.Data;

namespace F1Game.UDP.Packets;

/// <summary>
/// This packet contains additional telemetry values for all cars in the session.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly record struct CarTelemetry2DataPacket() : IByteParsable<CarTelemetry2DataPacket>, ISizeable, IByteWritable, IHaveHeader
{
	static int ISizeable.Size => 125;

	/// <inheritdoc/>
	public PacketHeader Header { get; init; }
	/// <summary>
	/// Additional telemetry for all cars in the session.
	/// </summary>
	public Array24<CarTelemetry2Data> CarTelemetry2Data { get; init; }

	static CarTelemetry2DataPacket IByteParsable<CarTelemetry2DataPacket>.Parse(ref BytesReader reader)
	{
		return new()
		{
			Header = reader.GetNextObject<PacketHeader>(),
			CarTelemetry2Data = reader.GetNextObjects<CarTelemetry2Data>(24),
		};
	}

	void IByteWritable.WriteBytes(ref BytesWriter writer)
	{
		writer.Write(Header);
		writer.Write(CarTelemetry2Data.AsReadOnlySpan());
	}
}
