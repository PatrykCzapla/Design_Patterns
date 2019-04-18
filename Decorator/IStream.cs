using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public interface IStream
    {
        char ReadNext();
        bool AtEnd();
    }

    public abstract class IStreamDecorator : IStream
    {
        protected IStream istream;

        public IStreamDecorator(IStream istream)
        {
            this.istream = istream;
        }
        public virtual bool AtEnd()
        {
            return istream.AtEnd();
        }
        public virtual char ReadNext()
        {
            return istream.ReadNext();
        }
    }

    public class ToSmallDecorator: IStreamDecorator
    {
        public ToSmallDecorator(IStream istream):base(istream)
        {
        }
        public override bool AtEnd()
        {
            return this.istream.AtEnd();
        }
        public override char ReadNext()
        {
            char c = istream.ReadNext();
            return char.ToLower(c);
        }
    }

    public class ToGreaterDecorator : IStreamDecorator
    {
        public ToGreaterDecorator(IStream istream) : base(istream)
        {
        }
        public override bool AtEnd()
        {
            return this.istream.AtEnd();
        }
        public override char ReadNext()
        {
            char c = istream.ReadNext();
            return char.ToUpper(c);
        }
    }

    public class SpaceDecorator : IStreamDecorator
    {
        public SpaceDecorator(IStream istream) : base(istream)
        {
        }
        public override bool AtEnd()
        {
            return this.istream.AtEnd();
        }
        public override char ReadNext()
        {
            char c = istream.ReadNext();
            if (c.Equals(" ".ToCharArray().First()))
            {
                return "_".ToCharArray().First();
            }
            else return c;
        }
    }

    public class ConcatenateDecorator : IStreamDecorator
    {
        IStream istream2;
        public ConcatenateDecorator(IStream istream, IStream istream2) : base(istream)
        {
            this.istream2 = istream2;
        }
        public override bool AtEnd()
        {
            return this.istream.AtEnd()&&istream2.AtEnd();
        }
        public override char ReadNext()
        {
            if (!istream.AtEnd()) return istream.ReadNext();
            else return istream2.ReadNext();
        }
    }

    public class ConcatenateAndFirstToSmallDecorator : IStreamDecorator
    {
        IStream istream2;

        public ConcatenateAndFirstToSmallDecorator(IStream istream, IStream istream2) : base(istream)
        {
            this.istream = new ToSmallDecorator(istream);
            this.istream2 = new ToGreaterDecorator(istream2);
        }
        public override bool AtEnd()
        {
            return this.istream.AtEnd() && istream2.AtEnd();
        }

        public override char ReadNext()
        {
            if (!istream.AtEnd()) return istream.ReadNext();
            else return istream2.ReadNext();
        }
    }

    public class DeleteVowelsDecorator : IStreamDecorator
    {
        public DeleteVowelsDecorator(IStream istream) : base(istream)
        {
        }
        public override bool AtEnd()
        {
            return this.istream.AtEnd();
        }
        public override char ReadNext()
        {
            char[] vovels = { 'a', 'e', 'y', 'o', 'i', 'u' };
            char c = istream.ReadNext();
            while (vovels.Contains(c)&&!istream.AtEnd())
            {
                c = istream.ReadNext();
            }             
            return c;
        }
    }

    public class AfterDotGreaterDecorator : IStreamDecorator
    {
        bool isDot = false;

        public AfterDotGreaterDecorator(IStream istream) : base(istream)
        {
        }
        public override bool AtEnd()
        {
            return this.istream.AtEnd();
        }
        public override char ReadNext()
        {
            char c = istream.ReadNext();
            if (c.Equals(".".ToCharArray().First()))
            {
                isDot = true;
                return c;
            }
            if (isDot)
            {
                isDot = false;
                return char.ToUpper(c);
            }
            else return c;

        }
    }

    public class CipherDecorator : IStreamDecorator
    {
        int n;

        public CipherDecorator(IStream istream, int n) : base(istream)
        {
            this.n = n;
        }        public override bool AtEnd()
        {
            return this.istream.AtEnd();
        }
        public override char ReadNext()
        {
            char c = istream.ReadNext();
            if (char.IsNumber(c)) return c;
            else return (char)(c + n);
        }
    }

    public class GreaterLowerDecorator : IStreamDecorator
    {
        int count = 0;

        public GreaterLowerDecorator(IStream istream) : base(istream)
        {
        }
        public override bool AtEnd()
        {
            return this.istream.AtEnd();
        }
        public override char ReadNext()
        {
            char c = istream.ReadNext();
            return (count++ % 2 == 0) ? char.ToUpper(c) : char.ToLower(c);
        }
    }

    public class OnlyNFirstCharsDecorator : IStreamDecorator
    {
        int N;
        int counter = 0;

        public OnlyNFirstCharsDecorator(IStream istream, int N) : base(istream)
        {
            this.N = N;
        }
        public override bool AtEnd()
        {
            if (counter == N) return true;
            counter++;
            return this.istream.AtEnd();
        }
        public override char ReadNext()
        {
            return istream.ReadNext();
        }
    }

    public class SkipNDecorator : IStreamDecorator
    {
        int N;
        int counter = 0;

        public SkipNDecorator(IStream istream, int N) : base(istream)
        {
            this.N = N;
        }
        public override bool AtEnd()
        {
            return this.istream.AtEnd();
        }
        public override char ReadNext()
        {
            while(counter < N && !AtEnd())
            {
                istream.ReadNext();
                counter++;
            }
            return istream.ReadNext();
        }
    } 

}