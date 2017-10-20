using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez_2._0
{
    public class EditorCommandManager
    {
        private static EditorCommandManager instance = new EditorCommandManager();

        public static EditorCommandManager Instance { get { return instance; } }

        private Stack<EditorCommand> doneCommands = new Stack<EditorCommand>();
        private Stack<EditorCommand> undoneCommands = new Stack<EditorCommand>();

        public void Do(EditorCommand command)
        {
            command.Ejecutar();
            doneCommands.Push(command);
            undoneCommands.Clear();
        }

        public void Undo()
        {
            if (doneCommands.Count <= 0) return;
            EditorCommand command = doneCommands.Pop();
            command.Revertir();
            undoneCommands.Push(command);
        }

        public void Redo()
        {
            if (undoneCommands.Count <= 0) return;
            EditorCommand command = undoneCommands.Pop();
            command.Ejecutar();
            doneCommands.Push(command);
        }

    }
}
