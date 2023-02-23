using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Debugger;
using SVM.VirtualMachine;
using SVM.VirtualMachine.Debug;


public class DebuggerClass : IDebugger
{
    #region Fields
    private IVirtualMachine virtualMachine = null;
    public int debugCounter = 0;
    #endregion
    #region TASK 5 - TO BE IMPLEMENTED BY THE STUDENT
      IVirtualMachine IDebugger.VirtualMachine {
        get
        {
            return virtualMachine;
        }
        set
        {
            if (null == value)
            {
                throw new SvmRuntimeException("A virtual machine error has occurred.");
            }
            virtualMachine = value;
        }
    } 

    void IDebugger.Break(IDebugFrame debugFrame)
    {

        var f = new DebugWindow();
        f.passInstruction(debugFrame.CodeFrame, debugFrame.CurrentInstruction, virtualMachine);
        debugCounter = f.contineDebug(debugCounter);   
        f.ShowDialog();   
    }
    #endregion
}


