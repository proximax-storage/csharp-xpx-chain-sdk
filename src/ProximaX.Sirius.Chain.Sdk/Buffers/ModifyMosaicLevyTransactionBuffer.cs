// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace ProximaX.Sirius.Chain.Sdk.Buffers
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct ModifyMosaicLevyTransactionBuffer : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  //public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_2_0_0(); }
  public static ModifyMosaicLevyTransactionBuffer GetRootAsModifyMosaicLevyTransactionBuffer(ByteBuffer _bb) { return GetRootAsModifyMosaicLevyTransactionBuffer(_bb, new ModifyMosaicLevyTransactionBuffer()); }
  public static ModifyMosaicLevyTransactionBuffer GetRootAsModifyMosaicLevyTransactionBuffer(ByteBuffer _bb, ModifyMosaicLevyTransactionBuffer obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public ModifyMosaicLevyTransactionBuffer __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint Size { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public byte Signature(int j) { int o = __p.__offset(6); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int SignatureLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetSignatureBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetSignatureBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetSignatureArray() { return __p.__vector_as_array<byte>(6); }
  public byte Signer(int j) { int o = __p.__offset(8); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int SignerLength { get { int o = __p.__offset(8); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetSignerBytes() { return __p.__vector_as_span<byte>(8, 1); }
#else
  public ArraySegment<byte>? GetSignerBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetSignerArray() { return __p.__vector_as_array<byte>(8); }
  public uint Version { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public ushort Type { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetUshort(o + __p.bb_pos) : (ushort)0; } }
  public uint MaxFee(int j) { int o = __p.__offset(14); return o != 0 ? __p.bb.GetUint(__p.__vector(o) + j * 4) : (uint)0; }
  public int MaxFeeLength { get { int o = __p.__offset(14); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<uint> GetMaxFeeBytes() { return __p.__vector_as_span<uint>(14, 4); }
#else
  public ArraySegment<byte>? GetMaxFeeBytes() { return __p.__vector_as_arraysegment(14); }
#endif
  public uint[] GetMaxFeeArray() { return __p.__vector_as_array<uint>(14); }
  public uint Deadline(int j) { int o = __p.__offset(16); return o != 0 ? __p.bb.GetUint(__p.__vector(o) + j * 4) : (uint)0; }
  public int DeadlineLength { get { int o = __p.__offset(16); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<uint> GetDeadlineBytes() { return __p.__vector_as_span<uint>(16, 4); }
#else
  public ArraySegment<byte>? GetDeadlineBytes() { return __p.__vector_as_arraysegment(16); }
#endif
  public uint[] GetDeadlineArray() { return __p.__vector_as_array<uint>(16); }
  public uint MosaicId(int j) { int o = __p.__offset(18); return o != 0 ? __p.bb.GetUint(__p.__vector(o) + j * 4) : (uint)0; }
  public int MosaicIdLength { get { int o = __p.__offset(18); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<uint> GetMosaicIdBytes() { return __p.__vector_as_span<uint>(18, 4); }
#else
  public ArraySegment<byte>? GetMosaicIdBytes() { return __p.__vector_as_arraysegment(18); }
#endif
  public uint[] GetMosaicIdArray() { return __p.__vector_as_array<uint>(18); }
  public ProximaX.Sirius.Chain.Sdk.Buffers.MosaicLevy? Levy { get { int o = __p.__offset(20); return o != 0 ? (ProximaX.Sirius.Chain.Sdk.Buffers.MosaicLevy?)(new ProximaX.Sirius.Chain.Sdk.Buffers.MosaicLevy()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }

  public static Offset<ModifyMosaicLevyTransactionBuffer> CreateModifyMosaicLevyTransactionBuffer(FlatBufferBuilder builder,
      uint size = 0,
      VectorOffset signatureOffset = default(VectorOffset),
      VectorOffset signerOffset = default(VectorOffset),
      uint version = 0,
      ushort type = 0,
      VectorOffset maxFeeOffset = default(VectorOffset),
      VectorOffset deadlineOffset = default(VectorOffset),
      VectorOffset mosaicIdOffset = default(VectorOffset),
      Offset<MosaicLevy> levyOffset = default(Offset<MosaicLevy>)) {
    builder.StartObject(9);
    ModifyMosaicLevyTransactionBuffer.AddLevy(builder, levyOffset);
    ModifyMosaicLevyTransactionBuffer.AddMosaicId(builder, mosaicIdOffset);
    ModifyMosaicLevyTransactionBuffer.AddDeadline(builder, deadlineOffset);
    ModifyMosaicLevyTransactionBuffer.AddMaxFee(builder, maxFeeOffset);
    ModifyMosaicLevyTransactionBuffer.AddVersion(builder, version);
    ModifyMosaicLevyTransactionBuffer.AddSigner(builder, signerOffset);
    ModifyMosaicLevyTransactionBuffer.AddSignature(builder, signatureOffset);
    ModifyMosaicLevyTransactionBuffer.AddSize(builder, size);
    ModifyMosaicLevyTransactionBuffer.AddType(builder, type);
    return ModifyMosaicLevyTransactionBuffer.EndModifyMosaicLevyTransactionBuffer(builder);
  }

  public static void StartModifyMosaicLevyTransactionBuffer(FlatBufferBuilder builder) { builder.StartObject(9); }
  public static void AddSize(FlatBufferBuilder builder, uint size) { builder.AddUint(0, size, 0); }
  public static void AddSignature(FlatBufferBuilder builder, VectorOffset signatureOffset) { builder.AddOffset(1, signatureOffset.Value, 0); }
  public static VectorOffset CreateSignatureVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateSignatureVectorBlock(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); builder.Add(data); return builder.EndVector(); }
  public static void StartSignatureVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddSigner(FlatBufferBuilder builder, VectorOffset signerOffset) { builder.AddOffset(2, signerOffset.Value, 0); }
  public static VectorOffset CreateSignerVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateSignerVectorBlock(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); builder.Add(data); return builder.EndVector(); }
  public static void StartSignerVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddVersion(FlatBufferBuilder builder, uint version) { builder.AddUint(3, version, 0); }
  public static void AddType(FlatBufferBuilder builder, ushort type) { builder.AddUshort(4, type, 0); }
  public static void AddMaxFee(FlatBufferBuilder builder, VectorOffset maxFeeOffset) { builder.AddOffset(5, maxFeeOffset.Value, 0); }
  public static VectorOffset CreateMaxFeeVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateMaxFeeVectorBlock(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartMaxFeeVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddDeadline(FlatBufferBuilder builder, VectorOffset deadlineOffset) { builder.AddOffset(6, deadlineOffset.Value, 0); }
  public static VectorOffset CreateDeadlineVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateDeadlineVectorBlock(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartDeadlineVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddMosaicId(FlatBufferBuilder builder, VectorOffset mosaicIdOffset) { builder.AddOffset(7, mosaicIdOffset.Value, 0); }
  public static VectorOffset CreateMosaicIdVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateMosaicIdVectorBlock(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartMosaicIdVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddLevy(FlatBufferBuilder builder, Offset<MosaicLevy> levyOffset) { builder.AddOffset(8, levyOffset.Value, 0); }
  public static Offset<ModifyMosaicLevyTransactionBuffer> EndModifyMosaicLevyTransactionBuffer(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<ModifyMosaicLevyTransactionBuffer>(o);
  }
  public static void FinishModifyMosaicLevyTransactionBufferBuffer(FlatBufferBuilder builder, Offset<ModifyMosaicLevyTransactionBuffer> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedModifyMosaicLevyTransactionBufferBuffer(FlatBufferBuilder builder, Offset<ModifyMosaicLevyTransactionBuffer> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
