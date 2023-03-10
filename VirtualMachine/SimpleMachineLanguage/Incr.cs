using System.Runtime.CompilerServices;

namespace SVM.SimpleMachineLanguage;

/// <summary>
/// Implements the SML Incr  instruction
/// Increments the integer value stored on top of the stack, 
/// leaving the result on the stack
/// </summary>
public class Incr: BaseInstruction
{
    #region TASK 3 - TO BE IMPLEMENTED BY THE STUDENT

    #region Constants
    #endregion

    #region Fields
    #endregion

    #region Constructors
    #endregion
    
    #region Properties
    #endregion

    #region Public methods
    #endregion

    #region Non-public methods
    #endregion

    #region System.Object overrides
    /// <summary>
    /// Determines whether the specified <see cref="System.Object">Object</see> is equal to the current <see cref="System.Object">Object</see>.
    /// </summary>
    /// <param name="obj">The <see cref="System.Object">Object</see> to compare with the current <see cref="System.Object">Object</see>.</param>
    /// <returns><b>true</b> if the specified <see cref="System.Object">Object</see> is equal to the current <see cref="System.Object">Object</see>; otherwise, <b>false</b>.</returns>
    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    /// <summary>
    /// Serves as a hash function for this type.
    /// </summary>
    /// <returns>A hash code for the current <see cref="System.Object">Object</see>.</returns>
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    /// <summary>
    /// Returns a <see cref="System.String">String</see> that represents the current <see cref="System.Object">Object</see>.
    /// </summary>
    /// <returns>A <see cref="System.String">String</see> that represents the current <see cref="System.Object">Object</see>.</returns>
    public override string ToString()
    {
        return base.ToString();
    }
    #endregion

    #region IInstruction Members

    public override void Run()
    {
        try
        {
            var op1 = VirtualMachine.Stack.Pop();
            var opType = op1.GetType();
            if (opType.Name != "Int32")
            {
                throw new SvmRuntimeException("value on top of stack is not an integer");
            }
            else
            {
                int op2 = (int)op1;
                op2++; 
                VirtualMachine.Stack.Push(op2);
            }         
        }
        catch (InvalidCastException)
        {
            throw new SvmRuntimeException(String.Format(BaseInstruction.OperandOfWrongTypeMessage,
                                            this.ToString(), VirtualMachine.ProgramCounter));
        }
    }

    #endregion

    #endregion
}
