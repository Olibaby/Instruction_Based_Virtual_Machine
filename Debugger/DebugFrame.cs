using SVM.VirtualMachine;
using System;
using System.Collections.Generic;
using SVM.VirtualMachine.Debug;

namespace Debugger
{
    internal class DebugFrame : IDebugFrame
    {
        #region Constants
        protected const string VirtualMachineErrorMessage = "A virtual machine error has occurred.";
        #endregion

        #region IDebugFrame Members
        private IInstruction currentInstruction = null;
        private List<IInstruction> codeFrame = null;    

        public IInstruction CurrentInstruction {
            get
            {
                return currentInstruction;
            }
            set
            {
                if (null == value)
                {
                    throw new SvmRuntimeException(VirtualMachineErrorMessage);
                }
                currentInstruction = value;
            }
        }

        public List<IInstruction> CodeFrame {
            get
            {
                return codeFrame;
            }
            set
            {
                if (null == value)
                {
                    throw new SvmRuntimeException(VirtualMachineErrorMessage);
                }
                codeFrame = value;
            }
        }
        #endregion
    }
}
