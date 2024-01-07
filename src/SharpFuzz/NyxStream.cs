using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SharpFuzz;
public class NyxStream : Stream
{
    public override bool CanRead => true;
    public override bool CanWrite => false;
    public override bool CanSeek => false;
    public override long Length => throw new NotSupportedException();
    public sealed override long Position
    {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        throw new NotSupportedException();
    }

    public override void WriteByte(byte value)
    {
        throw new NotSupportedException();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        return Read(new Span<byte>(buffer, offset, count));
    }

    public override int Read(Span<byte> buffer)
    {
        unsafe
        {
            fixed (byte* buffer2 = buffer)
            {
                return Native.read(0, buffer2, buffer.Length);
            }
        }
    }

    public override int ReadByte()
    {
        byte reference = 0;
        if (Read(MemoryMarshal.CreateSpan(ref reference, 1)) == 0)
        {
            return -1;
        }
        return reference;
    }

    public override void Flush()
    {
        throw new NotSupportedException();
    }

    public sealed override void SetLength(long value)
    {
        throw new NotSupportedException();
    }

    public sealed override long Seek(long offset, SeekOrigin origin)
    {
        throw new NotSupportedException();
    }
}