.class public auto ansi beforefieldinit
  CalculatorIL.Calculator
    extends System.Object
{

  .class nested public sealed auto ansi
    Operation
      extends System.Enum
  {

    .field public specialname rtspecialname int32 value__

    .field public static literal valuetype CalculatorIL.Calculator/Operation Plus = int32(0) // 0x00000000
      .custom instance void [System.ComponentModel.Primitives]System.ComponentModel.DescriptionAttribute::.ctor(string)
        = (01 00 01 2b 00 00 ) 

    .field public static literal valuetype CalculatorIL.Calculator/Operation Minus = int32(1) // 0x00000001
      .custom instance void [System.ComponentModel.Primitives]System.ComponentModel.DescriptionAttribute::.ctor(string)
        = (01 00 01 2d 00 00 )

    .field public static literal valuetype CalculatorIL.Calculator/Operation Multiply = int32(2) // 0x00000002
      .custom instance void [System.ComponentModel.Primitives]System.ComponentModel.DescriptionAttribute::.ctor(string)
        = (01 00 01 2a 00 00 )

    .field public static literal valuetype CalculatorIL.Calculator/Operation Divide = int32(3) // 0x00000003
      .custom instance void [System.ComponentModel.Primitives]System.ComponentModel.DescriptionAttribute::.ctor(string)
        = (01 00 01 2f 00 00 )
        
    .field public static literal valuetype CalculatorIL.Calculator/Operation IncorrectOperation = int32(4) // 0x00000004
  }

  .method public hidebysig static string
    GetDescription(
      class System.Enum operation
    ) cil managed
  {
    .maxstack 3
    .locals init (
      [0] class [System.Runtime]System.Type 'type',
      [1] class [System.Runtime]System.Reflection.MemberInfo[] memInfo,
      [2] bool V_2,
      [3] object[] attrs,
      [4] bool V_4,
      [5] string V_5
    )
    ldarg.0      // operation
    callvirt     instance class [System.Runtime]System.Type System.Object::GetType()
    stloc.0      // 'type'

    ldloc.0      // 'type'
    ldarg.0      // operation
    callvirt     instance string System.Object::ToString()
    callvirt     instance class [System.Runtime]System.Reflection.MemberInfo[] [System.Runtime]System.Type::GetMember(string)
    stloc.1      // memInfo

    ldloc.1      // memInfo
    brfalse.s    IL_001f
    ldloc.1      // memInfo
    ldlen
    ldc.i4.0
    cgt.un
    br.s         IL_0020
    IL_001f: ldc.i4.0
    IL_0020: stloc.2      // V_2

    ldloc.2      // V_2
    brfalse.s    IL_005c

    ldloc.1      // memInfo
    ldc.i4.0
    ldelem.ref
    ldtoken      [System.ComponentModel.Primitives]System.ComponentModel.DescriptionAttribute
    call         class [System.Runtime]System.Type [System.Runtime]System.Type::GetTypeFromHandle(valuetype [System.Runtime]System.RuntimeTypeHandle)
    ldc.i4.0
    callvirt     instance object[] [System.Runtime]System.Reflection.MemberInfo::GetCustomAttributes(class [System.Runtime]System.Type, bool)
    stloc.3      // attrs

    ldloc.3      // attrs
    brfalse.s    IL_0043
    ldloc.3      // attrs
    ldlen
    ldc.i4.0
    cgt.un
    br.s         IL_0044
    IL_0043: ldc.i4.0
    IL_0044: stloc.s      V_4

    ldloc.s      V_4
    brfalse.s    IL_005b

    ldloc.3      // attrs
    ldc.i4.0
    ldelem.ref
    castclass    [System.ComponentModel.Primitives]System.ComponentModel.DescriptionAttribute
    callvirt     instance string [System.ComponentModel.Primitives]System.ComponentModel.DescriptionAttribute::get_Description()
    stloc.s      V_5
    br.s         IL_0066

    IL_005b: nop

    IL_005c: ldarg.0      // operation
    callvirt     instance string System.Object::ToString()
    stloc.s      V_5
    br.s         IL_0066

    IL_0066: ldloc.s      V_5
    ret

  }

  .method public hidebysig static float64
    Calculate(
      int32 val1,
      valuetype CalculatorIL.Calculator/Operation operation,
      int32 val2
    ) cil managed
  {
    .maxstack 3
    
    ldarg.0
    conv.r8
    ldarg.2
    conv.r8
    
    ldarg.1
    
    switch(plus, minus, multiply, divide)
    
    plus: add ret
    minus: sub ret
    multiply: mul ret
    divide: div ret
  }
}
