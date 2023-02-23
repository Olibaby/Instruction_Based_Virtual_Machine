using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class NotEquTest
    {

        [TestMethod]
        public void IsNotEqu()
        {
            Mock<IVirtualMachine> virtualMachine = new Mock<IVirtualMachine>();
            virtualMachine.Setup(x => x.Stack).Returns(new System.Collections.Stack());

            EquInt equInt = new EquInt();

            equInt.VirtualMachine = virtualMachine.Object;
            equInt.VirtualMachine.Stack.Push(4);
            equInt.VirtualMachine.Stack.Push("add");
            var stackValue1 = equInt.VirtualMachine.Stack.Pop();
            var stackValue2 = equInt.VirtualMachine.Stack.Pop();
            Assert.IsTrue(stackValue1 != stackValue2);
        }

    }
}
