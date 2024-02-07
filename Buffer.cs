using System;
using System.Text;

namespace Fish.Serialization{
    public class Buffer
    {
        public byte[] buffer;
        int position = 0;
    
        public static Encoding encoding = Encoding.Unicode;
    
        public static implicit operator byte[](Buffer buffer) { return buffer.buffer; }
        public static implicit operator Buffer(byte[] array) { return new Buffer(array); }
    
        public Buffer(int bufferSize)
        {
            buffer = new byte[bufferSize];
        }
    
        Buffer(byte[] buffer)
        {
            this.buffer = buffer;
        }
    
        public bool Write(object value, Type type)
        {
            if (value is null)
                return false;
    
            switch (type)
            {
                case var t when t == typeof(byte): Write((byte)value); break;
                case var t when t == typeof(short): Write((short)value); break;
                case var t when t == typeof(ushort): Write((ushort)value); break;
                case var t when t == typeof(int): Write((int)value); break;
                case var t when t == typeof(uint): Write((uint)value); break;
                case var t when t == typeof(long): Write((long)value); break;
                case var t when t == typeof(ulong): Write((ulong)value); break;
                case var t when t == typeof(float): Write((float)value); break;
                case var t when t == typeof(double): Write((double)value); break;
                case var t when t == typeof(string): Write((string)value); break;
                default: return false;
            }
    
            return true;
        }
    
        public void Write(byte value)
        {
            buffer[position] = value;
    
            position += sizeof(byte);
        }
    
        public void Write(short value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            bytes.CopyTo(buffer, position);
    
            position += bytes.Length;
        }
    
        public void Write(ushort value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            bytes.CopyTo(buffer, position);
    
            position += bytes.Length;
        }
    
        public void Write(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            bytes.CopyTo(buffer, position);
    
            position += bytes.Length;
        }
    
        public void Write(uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            bytes.CopyTo(buffer, position);
    
            position += bytes.Length;
        }
    
        public void Write(long value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            bytes.CopyTo(buffer, position);
    
            position += bytes.Length;
        }
    
        public void Write(ulong value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            bytes.CopyTo(buffer, position);
    
            position += bytes.Length;
        }
    
        public void Write(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            bytes.CopyTo(buffer, position);
    
            position += bytes.Length;
        }
    
        public void Write(double value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            bytes.CopyTo(buffer, position);
    
            position += bytes.Length;
        }
    
        public void Write(string value)
        {
            int length = encoding.GetByteCount(value);
    
            Write(length);
    
            byte[] bytes = encoding.GetBytes(value);
            bytes.CopyTo(buffer, position);
    
            position += length;
        }
    
        public void Read(out byte value)
        {
            value = buffer[position];
            position += sizeof(byte);
        }
    
        public void Read(out short value)
        {
            value = BitConverter.ToInt16(buffer, position);
            position += sizeof(int);
        }
    
        public void Read(out ushort value)
        {
            value = BitConverter.ToUInt16(buffer, position);
            position += sizeof(int);
        }
    
        public void Read(out int value)
        {
            value = BitConverter.ToInt32(buffer, position);
            position += sizeof(int);
        }
    
        public void Read(out uint value)
        {
            value = BitConverter.ToUInt32(buffer, position);
            position += sizeof(int);
        }
    
        public void Read(out long value)
        {
            value = BitConverter.ToInt64(buffer, position);
            position += sizeof(int);
        }
    
        public void Read(out ulong value)
        {
            value = BitConverter.ToUInt64(buffer, position);
            position += sizeof(int);
        }
    
        public void Read(out float value)
        {
            value = BitConverter.ToSingle(buffer, position);
            position += sizeof(float);
        }
    
        public void Read(out double value)
        {
            value = BitConverter.ToDouble(buffer, position);
            position += sizeof(float);
        }
    
        public void Read(out string value)
        {
            Read(out int length);
    
            value = encoding.GetString(buffer, position, length);
            position += length;
        }
    }
}