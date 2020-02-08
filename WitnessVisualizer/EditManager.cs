using PuzzleGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitnessVisualizer
{
    class EditManager<T> where T : ICloneable
    {
        const int UNDO_STACK_SIZE = 50;
        T newestRecord;
        LinkedList<KeyValuePair<string, T>> undoStack;
        LinkedListNode<KeyValuePair<string, T>> undoPtr, redoPtr;
        public bool CanUndo
        {
            get { return undoPtr != null; }
        }
        public string LastUndoInfo
        {
            get { return CanUndo ? undoPtr.Value.Key : ""; }
        }
        public bool CanRedo
        {
            get { return undoPtr != redoPtr; }
        }
        public string LastRedoInfo
        {
            get { return CanRedo ? (undoPtr == null ? undoStack.First : undoPtr.Next).Value.Key : ""; }
        }
        public EditManager()
        {
            Reset();
        }
        public void Reset()
        {
            undoStack = new LinkedList<KeyValuePair<string, T>>();
            undoPtr = redoPtr = null;
        }
        public void BeforePreformEdit(T state, string commandName)
        {
            while (undoPtr != redoPtr)
            {
                var preNode = redoPtr.Previous;
                undoStack.Remove(redoPtr);
                redoPtr = preNode;
            }
            string localizedCommandName = Resources.Lang.ResourceManager.GetString("Undo>>" + commandName) ?? commandName;
            undoPtr = new LinkedListNode<KeyValuePair<string, T>>(
                new KeyValuePair<string, T>(localizedCommandName, (T)state.Clone()));
            redoPtr = undoPtr;

            undoStack.AddLast(undoPtr);
            if (undoStack.Count > UNDO_STACK_SIZE) undoStack.RemoveFirst();
        }
        public T Undo(T state)
        {
            if (CanUndo)
            {
                if (!CanRedo)
                {
                    newestRecord = state;
                }
                T result = undoPtr.Value.Value;
                if (undoPtr == undoStack.First)
                {
                    undoPtr = null;
                }
                else undoPtr = undoPtr.Previous;
                return result;
            }
            return default;
        }
        public T Redo()
        {
            if (CanRedo)
            {
                undoPtr = undoPtr == null ? undoStack.First : undoPtr.Next;
                return CanRedo ? undoPtr.Next.Value.Value : newestRecord;
            }
            return default;
        }
    }
}
