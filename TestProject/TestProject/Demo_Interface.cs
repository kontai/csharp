using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TestProject
{
    internal class Demo_Interface
    {
        static void Main(string[] args)
        {
            IUndoable iu = new TextBox();
            iu.undo();

            IUndoable ir = new RichTextBox();
            ir.undo();
        }
    }

    public interface IUndoable
    {
        void undo();
    }

    public class TextBox : IUndoable
    {
        public virtual void undo() => Console.WriteLine("TextBox undo");
    }

    public class RichTextBox : TextBox
    {
        public override void undo() => Console.WriteLine("RichTextBox undo");
    }
}