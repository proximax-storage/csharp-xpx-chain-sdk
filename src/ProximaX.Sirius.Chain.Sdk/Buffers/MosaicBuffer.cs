// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace ProximaX.Sirius.Chain.Sdk.Buffers
{

using global::System;
using global::FlatBuffers;

public struct MosaicBuffer : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static MosaicBuffer GetRootAsMosaicBuffer(ByteBuffer _bb) { return GetRootAsMosaicBuffer(_bb, new MosaicBuffer()); }
  public static MosaicBuffer GetRootAsMosaicBuffer(ByteBuffer _bb, MosaicBuffer obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public MosaicBuffer __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint Id(int j) { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(__p.__vector(o) + j * 4) : (uint)0; }
  public int IdLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetIdBytes() { return __p.__vector_as_span(4); }
#else
  public ArraySegment<byte>? GetIdBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public uint[] GetIdArray() { return __p.__vector_as_array<uint>(4); }
  public uint Amount(int j) { int o = __p.__offset(6); return o != 0 ? __p.bb.GetUint(__p.__vector(o) + j * 4) : (uint)0; }
  public int AmountLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetAmountBytes() { return __p.__vector_as_span(6); }
#else
  public ArraySegment<byte>? GetAmountBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public uint[] GetAmountArray() { return __p.__vector_as_array<uint>(6); }

  public static Offset<MosaicBuffer> CreateMosaicBuffer(FlatBufferBuilder builder,
      VectorOffset idOffset = default(VectorOffset),
      VectorOffset amountOffset = default(VectorOffset)) {
    builder.StartObject(2);
    MosaicBuffer.AddAmount(builder, amountOffset);
    MosaicBuffer.AddId(builder, idOffset);
    return MosaicBuffer.EndMosaicBuffer(builder);
  }

  public static void StartMosaicBuffer(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddId(FlatBufferBuilder builder, VectorOffset idOffset) { builder.AddOffset(0, idOffset.Value, 0); }
  public static VectorOffset CreateIdVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateIdVectorBlock(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartIdVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddAmount(FlatBufferBuilder builder, VectorOffset amountOffset) { builder.AddOffset(1, amountOffset.Value, 0); }
  public static VectorOffset CreateAmountVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateAmountVectorBlock(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartAmountVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<MosaicBuffer> EndMosaicBuffer(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<MosaicBuffer>(o);
  }
};


}
