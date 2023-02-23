using Moq;
using SVM.SimpleMachineLanguage;
using SVM.VirtualMachine;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVMTest
{
    [TestClass]
    public class BltIntTest
    {
        [TestMethod]
        public void IsLowerInt()
        {
            Mock<IVirtualMachine> virtualMachine = new Mock<IVirtualMachine>();
            virtualMachine.Setup(x => x.Stack).Returns(new System.Collections.Stack());

            BltInt bltInt = new BltInt();

            bltInt.VirtualMachine = virtualMachine.Object;
            bltInt.VirtualMachine.Stack.Push(5);
            string[] operands = { "4", "incr" };
            bltInt.Operands = operands;
            int operandValue = int.Parse(bltInt.Operands[0]);
            int stackValue = (int)bltInt.VirtualMachine.Stack.Peek();
            Assert.IsTrue(operandValue < stackValue);
        }

        [TestMethod]
        public void IsInteger()
        {
            Mock<IVirtualMachine> virtualMachine = new Mock<IVirtualMachine>();
            virtualMachine.Setup(x => x.Stack).Returns(new System.Collections.Stack());
            BltInt bltInt = new BltInt();

            bltInt.VirtualMachine = virtualMachine.Object;
            bltInt.VirtualMachine.Stack.Push(5);
            Assert.AreEqual("Int32", bltInt.VirtualMachine.Stack.Peek().GetType().Name);
        }


    }
}
