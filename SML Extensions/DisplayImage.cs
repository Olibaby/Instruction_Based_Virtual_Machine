using SVM.VirtualMachine;
using SVM.VirtualMachine.Debug;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SML_Extensions
{
    internal class DisplayImage: BaseInstruction
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
            if (VirtualMachine.Stack.Count < 1)
            {
                throw new SvmRuntimeException(String.Format(BaseInstruction.StackUnderflowMessage,
                                                this.ToString(), VirtualMachine.ProgramCounter));
            }

            //Console.WriteLine(VirtualMachine.Stack.Pop().ToString());

            try
            {
                var opImage = VirtualMachine.Stack.Pop();
                var opType = opImage.GetType();
                if (opType.Name != "Bitmap")
                {
                    throw new SvmRuntimeException("value on top of stack is not an image");
                }
                else
                {
                    var f = new ImageDisplay();
                    try
                    {
                        var img = (Image)opImage;
                        f.image = img;
                        f.ShowDialog();
                    }
                    catch
                    {
                        throw new SvmRuntimeException("can't load image");
                    }                
                }
            }
            catch (InvalidCastException)
            {
                throw new SvmRuntimeException(String.Format(BaseInstruction.OperandOfWrongTypeMessage,
                                                this.ToString(), VirtualMachine.ProgramCounter));
            }
        }

        #endregion
    }
}
