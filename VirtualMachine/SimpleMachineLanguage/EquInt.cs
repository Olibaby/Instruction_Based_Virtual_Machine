using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVM.SimpleMachineLanguage
{
    public class EquInt: BaseInstructionWithOperand
    {
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
            var popValue = VirtualMachine.Stack.Peek();

            var opType = popValue.GetType();

            if (opType.Name != "Int32")

            {

                throw new SvmRuntimeException("value on top of stack is not an integer");

            }

            else

            {

                var operandValue = int.Parse(Operands[0]);

                var stackValue = (int)popValue;

                if (operandValue == stackValue)

                {

                    if (VirtualMachine.Location.ContainsValue(Operands[1]))

                    {

                        if (VirtualMachine.Location.ContainsKey(Operands[1]))

                        {
                            var value = VirtualMachine.Location[Operands[1]];
                            VirtualMachine.ProgramCounter = int.Parse(value) - 1;
                        }

                    }

                }

            }
        }

        #endregion
    }
}
