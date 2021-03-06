﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cvl.VirtualMachine.Instructions.Conditional
{
    /// <summary>
    /// Tests whether an object reference (type O) is an instance of a particular class.
    /// https://docs.microsoft.com/en-us/dotnet/api/system.reflection.emit.opcodes.isinst?view=netframework-4.8
    /// </summary>
    public class Isinst : InstructionBase
    {        
        public override void Wykonaj()
        {
            dynamic b = PopObject();
            if (b != null)
            {
                var typ = b.GetType();
                var typOperanda = (Type)Instruction.Operand;
                if (typOperanda.IsAssignableFrom(typ))
                {
                    //mamy ten sam typ
                    PushObject(b);
                }
                else
                {
                    PushObject(null);
                }
            }
            else
            {
                PushObject(null);
            }

            WykonajNastepnaInstrukcje();
        }
    }
}