using System;
using System.Text;

namespace Fish.Serialization
{
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

        /// <summary>
        /// Gets the read/write position of the buffer
        /// </summary>
        /// <returns>The read/write position</returns>
        public int GetPosition()
        {
            return position;
        }

        /// <summary>
        /// Sets the read/write position of the buffer
        /// <param name="position">The position to set the read/write to</param>
        /// </summary>
        public void SetPosition(int position)
        {
            this.position = position;
        }

        /// <summary>
        /// Tries to write an object to the buffer as the given type
        /// </summary>
        /// <param name="value">The value of the write object</param>
        /// <param name="type">The type of the object</param>
        /// <returns>True on success and false on failure</returns>
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

        /// <summary>
        /// Tries to read an object from the buffer as the given type
        /// </summary>
        /// <param name="value">The value of the read object</param>
        /// <param name="type">The type of the object</param>
        /// <returns>True on success and false on failure</returns>
        public bool Read(out object value, Type type)
        {
            value = null;

            switch (type)
            {
                case var t when t == typeof(byte): { Read(out byte _t); value = _t; } break;
                case var t when t == typeof(short): { Read(out short _t); value = _t; } break;
                case var t when t == typeof(ushort): { Read(out ushort _t); value = _t; } break;
                case var t when t == typeof(int): { Read(out int _t); value = _t; } break;
                case var t when t == typeof(uint): { Read(out uint _t); value = _t; } break;
                case var t when t == typeof(long): { Read(out long _t); value = _t; } break;
                case var t when t == typeof(ulong): { Read(out ulong _t); value = _t; } break;
                case var t when t == typeof(float): { Read(out float _t); value = _t; } break;
                case var t when t == typeof(double): { Read(out double _t); value = _t; } break;
                case var t when t == typeof(string): { Read(out string _t); value = _t; } break;
                default: return false;
            }

            return true;
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
