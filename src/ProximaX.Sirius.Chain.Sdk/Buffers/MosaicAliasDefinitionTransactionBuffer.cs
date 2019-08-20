// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace ProximaX.Sirius.Chain.Sdk.Buffers
{

using global::System;
using global::FlatBuffers;

public struct MosaicAliasDefinitionTransactionBuffer : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static MosaicAliasDefinitionTransactionBuffer GetRootAsMosaicAliasDefinitionTransactionBuffer(ByteBuffer _bb) { return GetRootAsMosaicAliasDefinitionTransactionBuffer(_bb, new MosaicAliasDefinitionTransactionBuffer()); }
  public static MosaicAliasDefinitionTransactionBuffer GetRootAsMosaicAliasDefinitionTransactionBuffer(ByteBuffer _bb, MosaicAliasDefinitionTransactionBuffer obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public MosaicAliasDefinitionTransactionBuffer __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint Size { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public byte Signature(int j) { int o = __p.__offset(6); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int SignatureLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetSignatureBytes() { return __p.__vector_as_span(6); }
#else
  public ArraySegment<byte>? GetSignatureBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetSignatureArray() { return __p.__vector_as_array<byte>(6); }
  public byte Signer(int j) { int o = __p.__offset(8); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int SignerLength { get { int o = __p.__offset(8); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetSignerBytes() { return __p.__vector_as_span(8); }
#else
  public ArraySegment<byte>? GetSignerBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetSignerArray() { return __p.__vector_as_array<byte>(8); }
  public ushort Version { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetUshort(o + __p.bb_pos) : (ushort)0; } }
  public ushort Type { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetUshort(o + __p.bb_pos) : (ushort)0; } }
  public uint Fee(int j) { int o = __p.__offset(14); return o != 0 ? __p.bb.GetUint(__p.__vector(o) + j * 4) : (uint)0; }
  public int FeeLength { get { int o = __p.__offset(14); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetFeeBytes() { return __p.__vector_as_span(14); }
#else
  public ArraySegment<byte>? GetFeeBytes() { return __p.__vector_as_arraysegment(14); }
#endif
  public uint[] GetFeeArray() { return __p.__vector_as_array<uint>(14); }
  public uint Deadline(int j) { int o = __p.__offset(16); return o != 0 ? __p.bb.GetUint(__p.__vector(o) + j * 4) : (uint)0; }
  public int DeadlineLength { get { int o = __p.__offset(16); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetDeadlineBytes() { return __p.__vector_as_span(16); }
#else
  public ArraySegment<byte>? GetDeadlineBytes() { return __p.__vector_as_arraysegment(16); }
#endif
  public uint[] GetDeadlineArray() { return __p.__vector_as_array<uint>(16); }
  public uint NamespaceId(int j) { int o = __p.__offset(18); return o != 0 ? __p.bb.GetUint(__p.__vector(o) + j * 4) : (uint)0; }
  public int NamespaceIdLength { get { int o = __p.__offset(18); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetNamespaceIdBytes() { return __p.__vector_as_span(18); }
#else
  public ArraySegment<byte>? GetNamespaceIdBytes() { return __p.__vector_as_arraysegment(18); }
#endif
  public uint[] GetNamespaceIdArray() { return __p.__vector_as_array<uint>(18); }
  public uint MosaicId(int j) { int o = __p.__offset(20); return o != 0 ? __p.bb.GetUint(__p.__vector(o) + j * 4) : (uint)0; }
  public int MosaicIdLength { get { int o = __p.__offset(20); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetMosaicIdBytes() { return __p.__vector_as_span(20); }
#else
  public ArraySegment<byte>? GetMosaicIdBytes() { return __p.__vector_as_arraysegment(20); }
#endif
  public uint[] GetMosaicIdArray() { return __p.__vector_as_array<uint>(20); }
  public byte AliasAction { get { int o = __p.__offset(22); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }

  public static Offset<MosaicAliasDefinitionTransactionBuffer> CreateMosaicAliasDefinitionTransactionBuffer(FlatBufferBuilder builder,
      uint size = 0,
      VectorOffset signatureOffset = default(VectorOffset),
      VectorOffset signerOffset = default(VectorOffset),
      ushort version = 0,
      ushort type = 0,
      VectorOffset feeOffset = default(VectorOffset),
      VectorOffset deadlineOffset = default(VectorOffset),
      VectorOffset namespaceIdOffset = default(VectorOffset),
      VectorOffset mosaicIdOffset = default(VectorOffset),
      byte aliasAction = 0) {
    builder.StartObject(10);
    MosaicAliasDefinitionTransactionBuffer.AddMosaicId(builder, mosaicIdOffset);
    MosaicAliasDefinitionTransactionBuffer.AddNamespaceId(builder, namespaceIdOffset);
    MosaicAliasDefinitionTransactionBuffer.AddDeadline(builder, deadlineOffset);
    MosaicAliasDefinitionTransactionBuffer.AddFee(builder, feeOffset);
    MosaicAliasDefinitionTransactionBuffer.AddSigner(builder, signerOffset);
    MosaicAliasDefinitionTransactionBuffer.AddSignature(builder, signatureOffset);
    MosaicAliasDefinitionTransactionBuffer.AddSize(builder, size);
    MosaicAliasDefinitionTransactionBuffer.AddType(builder, type);
    MosaicAliasDefinitionTransactionBuffer.AddVersion(builder, version);
    MosaicAliasDefinitionTransactionBuffer.AddAliasAction(builder, aliasAction);
    return MosaicAliasDefinitionTransactionBuffer.EndMosaicAliasDefinitionTransactionBuffer(builder);
  }

  public static void StartMosaicAliasDefinitionTransactionBuffer(FlatBufferBuilder builder) { builder.StartObject(10); }
  public static void AddSize(FlatBufferBuilder builder, uint size) { builder.AddUint(0, size, 0); }
  public static void AddSignature(FlatBufferBuilder builder, VectorOffset signatureOffset) { builder.AddOffset(1, signatureOffset.Value, 0); }
  public static VectorOffset CreateSignatureVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateSignatureVectorBlock(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); builder.Add(data); return builder.EndVector(); }
  public static void StartSignatureVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddSigner(FlatBufferBuilder builder, VectorOffset signerOffset) { builder.AddOffset(2, signerOffset.Value, 0); }
  public static VectorOffset CreateSignerVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateSignerVectorBlock(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); builder.Add(data); return builder.EndVector(); }
  public static void StartSignerVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddVersion(FlatBufferBuilder builder, ushort version) { builder.AddUshort(3, version, 0); }
  public static void AddType(FlatBufferBuilder builder, ushort type) { builder.AddUshort(4, type, 0); }
  public static void AddFee(FlatBufferBuilder builder, VectorOffset feeOffset) { builder.AddOffset(5, feeOffset.Value, 0); }
  public static VectorOffset CreateFeeVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateFeeVectorBlock(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartFeeVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddDeadline(FlatBufferBuilder builder, VectorOffset deadlineOffset) { builder.AddOffset(6, deadlineOffset.Value, 0); }
  public static VectorOffset CreateDeadlineVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateDeadlineVectorBlock(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartDeadlineVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddNamespaceId(FlatBufferBuilder builder, VectorOffset namespaceIdOffset) { builder.AddOffset(7, namespaceIdOffset.Value, 0); }
  public static VectorOffset CreateNamespaceIdVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateNamespaceIdVectorBlock(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartNamespaceIdVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddMosaicId(FlatBufferBuilder builder, VectorOffset mosaicIdOffset) { builder.AddOffset(8, mosaicIdOffset.Value, 0); }
  public static VectorOffset CreateMosaicIdVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateMosaicIdVectorBlock(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartMosaicIdVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddAliasAction(FlatBufferBuilder builder, byte aliasAction) { builder.AddByte(9, aliasAction, 0); }
  public static Offset<MosaicAliasDefinitionTransactionBuffer> EndMosaicAliasDefinitionTransactionBuffer(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<MosaicAliasDefinitionTransactionBuffer>(o);
  }
  public static void FinishMosaicAliasDefinitionTransactionBufferBuffer(FlatBufferBuilder builder, Offset<MosaicAliasDefinitionTransactionBuffer> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedMosaicAliasDefinitionTransactionBufferBuffer(FlatBufferBuilder builder, Offset<MosaicAliasDefinitionTransactionBuffer> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
