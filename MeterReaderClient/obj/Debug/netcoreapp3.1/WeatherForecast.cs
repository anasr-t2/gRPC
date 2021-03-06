// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: WeatherForecast.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace WeatherForecast {

  /// <summary>Holder for reflection information generated from WeatherForecast.proto</summary>
  public static partial class WeatherForecastReflection {

    #region Descriptor
    /// <summary>File descriptor for WeatherForecast.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static WeatherForecastReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChVXZWF0aGVyRm9yZWNhc3QucHJvdG8aG2dvb2dsZS9wcm90b2J1Zi9lbXB0",
            "eS5wcm90bxofZ29vZ2xlL3Byb3RvYnVmL3RpbWVzdGFtcC5wcm90byJ9CgtX",
            "ZWF0aGVyRGF0YRIxCg1kYXRlVGltZVN0YW1wGAEgASgLMhouZ29vZ2xlLnBy",
            "b3RvYnVmLlRpbWVzdGFtcBIUCgx0ZW1wZXJhdHVyZUMYAiABKAUSFAoMdGVt",
            "cGVyYXR1cmVGGAMgASgFEg8KB3N1bW1hcnkYBCABKAkyTgoQV2VhdGhlckZv",
            "cmVjYXN0cxI6ChBHZXRXZWF0aGVyU3RyZWFtEhYuZ29vZ2xlLnByb3RvYnVm",
            "LkVtcHR5GgwuV2VhdGhlckRhdGEwAUISqgIPV2VhdGhlckZvcmVjYXN0YgZw",
            "cm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::WeatherForecast.WeatherData), global::WeatherForecast.WeatherData.Parser, new[]{ "DateTimeStamp", "TemperatureC", "TemperatureF", "Summary" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class WeatherData : pb::IMessage<WeatherData> {
    private static readonly pb::MessageParser<WeatherData> _parser = new pb::MessageParser<WeatherData>(() => new WeatherData());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<WeatherData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::WeatherForecast.WeatherForecastReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WeatherData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WeatherData(WeatherData other) : this() {
      dateTimeStamp_ = other.dateTimeStamp_ != null ? other.dateTimeStamp_.Clone() : null;
      temperatureC_ = other.temperatureC_;
      temperatureF_ = other.temperatureF_;
      summary_ = other.summary_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WeatherData Clone() {
      return new WeatherData(this);
    }

    /// <summary>Field number for the "dateTimeStamp" field.</summary>
    public const int DateTimeStampFieldNumber = 1;
    private global::Google.Protobuf.WellKnownTypes.Timestamp dateTimeStamp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp DateTimeStamp {
      get { return dateTimeStamp_; }
      set {
        dateTimeStamp_ = value;
      }
    }

    /// <summary>Field number for the "temperatureC" field.</summary>
    public const int TemperatureCFieldNumber = 2;
    private int temperatureC_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int TemperatureC {
      get { return temperatureC_; }
      set {
        temperatureC_ = value;
      }
    }

    /// <summary>Field number for the "temperatureF" field.</summary>
    public const int TemperatureFFieldNumber = 3;
    private int temperatureF_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int TemperatureF {
      get { return temperatureF_; }
      set {
        temperatureF_ = value;
      }
    }

    /// <summary>Field number for the "summary" field.</summary>
    public const int SummaryFieldNumber = 4;
    private string summary_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Summary {
      get { return summary_; }
      set {
        summary_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as WeatherData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(WeatherData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(DateTimeStamp, other.DateTimeStamp)) return false;
      if (TemperatureC != other.TemperatureC) return false;
      if (TemperatureF != other.TemperatureF) return false;
      if (Summary != other.Summary) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (dateTimeStamp_ != null) hash ^= DateTimeStamp.GetHashCode();
      if (TemperatureC != 0) hash ^= TemperatureC.GetHashCode();
      if (TemperatureF != 0) hash ^= TemperatureF.GetHashCode();
      if (Summary.Length != 0) hash ^= Summary.GetHashCode();
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
      if (dateTimeStamp_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(DateTimeStamp);
      }
      if (TemperatureC != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(TemperatureC);
      }
      if (TemperatureF != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(TemperatureF);
      }
      if (Summary.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Summary);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (dateTimeStamp_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(DateTimeStamp);
      }
      if (TemperatureC != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(TemperatureC);
      }
      if (TemperatureF != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(TemperatureF);
      }
      if (Summary.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Summary);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(WeatherData other) {
      if (other == null) {
        return;
      }
      if (other.dateTimeStamp_ != null) {
        if (dateTimeStamp_ == null) {
          DateTimeStamp = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        DateTimeStamp.MergeFrom(other.DateTimeStamp);
      }
      if (other.TemperatureC != 0) {
        TemperatureC = other.TemperatureC;
      }
      if (other.TemperatureF != 0) {
        TemperatureF = other.TemperatureF;
      }
      if (other.Summary.Length != 0) {
        Summary = other.Summary;
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
          case 10: {
            if (dateTimeStamp_ == null) {
              DateTimeStamp = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(DateTimeStamp);
            break;
          }
          case 16: {
            TemperatureC = input.ReadInt32();
            break;
          }
          case 24: {
            TemperatureF = input.ReadInt32();
            break;
          }
          case 34: {
            Summary = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
