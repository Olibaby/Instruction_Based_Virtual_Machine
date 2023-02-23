namespace SVM.VirtualMachine;

using SVM.VirtualMachine.Debug;
using System.ComponentModel;
using System.Diagnostics;

#region Using directives
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Input;
#endregion

/// <summary>
/// Utility class which generates compiles a textual representation
/// of an SML instruction into an executable instruction instance
/// </summary>
internal static class JITCompiler
{
    #region Constants
    #endregion

    #region Fields
    internal static List<Assembly> loadedAssemblies = new List<Assembly>();
    #endregion

    #region Constructors
    #endregion

    #region Properties
    #endregion

    #region Public methods
    #endregion

    #region Non-public methods
    internal static IInstruction CompileInstruction(string opcode)
    {
        IInstruction instruction = null;
        #region TASK 1 - TO BE IMPLEMENTED BY THE STUDENT
        //Assembly asm2 = Assembly.GetExecutingAssembly();
        //if (asm2 != null)
        //{

        //    foreach (TypeInfo type in asm2.DefinedTypes)
        //    {
        //        if (type.ImplementedInterfaces.Contains(typeof(IInstruction)) && string.Equals(type.Name, opcode, StringComparison.OrdinalIgnoreCase))
        //        {
        //            instruction = (IInstruction)Activator.CreateInstance(type);
        //            Console.WriteLine("created instance" + instruction);
        //            return instruction;
        //        }
        //    }
        //    if (instruction == null)
        //    {
        //        throw new SvmCompilationException("Invalid SML Instruction");
        //    }
        //}
        #endregion

        try
        {
            foreach (Assembly asm in loadedAssemblies)
            {
                if (asm != null)
                {
                    foreach (TypeInfo type in asm.DefinedTypes)
                    {
                        //var test = type.ImplementedInterfaces.Any(c => c.Name == "IInstructionWithOperand");
                        if (type.ImplementedInterfaces.Contains(typeof(IInstruction)) && string.Equals(type.Name, opcode, StringComparison.OrdinalIgnoreCase))
                        {
                            instruction = (IInstruction)Activator.CreateInstance(type);
                            return instruction;
                        }
                    }
                }
            }
        }
        catch
        {
            throw new SvmCompilationException("Invalid SML Instruction");
        }
     
        return instruction;
    }

    internal static IInstruction CompileInstruction(string opcode, params string[] operands)
    {
        IInstructionWithOperand instruction = null;
        #region TASK 1 - TO BE IMPLEMENTED BY THE STUDENT
        //Assembly asm2 = Assembly.GetExecutingAssembly();
        //if (asm2 != null)
        //{
        //    foreach (TypeInfo type in asm2.DefinedTypes)
        //    {
        //        if (type.ImplementedInterfaces.Contains(typeof(IInstructionWithOperand)) && string.Equals(type.Name, opcode, StringComparison.OrdinalIgnoreCase))
        //        {
        //            instruction = (IInstructionWithOperand)Activator.CreateInstance(type);
        //            instruction.Operands = operands;
        //            return instruction;
        //        }
        //    }
        //}
        //if (instruction == null)
        //{
        //    throw new SvmCompilationException("Invalid SML Instruction");
        //}
        #endregion

        try
        {
            foreach (Assembly asm in loadedAssemblies)
            {
                if (asm != null)
                {
                    foreach (TypeInfo type in asm.DefinedTypes)
                    {
                        //var test = type.ImplementedInterfaces.Any(c => c.Name == "IInstructionWithOperand");
                        if (type.ImplementedInterfaces.Contains(typeof(IInstructionWithOperand)) && string.Equals(type.Name, opcode, StringComparison.OrdinalIgnoreCase))
                        {
                            instruction = (IInstructionWithOperand)Activator.CreateInstance(type);
                            instruction.Operands = operands;
                            return instruction;
                        }
                    }
                }
            }
        }
        catch
        {
            throw new SvmCompilationException("Invalid SML Instruction");
        }

        return instruction;
    }

    internal static void loadAssembliesWithInstruction()
    {
        string[] files = Directory.GetFiles(Environment.CurrentDirectory);
        string asm2 = Assembly.GetExecutingAssembly().Location;
        foreach (var file in files)
        {
            try
            {
                AssemblyName.GetAssemblyName(file);
                [DllImport("Mscoree.dll", CharSet = CharSet.Unicode)]
                static extern bool StrongNameSignatureVerificationEx(string wszFilePath, bool fforceverification, ref bool pfwasverified);
                var isStronglyNamed = false;
                StrongNameSignatureVerificationEx(file, true, ref isStronglyNamed);
                if (!isStronglyNamed && file != asm2)
                {
                    continue;
                }
                var fileH = File.OpenRead(file);
                SHA256 mySHA256 = SHA256.Create();
                byte[] fileHash = mySHA256.ComputeHash(fileH);
                string someString = BitConverter.ToString(fileHash).Replace("-", "");
                string[] value = System.Configuration.ConfigurationManager.AppSettings["debuggerHash"].Split(',');
                if (value.Contains(someString) || file == asm2)
                {
                    var asm = Assembly.LoadFrom(file);
                    var test = loadedAssemblies.Any(a => a.FullName == asm.FullName);
                    if (!loadedAssemblies.Any(a => a.FullName == asm.FullName))
                    {
                        loadedAssemblies.Add(asm);
                    }
                }
                else
                {
                    continue;
                    throw new SvmCompilationException("Config file ahould be updated");
                }

            }
            catch (BadImageFormatException)
            {
                continue;
            }
        }
    }
    #endregion


}
