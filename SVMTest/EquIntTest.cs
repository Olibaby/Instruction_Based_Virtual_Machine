using Moq;
using SVM.SimpleMachineLanguage;
using SVM.VirtualMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVMTest
{
    [TestClass]
    public class EquIntTest
    {

        [TestMethod]
        public void IsEquInt()
        {
            Mock<IVirtualMachine> virtualMachine = new Mock<IVirtualMachine>();
            virtualMachine.Setup(x => x.Stack).Returns(new System.Collections.Stack());

            EquInt equInt = new EquInt();

            equInt.VirtualMachine = virtualMachine.Object;
            equInt.VirtualMachine.Stack.Push(5);
            string[] operands = { "5", "incr" };
            equInt.Operands = operands;
            int operandValue = int.Parse(equInt.Operands[0]);
            int stackValue = (int)equInt.VirtualMachine.Stack.Peek();
            Assert.IsTrue(operandValue == stackValue);
        }

        [TestMethod]
        public void IsInteger()
        {
            Mock<IVirtualMachine> virtualMachine = new Mock<IVirtualMachine>();
            virtualMachine.Setup(x => x.Stack).Returns(new System.Collections.Stack());
            EquInt equInt = new EquInt();

            equInt.VirtualMachine = virtualMachine.Object;
            equInt.VirtualMachine.Stack.Push(5);
            Assert.AreEqual("Int32", equInt.VirtualMachine.Stack.Peek().GetType().Name);
        }


    }
}
