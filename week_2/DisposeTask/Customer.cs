using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DisposeTask
{
    public class Customer : IDisposable
    {
        private StringReader _reader;
        private bool isDisposed = false;
        public Customer()
        {
            this._reader = new StringReader("test");
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposeValue)
        {
            if (!isDisposed)
            {
                if (disposeValue)
                {
                    if (_reader != null)
                    {
                        this._reader.Dispose();
                    }
                }

                isDisposed = true;
            }
        }
    }
}
