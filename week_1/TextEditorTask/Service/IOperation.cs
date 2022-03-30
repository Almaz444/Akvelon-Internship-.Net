using System;
using System.Collections.Generic;
using System.Text;

namespace TextEditorTask.Service
{
    public interface IOperation
    {
        public void Undo();
        public void Redo();
    }
}
