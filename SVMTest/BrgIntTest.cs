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
    public class BrgIntTest
    {
        [TestMethod]
        public void IsBiggerInt()
        {
            Mock<IVirtualMachine> virtualMachine = new Mock<IVirtualMachine>();
            virtualMachine.Setup(x => x.Stack).Returns(new System.Collections.Stack());

            BgrInt bgrInt = new BgrInt();

            bgrInt.VirtualMachine = virtualMachine.Object;
            bgrInt.VirtualMachine.Stack.Push(4);
            string[] operands = { "5", "incr" };
            bgrInt.Operands = operands;
            int operandValue = int.Parse(bgrInt.Operands[0]);
            int stackValue = (int)bgrInt.VirtualMachine.Stack.Peek();
            Assert.IsTrue(operandValue > stackValue);
        }

        [TestMethod]
        public void IsInteger()
        {
            Mock<IVirtualMachine> virtualMachine = new Mock<IVirtualMachine>();
            virtualMachine.Setup(x => x.Stack).Returns(new System.Collections.Stack());
            BgrInt bgrInt = new BgrInt();

            bgrInt.VirtualMachine = virtualMachine.Object;
            bgrInt.VirtualMachine.Stack.Push(5);
            Assert.AreEqual("Int32", bgrInt.VirtualMachine.Stack.Peek().GetType().Name);
        }

        //[TestMethod]
        //public void IsBranching()
        //{
        //    Mock<IVirtualMachine> virtualMachine = new Mock<IVirtualMachine>();
        //    virtualMachine.Setup(x => x.Stack).Returns(new System.Collections.Stack());
        //    virtualMachine.Setup(x => x.Location).Returns(new StringDictionary());
        //    virtualMachine.Setup(x => x.ProgramCounter).Returns(6); 

        //    BgrInt bgrInt = new BgrInt();

        //    bgrInt.VirtualMachine = virtualMachine.Object;
        //    bgrInt.VirtualMachine.Stack.Push(4);
        //    bgrInt.VirtualMachine.Location.Add("7", "incr");
        //    string[] operands = { "5", "incr" };
        //    bgrInt.Operands = operands;
        //    bgrInt.Run();
        //    Assert.AreEqual(bgrInt.VirtualMachine.ProgramCounter, bgrInt.VirtualMachine.Location["7"]);
        //}

    }
}
