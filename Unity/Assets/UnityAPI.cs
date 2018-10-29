// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: UnityAPI.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace UnitiyAPI {

  /// <summary>Holder for reflection information generated from UnityAPI.proto</summary>
  public static partial class UnityAPIReflection {

    #region Descriptor
    /// <summary>File descriptor for UnityAPI.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static UnityAPIReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg5Vbml0eUFQSS5wcm90bxIJVW5pdGl5QVBJIuwBChJVbml0eUdsb2JhbENv",
            "bW1hbmQSKQoHb3BfY29kZRgBIAEoDjIYLlVuaXRpeUFQSS5Db21tYW5kT3BD",
            "b2RlEjYKEW9iamVjdF9tYW5hZ2VtZW50GAIgASgLMhsuVW5pdGl5QVBJLk9i",
            "amVjdE1hbmFnZW1lbnQSKgoLY2FtZXJhX3ZpZXcYAyABKA4yFS5Vbml0aXlB",
            "UEkuQ2FtZXJhVmlldxJHChp0YWN0aWNhbF9vYmplY3RfbWFuYWdlbWVudBgE",
            "IAEoCzIjLlVuaXRpeUFQSS5UYWN0aWNhbE9iamVjdE1hbmFnZW1lbnQiawoQ",
            "T2JqZWN0TWFuYWdlbWVudBIvCgdvcF9jb2RlGAEgASgOMh4uVW5pdGl5QVBJ",
            "Lk9iamVjdENvbnRyb2xPcENvZGUSEwoLb2JqZWN0X3R5cGUYAiABKAUSEQoJ",
            "aGlnaGxpZ2h0GAMgASgIIkwKGFRhY3RpY2FsT2JqZWN0TWFuYWdlbWVudBIw",
            "CgdvcF9jb2RlGAEgASgOMh8uVW5pdGl5QVBJLlRhY3RpY2FsT2JqZWN0T3BD",
            "b2RlKk8KDUNvbW1hbmRPcENvZGUSFQoRT0JKRUNUX01BTkFHRU1FTlQQABIS",
            "Cg5DQU1FUkFfQ09OVFJPTBABEhMKD1RBQ1RJQ0FMX09CSkVDVBACKioKCkNh",
            "bWVyYVZpZXcSDQoJUExBTl9WSUVXEAASDQoJRlJFRV9MT09LEAEqNQoTT2Jq",
            "ZWN0Q29udHJvbE9wQ29kZRIHCgNBREQQABIVChFISUdITElHSFRfT0JKRUNU",
            "UxABKigKFFRhY3RpY2FsT2JqZWN0T3BDb2RlEhAKDENSRUFURV9ST1VURRAA",
            "YgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::UnitiyAPI.CommandOpCode), typeof(global::UnitiyAPI.CameraView), typeof(global::UnitiyAPI.ObjectControlOpCode), typeof(global::UnitiyAPI.TacticalObjectOpCode), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::UnitiyAPI.UnityGlobalCommand), global::UnitiyAPI.UnityGlobalCommand.Parser, new[]{ "OpCode", "ObjectManagement", "CameraView", "TacticalObjectManagement" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::UnitiyAPI.ObjectManagement), global::UnitiyAPI.ObjectManagement.Parser, new[]{ "OpCode", "ObjectType", "Highlight" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::UnitiyAPI.TacticalObjectManagement), global::UnitiyAPI.TacticalObjectManagement.Parser, new[]{ "OpCode" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum CommandOpCode {
    [pbr::OriginalName("OBJECT_MANAGEMENT")] ObjectManagement = 0,
    [pbr::OriginalName("CAMERA_CONTROL")] CameraControl = 1,
    [pbr::OriginalName("TACTICAL_OBJECT")] TacticalObject = 2,
  }

  public enum CameraView {
    [pbr::OriginalName("PLAN_VIEW")] PlanView = 0,
    [pbr::OriginalName("FREE_LOOK")] FreeLook = 1,
  }

  public enum ObjectControlOpCode {
    [pbr::OriginalName("ADD")] Add = 0,
    [pbr::OriginalName("HIGHLIGHT_OBJECTS")] HighlightObjects = 1,
  }

  public enum TacticalObjectOpCode {
    [pbr::OriginalName("CREATE_ROUTE")] CreateRoute = 0,
  }

  #endregion

  #region Messages
  public sealed partial class UnityGlobalCommand : pb::IMessage<UnityGlobalCommand> {
    private static readonly pb::MessageParser<UnityGlobalCommand> _parser = new pb::MessageParser<UnityGlobalCommand>(() => new UnityGlobalCommand());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<UnityGlobalCommand> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::UnitiyAPI.UnityAPIReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UnityGlobalCommand() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UnityGlobalCommand(UnityGlobalCommand other) : this() {
      opCode_ = other.opCode_;
      objectManagement_ = other.objectManagement_ != null ? other.objectManagement_.Clone() : null;
      cameraView_ = other.cameraView_;
      tacticalObjectManagement_ = other.tacticalObjectManagement_ != null ? other.tacticalObjectManagement_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UnityGlobalCommand Clone() {
      return new UnityGlobalCommand(this);
    }

    /// <summary>Field number for the "op_code" field.</summary>
    public const int OpCodeFieldNumber = 1;
    private global::UnitiyAPI.CommandOpCode opCode_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::UnitiyAPI.CommandOpCode OpCode {
      get { return opCode_; }
      set {
        opCode_ = value;
      }
    }

    /// <summary>Field number for the "object_management" field.</summary>
    public const int ObjectManagementFieldNumber = 2;
    private global::UnitiyAPI.ObjectManagement objectManagement_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::UnitiyAPI.ObjectManagement ObjectManagement {
      get { return objectManagement_; }
      set {
        objectManagement_ = value;
      }
    }

    /// <summary>Field number for the "camera_view" field.</summary>
    public const int CameraViewFieldNumber = 3;
    private global::UnitiyAPI.CameraView cameraView_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::UnitiyAPI.CameraView CameraView {
      get { return cameraView_; }
      set {
        cameraView_ = value;
      }
    }

    /// <summary>Field number for the "tactical_object_management" field.</summary>
    public const int TacticalObjectManagementFieldNumber = 4;
    private global::UnitiyAPI.TacticalObjectManagement tacticalObjectManagement_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::UnitiyAPI.TacticalObjectManagement TacticalObjectManagement {
      get { return tacticalObjectManagement_; }
      set {
        tacticalObjectManagement_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as UnityGlobalCommand);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(UnityGlobalCommand other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (OpCode != other.OpCode) return false;
      if (!object.Equals(ObjectManagement, other.ObjectManagement)) return false;
      if (CameraView != other.CameraView) return false;
      if (!object.Equals(TacticalObjectManagement, other.TacticalObjectManagement)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (OpCode != 0) hash ^= OpCode.GetHashCode();
      if (objectManagement_ != null) hash ^= ObjectManagement.GetHashCode();
      if (CameraView != 0) hash ^= CameraView.GetHashCode();
      if (tacticalObjectManagement_ != null) hash ^= TacticalObjectManagement.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (OpCode != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) OpCode);
      }
      if (objectManagement_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(ObjectManagement);
      }
      if (CameraView != 0) {
        output.WriteRawTag(24);
        output.WriteEnum((int) CameraView);
      }
      if (tacticalObjectManagement_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(TacticalObjectManagement);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (OpCode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) OpCode);
      }
      if (objectManagement_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ObjectManagement);
      }
      if (CameraView != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) CameraView);
      }
      if (tacticalObjectManagement_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(TacticalObjectManagement);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(UnityGlobalCommand other) {
      if (other == null) {
        return;
      }
      if (other.OpCode != 0) {
        OpCode = other.OpCode;
      }
      if (other.objectManagement_ != null) {
        if (objectManagement_ == null) {
          objectManagement_ = new global::UnitiyAPI.ObjectManagement();
        }
        ObjectManagement.MergeFrom(other.ObjectManagement);
      }
      if (other.CameraView != 0) {
        CameraView = other.CameraView;
      }
      if (other.tacticalObjectManagement_ != null) {
        if (tacticalObjectManagement_ == null) {
          tacticalObjectManagement_ = new global::UnitiyAPI.TacticalObjectManagement();
        }
        TacticalObjectManagement.MergeFrom(other.TacticalObjectManagement);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            opCode_ = (global::UnitiyAPI.CommandOpCode) input.ReadEnum();
            break;
          }
          case 18: {
            if (objectManagement_ == null) {
              objectManagement_ = new global::UnitiyAPI.ObjectManagement();
            }
            input.ReadMessage(objectManagement_);
            break;
          }
          case 24: {
            cameraView_ = (global::UnitiyAPI.CameraView) input.ReadEnum();
            break;
          }
          case 34: {
            if (tacticalObjectManagement_ == null) {
              tacticalObjectManagement_ = new global::UnitiyAPI.TacticalObjectManagement();
            }
            input.ReadMessage(tacticalObjectManagement_);
            break;
          }
        }
      }
    }

  }

  public sealed partial class ObjectManagement : pb::IMessage<ObjectManagement> {
    private static readonly pb::MessageParser<ObjectManagement> _parser = new pb::MessageParser<ObjectManagement>(() => new ObjectManagement());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ObjectManagement> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::UnitiyAPI.UnityAPIReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ObjectManagement() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ObjectManagement(ObjectManagement other) : this() {
      opCode_ = other.opCode_;
      objectType_ = other.objectType_;
      highlight_ = other.highlight_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ObjectManagement Clone() {
      return new ObjectManagement(this);
    }

    /// <summary>Field number for the "op_code" field.</summary>
    public const int OpCodeFieldNumber = 1;
    private global::UnitiyAPI.ObjectControlOpCode opCode_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::UnitiyAPI.ObjectControlOpCode OpCode {
      get { return opCode_; }
      set {
        opCode_ = value;
      }
    }

    /// <summary>Field number for the "object_type" field.</summary>
    public const int ObjectTypeFieldNumber = 2;
    private int objectType_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ObjectType {
      get { return objectType_; }
      set {
        objectType_ = value;
      }
    }

    /// <summary>Field number for the "highlight" field.</summary>
    public const int HighlightFieldNumber = 3;
    private bool highlight_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Highlight {
      get { return highlight_; }
      set {
        highlight_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ObjectManagement);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ObjectManagement other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (OpCode != other.OpCode) return false;
      if (ObjectType != other.ObjectType) return false;
      if (Highlight != other.Highlight) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (OpCode != 0) hash ^= OpCode.GetHashCode();
      if (ObjectType != 0) hash ^= ObjectType.GetHashCode();
      if (Highlight != false) hash ^= Highlight.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (OpCode != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) OpCode);
      }
      if (ObjectType != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(ObjectType);
      }
      if (Highlight != false) {
        output.WriteRawTag(24);
        output.WriteBool(Highlight);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (OpCode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) OpCode);
      }
      if (ObjectType != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ObjectType);
      }
      if (Highlight != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ObjectManagement other) {
      if (other == null) {
        return;
      }
      if (other.OpCode != 0) {
        OpCode = other.OpCode;
      }
      if (other.ObjectType != 0) {
        ObjectType = other.ObjectType;
      }
      if (other.Highlight != false) {
        Highlight = other.Highlight;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            opCode_ = (global::UnitiyAPI.ObjectControlOpCode) input.ReadEnum();
            break;
          }
          case 16: {
            ObjectType = input.ReadInt32();
            break;
          }
          case 24: {
            Highlight = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  public sealed partial class TacticalObjectManagement : pb::IMessage<TacticalObjectManagement> {
    private static readonly pb::MessageParser<TacticalObjectManagement> _parser = new pb::MessageParser<TacticalObjectManagement>(() => new TacticalObjectManagement());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TacticalObjectManagement> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::UnitiyAPI.UnityAPIReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TacticalObjectManagement() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TacticalObjectManagement(TacticalObjectManagement other) : this() {
      opCode_ = other.opCode_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TacticalObjectManagement Clone() {
      return new TacticalObjectManagement(this);
    }

    /// <summary>Field number for the "op_code" field.</summary>
    public const int OpCodeFieldNumber = 1;
    private global::UnitiyAPI.TacticalObjectOpCode opCode_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::UnitiyAPI.TacticalObjectOpCode OpCode {
      get { return opCode_; }
      set {
        opCode_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TacticalObjectManagement);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TacticalObjectManagement other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (OpCode != other.OpCode) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (OpCode != 0) hash ^= OpCode.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (OpCode != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) OpCode);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (OpCode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) OpCode);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TacticalObjectManagement other) {
      if (other == null) {
        return;
      }
      if (other.OpCode != 0) {
        OpCode = other.OpCode;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            opCode_ = (global::UnitiyAPI.TacticalObjectOpCode) input.ReadEnum();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code